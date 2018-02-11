using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;
using SystemInterface.IO;
using AwsConfigurator.Configuration;
using AwsConfigurator.Interfaces;
using AwsConfigurator.Model;
using IniParser;
using IniParser.Parser;

namespace AwsConfigurator.DataManagers
{
    public class ConfigFileDataManager : IFileDataManager
    {
        private IFileSystem _fileSystem;
        private ConfigSource _configSource;
        private const string ProfilePrefix = "profile ";

        public ConfigFileDataManager(IFileSystem fileSystem, ConfigSource configSource)
        {
            _fileSystem = fileSystem;
            _configSource = configSource;
        }
        public List<CredentialProfile> Load(string path)
        {
            var fileContents = _fileSystem.File.ReadAllText(path);
            var configManager = new ConfigManager();
            var stringIniParser = new IniDataParser();
            var  iniData = stringIniParser.Parse(fileContents);
            foreach (var section in iniData.Sections)
            {
                var profileName = _configSource == ConfigSource.ConfigFile && section.SectionName.StartsWith(ProfilePrefix)
                    ? section.SectionName.Remove(0, ProfilePrefix.Length)
                    : section.SectionName;
                foreach (var key in section.Keys)
                {
                    configManager.UpsertKey(profileName, key.KeyName, key.Value, _configSource);
                }
            }

            return configManager.CredentialProfiles;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
