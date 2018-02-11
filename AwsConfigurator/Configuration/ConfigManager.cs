using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwsConfigurator.Interfaces;
using AwsConfigurator.Model;

namespace AwsConfigurator.Configuration
{
    public class ConfigManager : IConfigManager
    {
        private List<CredentialProfile> _credentialProfileList;

        public ConfigManager(List<CredentialProfile> credentialProfileList = null)
        {
            if (credentialProfileList != null)
            {
                _credentialProfileList = credentialProfileList;
            }
            else
            {
                _credentialProfileList = new List<CredentialProfile>();
            }
        }

        public void Validate(string profileName, Func<bool> validate)
        {
            throw new NotImplementedException();
        }

        public void DeleteKey(string profileName, string key)
        {

        }

        public List<CredentialProfile> CredentialProfiles
        {
            get { return _credentialProfileList; }
        }

        public void UpsertKey(string profileName, string key, string value, ConfigSource configSource)
        {
            if (!ConfigKey.IsValid(key))
            {
                throw new ArgumentException($"Not a valid credential key: {key}");
            }
            var credentialProfile = _credentialProfileList.FirstOrDefault(cp => cp.ProfileName.Equals(profileName));
            if (credentialProfile == null)
            {
                credentialProfile = new CredentialProfile() {ProfileName = profileName};
                _credentialProfileList.Add(credentialProfile);
            }
            credentialProfile.Items[key] = new CredentialItem
            {
                Source = configSource,
                Value = value
            };
        }

        public void Copy(string profileName, string newProfileName)
        {
            throw new NotImplementedException();
        }

        public void Delete(string profileName)
        {
            throw new NotImplementedException();
        }

        public CredentialProfile GetProfile(string profileName)
        {
            return _credentialProfileList.FirstOrDefault(cp => cp.ProfileName.Equals(profileName));
        }
    }
}
