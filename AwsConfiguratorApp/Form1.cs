using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AwsConfigurator.Configuration;
using AwsConfigurator.DataManagers;
using AwsConfigurator.Extensions;
using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;
using AwsConfigurator.Installer;
using Syncfusion.Windows.Forms.Tools;
using CredentialProfile = AwsConfigurator.Model.CredentialProfile;
using NAudio.Wave;
using Squirrel;

namespace AwsConfiguratorApp
{
    public partial class mainForm : Form
    {
        private Voice _selectedVoice;
        private TreeNodeAdv _selectedNode;
        private List<CredentialProfile> _profileList;
        private string ClsId;
        private List<string> installedVoices = new List<string>();
        private List<Voice> allVoices;
        private List<string> voicesToBeAdded = new List<string>();
        private List<string> voicesToBeDeleted = new List<string>();

        public mainForm()
        {
            ClsId = System.Configuration.ConfigurationManager.AppSettings["PollyTTSEngineClsId"];
            InitializeComponent();
        }

        private async void mainForm_Load(object sender, EventArgs e)
        {
            var fs = new FileSystem();
            var configFileDataManager = new ConfigFileDataManager(new FileSystem(),
                ConfigSource.ConfigFile);
            var path = System.Environment.GetEnvironmentVariable("USERPROFILE");
            _profileList = configFileDataManager.Load($@"{path}\.aws\config");
            _profileList = _profileList.Merge(configFileDataManager.Load($@"{path}\.aws\credentials"));
            foreach (var profile in _profileList)
            {
                profileNameListBox.Items.Add(profile.ProfileName);
            }
            
            RefreshVersions();
            await GetAllVoices();
            versionLabel.Text = $@"v{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion}";
        }

        private void profileNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var credentialProfile =
                _profileList.FirstOrDefault(p => p.ProfileName == profileNameListBox.SelectedItem.ToString());
            awsKeyTextBox.Text = credentialProfile.Items.Any(cp=>cp.Key == ConfigKey.AwsAccessKeyId)?
                credentialProfile.Items[ConfigKey.AwsAccessKeyId].Value : string.Empty;
            awsSecretAccessKeyIdTextBox.Text = credentialProfile.Items.Any(cp => cp.Key == ConfigKey.AwsSecretAccessKey) ?
                credentialProfile.Items[ConfigKey.AwsSecretAccessKey].Value : string.Empty;

            var region = credentialProfile.Items[ConfigKey.Region].Value;
            regionComboBox.SelectedItem = "No Region Selected";
            if (credentialProfile.Items.Any(cp => cp.Key == ConfigKey.Region))
            {
                foreach (var item in regionComboBox.Items)
                {
                    if (item.ToString().StartsWith($"{region} "))
                    {
                        regionComboBox.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void checkSoftwareVersion_Click(object sender, EventArgs e)
        {
            RefreshVersions();
        }

        private async Task GetAllVoices()
        {
            var client = new AmazonPollyClient(RegionEndpoint.USEast1);
            var describeVoiceResponse = await client.DescribeVoicesAsync(new DescribeVoicesRequest());
            pollyTreeView.Root.SortOrder = SortOrder.Ascending;
            var voiceManager = new VoiceManager(ClsId);
            allVoices = describeVoiceResponse.Voices;
            foreach (var voice in allVoices)
            {
                TreeNodeAdv languageNode = null;

                foreach (TreeNodeAdv node in pollyTreeView.Nodes)
                {
                    if (node.Text.Equals(voice.LanguageName))
                    {
                        languageNode = node;
                        break;
                    }
                }

                if (languageNode == null)
                {
                    var treeNodeAdv = new TreeNodeAdv(voice.LanguageName);
                    var nodeIndex = pollyTreeView.Root.Nodes.Add(treeNodeAdv);
                    languageNode = pollyTreeView.Root.Nodes[nodeIndex];
                    languageNode.CheckStateChanged += CheckStateChanged;
                }

                TreeNodeAdv genderNode = null;
                foreach (TreeNodeAdv node in languageNode.Nodes)
                {
                    if (!node.Text.Equals(voice.Gender)) continue;
                    genderNode = node;
                    break;
                }

                if (genderNode == null)
                {
                    var treeNodeAdv = new TreeNodeAdv(voice.Gender);
                    var nodeIndex = languageNode.Nodes.Add(treeNodeAdv);
                    genderNode = languageNode.Nodes[nodeIndex];
                }

                genderNode.CheckStateChanged += CheckStateChanged;
                if (voiceManager.IsVoiceInstalled(voice))
                {
                    installedVoices.Add(voice.Id);
                }
                var voiceNodeIndex = genderNode.Nodes.Add(new TreeNodeAdv()
                {
                    Text = voice.Name,
                    Tag = voice,
                    Checked = voiceManager.IsVoiceInstalled(voice)
                });
                genderNode.SortOrder = SortOrder.Ascending;
                genderNode.Nodes[voiceNodeIndex].CheckStateChanged += CheckStateChanged;
            }
            
            pollyTreeView.Root.Sort();
        }

        private void syncVoiceSelections(TreeNodeAdv currentNode)
        {
            foreach (TreeNodeAdv node in currentNode.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    syncVoiceSelections(node);
                }
                var voice = (Voice) node.Tag;
                if (voice == null) continue;
                if (node.Checked)
                {
                    if (voicesToBeDeleted.Contains(voice.Id))
                    {
                        voicesToBeDeleted.Remove(voice.Id);
                    }

                    if (installedVoices.Contains(voice.Id) || voicesToBeAdded.Contains(voice.Id))
                    {
                        continue;
                    }
                    else
                    {
                        voicesToBeAdded.Add(voice.Id);
                    }
                }
                else
                {
                    if (voicesToBeAdded.Contains(voice.Id))
                    {
                        voicesToBeAdded.Remove(voice.Id);
                    }

                    if (!installedVoices.Contains(voice.Id) || voicesToBeDeleted.Contains(voice.Id))
                    {
                        continue;
                    }
                    else
                    {
                         voicesToBeDeleted.Add(voice.Id);
                    }
                }
            }

            refreshApplyButton();
        }

        private void CheckStateChanged(object sender, EventArgs e)
        {
            syncVoiceSelections(pollyTreeView.Root);
        }

        private void RefreshVersions()
        {
            var softwareManager = new SoftwareManager();
            latestVersionLabel.Text = "Checking . . . ";
            installedVersionLabel.Text = "Checking . . . ";
            string siteVersion;

            var installFile = softwareManager.DownloadSoftware("https://s3.amazonaws.com/aws-cli/AWSCLI64.msi");
            try
            {
                siteVersion = softwareManager.GetMsiProperty(installFile, "ProductVersion").Replace(":", ".");
            }
            finally
            {
                File.Delete(installFile);
            }

            var installedVersion = softwareManager.GetInstalledSoftwareProperty("AWS Command Line Interface", "DisplayVersion");
            latestVersionLabel.Text = siteVersion; 
            installedVersionLabel.Text = string.IsNullOrEmpty(installedVersion) ? "Not installed" : installedVersion;
            installButton.Enabled = false;
            if (string.IsNullOrEmpty(installedVersion))
            {
                installButton.Enabled = true;
                installButton.Text = "Install";
                uninstallButton.Enabled = false;
            }
            else if (new Version(siteVersion) > new Version(installedVersion))
            {
                installButton.Enabled = true;
                installButton.Text = "Upgrade";
                uninstallButton.Enabled = false;
            }
            else if (new Version(siteVersion) == new Version(installedVersion))
            {
                installButton.Text = "Upgrade";
                installButton.Enabled = false;
                uninstallButton.Enabled = false;
            }

            lastCheckedLabel.Text = $@"Last checked: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")}";
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            var softwareManager = new SoftwareManager();
            if (softwareManager.IsSoftwareInstalled("AWS Command Line Interface"))
            {
                UninstallSoftware("AWS Command Line Interface");
            }

            var installPath = softwareManager.DownloadSoftware("https://s3.amazonaws.com/aws-cli/AWSCLI64.msi");
            try
            {
                softwareManager.InstallSoftware(installPath);
            }
            finally
            {
                File.Delete(installPath);
            }
            RefreshVersions();
        }

        public void UninstallSoftware(string displayName)
        {
            var softwareManager = new SoftwareManager();
            if (softwareManager.IsSoftwareInstalled("AWS Command Line Interface"))
            {
                softwareManager.UninstallSoftware("AWS Command Line Interface");
            }
            RefreshVersions();
        }

        private void uninstallButton_Click(object sender, EventArgs e)
        {
            UninstallSoftware("AWS Command Line Interface");
        }

        private async Task<SynthesizeSpeechResponse> SynthesizeSpeech()
        {
            var client = new AmazonPollyClient(RegionEndpoint.USEast1);

            var synthesizeSpeechRequest = new SynthesizeSpeechRequest();
            synthesizeSpeechRequest.VoiceId = _selectedVoice.Id;
            synthesizeSpeechRequest.TextType = TextType.Text;
            synthesizeSpeechRequest.Text = previewText.Text;
            synthesizeSpeechRequest.OutputFormat = OutputFormat.Pcm;
            synthesizeSpeechRequest.SampleRate = "16000";
            var response = client.SynthesizeSpeechAsync(synthesizeSpeechRequest);
            return response.Result;
        }

        private void playSampleButton_Click(object sender, EventArgs e)
        {
            playSampleButton.Enabled = false;
            var response = SynthesizeSpeech().Result;

            using (var ms = new MemoryStream())
            {
                response.AudioStream.CopyTo(ms);
                byte[] buf = ms.GetBuffer();
                var source = new BufferedWaveProvider(new WaveFormat(16000, 16, 1)) {ReadFully = false};
                source.AddSamples(buf, 0, buf.Length);
                using (var waveOut = new WaveOutEvent())
                {
                    waveOut.Init(source);
                    var stopped = new AutoResetEvent(false);
                    waveOut.Play();
                    while (waveOut.PlaybackState == PlaybackState.Playing)

                        Thread.Sleep(100);
                }
            }

            playSampleButton.Enabled = true;
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pollyTreeView_Click(object sender, EventArgs e)
        {
            var validSelection = false;
            var selectedNode = ((TreeViewAdv) sender).SelectedNode;
            if (selectedNode != null && 
                selectedNode.Nodes != null &&
                selectedNode.Nodes.Count == 0)
            {
                validSelection = true;
            }
            if (validSelection)
            {
                _selectedVoice = (Voice)selectedNode.Tag;
                _selectedNode = selectedNode;
                previewText.Enabled = true;
                playSampleButton.Enabled = true;
                selectedVoiceLabel.Text = 
                    $"{_selectedVoice.Name}, {_selectedVoice.LanguageName} ({_selectedVoice.Gender})";
                toggleVoiceButton.Enabled = true;
                refreshToggleVoiceButton();
            }
            else
            {
                _selectedVoice = null;
                previewText.Enabled = false;
                playSampleButton.Enabled = false;
                toggleVoiceButton.Enabled = false;
                selectedVoiceLabel.Text = "None";
                toggleVoiceButton.Text = "Show";
            }

            if (_selectedNode == null) { return; }

            refreshApplyButton();
        }

        private void toggleVoiceButton_Click(object sender, EventArgs e)
        {
            var voiceManager = new VoiceManager(ClsId);
            if (toggleVoiceButton.Text == "Show")
            {
                if (voicesToBeDeleted.Contains(_selectedVoice.Id))
                {
                    voicesToBeDeleted.Remove(_selectedVoice.Id);
                }

                if (!voiceManager.IsVoiceInstalled(_selectedVoice))
                {
                    voicesToBeAdded.Add(_selectedVoice.Id);
                }
                _selectedNode.Checked = true;
            }
                else
            {
                if (voicesToBeAdded.Contains(_selectedVoice.Id))
                {
                    voicesToBeAdded.Remove(_selectedVoice.Id);
                }

                if (voiceManager.IsVoiceInstalled(_selectedVoice))
                {
                    voicesToBeDeleted.Add(_selectedVoice.Id);
                }

                _selectedNode.Checked = false;
            }

            refreshToggleVoiceButton();
            refreshApplyButton();
        }

        private void refreshToggleVoiceButton()
        {
            if (_selectedVoice == null) return;
            var voiceManager = new VoiceManager(ClsId);
            if (voiceManager.IsVoiceInstalled(_selectedVoice) && !voicesToBeDeleted.Contains(_selectedVoice.Id))
            {
                toggleVoiceButton.Text = @"Hide";
            }
            else
            {
                toggleVoiceButton.Text = @"Show";
            }
        }

        private void refreshApplyButton()
        {
            var totalChanges = voicesToBeDeleted.Count + voicesToBeAdded.Count;
            applyChangesButton.Enabled = totalChanges > 0;
            if (totalChanges > 0)
            {
                applyChangesButton.Text = $"Apply Changes (# of Changes: {totalChanges})";
                resetSelectionsButton.Enabled = true;
            }
            else
            {
                applyChangesButton.Text = "No changes";
                applyChangesButton.Enabled = false;
                resetSelectionsButton.Enabled = false;
            }
        }

        private void addAllVoicesButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNodeAdv node in pollyTreeView.Root.Nodes)
            {
                node.Checked = true;
                node.CheckState = CheckState.Checked;
            }
        }

        private void applyChangesButton_Click(object sender, EventArgs e)
        {
            var voiceManager = new VoiceManager(ClsId);
            foreach (var voice in voicesToBeAdded)
            {
                voiceManager.AddVoice(allVoices.FirstOrDefault(v=>v.Id == voice));
                installedVoices.Add(voice);
            }

            foreach (var voice in voicesToBeDeleted)
            {
                voiceManager.DeleteVoice(allVoices.FirstOrDefault(v => v.Id == voice));
                if (installedVoices.Contains(voice))
                {
                    installedVoices.Remove(voice);
                }
            }

            voicesToBeAdded.Clear();
            voicesToBeDeleted.Clear();
            syncVoiceSelections(pollyTreeView.Root);
            refreshApplyButton();
        }

        private void resetSelectionsButton_Click(object sender, EventArgs e)
        {
            resetSelections(pollyTreeView.Root);
        }

        private void resetSelections(TreeNodeAdv currentNode)
        {
            foreach (TreeNodeAdv node in currentNode.Nodes)
            {
                var voice = (Voice) node.Tag;
                if (voice != null)
                {
                    if (node.Checked == false && installedVoices.Contains(voice.Id))
                    {
                        node.Checked = true;
                    }

                    if (node.Checked == true && !installedVoices.Contains(voice.Id))
                    {
                        node.Checked = false;
                    }
                }
                resetSelections(node);
            }
            refreshToggleVoiceButton();
            refreshApplyButton();
        }

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNodeAdv node in pollyTreeView.Root.Nodes)
            {
                node.Checked = false;
            }
            refreshToggleVoiceButton();
            refreshApplyButton();
        }
    }
}
