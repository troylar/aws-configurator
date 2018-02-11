using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Text;
using AwsConfigurator.Interfaces;
using Microsoft.Win32;
using WindowsInstaller;
using Microsoft.Deployment.WindowsInstaller;
using static Microsoft.Deployment.WindowsInstaller.Installer;

namespace AwsConfigurator.Installer
{
    public class SoftwareManager : ISoftwareManager
    {
        private RegistryKey GetInstalledSoftwareKey(string displayName)
        {
            const string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (var key = baseKey.OpenSubKey(uninstallKey))
                {
                    if (key == null)
                    {
                        return null;
                    }

                    foreach (var subkeyName in key.GetSubKeyNames())
                    {
                        var subKey = key.OpenSubKey(subkeyName);
                        var name = subKey.GetValue("DisplayName");
                        if (name != null && displayName.Equals(name))
                        {
                            return subKey;
                        }
                    }
                }
            }
            return null;
        }
        public string  GetInstalledSoftwareProperty(string displayName, string property)
        {
            var installedSoftwareKey = GetInstalledSoftwareKey(displayName);
            if (installedSoftwareKey == null) return string.Empty;
            return installedSoftwareKey.GetValue(property) == null
                ? string.Empty
                : (string) installedSoftwareKey.GetValue(property);
        }

        public bool IsSoftwareValid(string name, Func<bool> validate)
        {
            throw new NotImplementedException();
        }

        public bool UninstallSoftware(string displayName)
        {
            var uninstallString = GetInstalledSoftwareProperty(displayName, "UninstallString");

            var exec = uninstallString.Split(' ');

            var p = new Process();
            p.StartInfo.FileName = exec[0];
            //The argument that you want to give
            if (exec.Length > 1)
            {
                var noUi = exec[1].Replace("/I", "/x");
                p.StartInfo.Arguments = $"{noUi} /qb";
            }
            p.Start();
            p.WaitForExit();
            return true;
        }

        public bool InstallSoftware(string installPath)
        {
            SetInternalUI(InstallUIOptions.ProgressOnly);
            InstallProduct(installPath, "ACTION=INSTALL");
            return true;
        }
        public string DownloadSoftware(string url)
        {
            var downloadPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString()}.msi");
            using (var client = new WebClient())
            {
                client.DownloadFile(url, downloadPath);
            }
            return downloadPath;
        }

        public string GetMsiProperty(string msiFile, string property)
        {
            string retVal = string.Empty;

            // Create an Installer instance
            var classType = Type.GetTypeFromProgID("WindowsInstaller.Installer");
            var installerObj = Activator.CreateInstance(classType);
            var installer = installerObj as WindowsInstaller.Installer;

            // Open the msi file for reading
            // 0 - Read, 1 - Read/Write
            var database = installer.OpenDatabase(msiFile, 0);
                // Fetch the requested property
            var sql = $"SELECT Value FROM Property WHERE Property ='{property}'";
            var view = database.OpenView(sql);
            try
            {
                view.Execute(null);

                // Read in the fetched record
                var record = view.Fetch();
                if (record != null)
                    retVal = record.StringData[1];

            }
            finally
            {
                if (view != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(view);
                    view = null;
                }
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(database);
                database = null;
                GC.Collect();
            }
            return retVal;
        }

        public bool IsSoftwareInstalled(string displayName)
        {
            var key = GetInstalledSoftwareKey(displayName);
            return key != null;
        }
    }
}
