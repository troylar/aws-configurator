using System;
using System.Collections.Generic;
using System.Text;
using Amazon.Polly.Model;
using AwsConfigurator.Interfaces;
using AwsConfigurator.Extensions;

namespace AwsConfigurator.DataManagers
{
    public class VoiceManager : IVoiceManager
    {
        private const string VoiceKey = "SOFTWARE\\Microsoft\\Speech\\Voices\\Tokens";
        public string ClsId { get; set; }
        public bool IsVoiceInstalled(Voice voice)
        {
            var registryManager = new RegistryManager();
            var key = $@"{VoiceKey}\{voice.TokenKeyName()}";
            return registryManager.DoesKeyExist(key);
        }

        public VoiceManager(string clsId)
        {
            ClsId = clsId;
        }

        public void AddVoice(Voice voice)
        {
            var registryManager = new RegistryManager();
            var tokensKey = $@"{VoiceKey}";
            var voiceKey = $@"{tokensKey}\{voice.TokenKeyName()}";
            var attributesKey = $@"{tokensKey}\{voice.TokenKeyName()}\\Attributes";
            if (!registryManager.DoesKeyExist(voiceKey))
            {
                registryManager.CreateSubkey(tokensKey, voice.TokenKeyName());
            }
            registryManager.SetRegistryKeyString(voiceKey, voice.LCID(), voice.NameAndLanguage());
            registryManager.SetRegistryKeyString(voiceKey, "CLSID", "{" + ClsId + "}");
            registryManager.SetRegistryKeyString(voiceKey, string.Empty, voice.NameAndLanguage());
            if (!registryManager.DoesKeyExist(attributesKey))
            {
                registryManager.CreateSubkey(voiceKey, "Attributes");
            }
            registryManager.SetRegistryKeyString(attributesKey, "Gender", voice.Gender);
            registryManager.SetRegistryKeyString(attributesKey, "Vendor", "Amazon");
            registryManager.SetRegistryKeyString(attributesKey, "VoiceId", voice.Id);
            registryManager.SetRegistryKeyString(attributesKey, "Name", $"Amazon Polly {voice.Id}");
            registryManager.SetRegistryKeyString(attributesKey, "Language", voice.LCIDInHex());
        }

        public void DeleteVoice(Voice voice)
        {
            var registryManager = new RegistryManager();
            var tokensKey = $@"{VoiceKey}";
            var voiceKey = $@"{tokensKey}\{voice.TokenKeyName()}";
            var attributesKey = $@"{tokensKey}\{voice.TokenKeyName()}\\Attributes";
            registryManager.DeleteRegistryKeyName(voiceKey, "Attributes");
            registryManager.DeleteRegistryKeyName(tokensKey, voice.TokenKeyName());
        }
    }
}
