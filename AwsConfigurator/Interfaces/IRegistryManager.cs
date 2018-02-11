using System;
using System.Collections.Generic;
using System.Text;

namespace AwsConfigurator.Interfaces
{
    public interface IRegistryManager
    {
        void SetRegistryKeyString(string key, string name, string value);
        void DeleteRegistryKeyName(string key, string name);
        bool DoesKeyExist(string key);
        void CreateSubkey(string key, string subkey);
    }
}
