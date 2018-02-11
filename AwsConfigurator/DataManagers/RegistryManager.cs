using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Interfaces;
using Microsoft.Win32;

namespace AwsConfigurator.DataManagers
{
    public class RegistryManager : IRegistryManager
    {
        private RegistryKey GetSubKey(string key)
        {
            var rootKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var subKey = rootKey.OpenSubKey(key, true);
            return subKey;
        }
        public void SetRegistryKeyString(string key, string name, string value)
        {
            var subKey = GetSubKey(key);
            try
            {
                subKey.SetValue(name, value, RegistryValueKind.String);
            }
            finally
            {
                subKey.Close();
            }
        }

        public bool DoesKeyExist(string key)
        {
            var rootKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey subKey;
            try
            {
                subKey = rootKey.OpenSubKey(key, true);
            }
            finally
            {
                rootKey.Close();
            }

            return subKey != null;
        }

        public void CreateSubkey(string baseKey, string subKey)
        {
            var rootKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var key = rootKey.OpenSubKey(baseKey, true);
            key.CreateSubKey(subKey);
            key.Close();
            rootKey.Close();
        }

        public void DeleteRegistryKeyName(string key, string name)
        {
            var subKey = GetSubKey(key);
            try
            {
                if (DoesKeyExist($"{key}\\{name}"))
                {
                    subKey.DeleteSubKey(name);
                }
            }
            finally
            {
                subKey.Close();
            }
        }
    }
}
