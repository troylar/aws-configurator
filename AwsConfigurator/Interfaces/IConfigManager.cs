using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Configuration;
using AwsConfigurator.Model;

namespace AwsConfigurator.Interfaces
{
    public interface IConfigManager
    {
        void Validate(string profileName, Func<bool> validate);
        void DeleteKey(string profileName, string key);
        void UpsertKey(string profileName, string key, string value, ConfigSource configurationSource);
        void Copy(string profileName, string newProfileName);
        void Delete(string profileName);
        CredentialProfile GetProfile(string profileName);
    }
}
