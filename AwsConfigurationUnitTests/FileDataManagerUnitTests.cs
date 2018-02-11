using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using AwsConfigurator.Configuration;
using AwsConfigurator.DataManagers;
using AwsConfigurator.Interfaces;
using Moq;
using Xunit;
using AwsConfigurator.Extensions;

namespace AwsConfigurationUnitTests
{
    public class FileDataManagerUnitTests
    {
        private string _goodFile = @"
            [default]
            region = us-east-1
            output = json
            [profile test_profile]
            output = xml
            region = eu-west-1
        "; 

        private string _goodCredentialsFile = @"
            [default]
            aws_access_key_id = my_access_key_id
            aws_secret_access_key = my_secret_access_key
            aws_session_token = my_session_token
            [test_profile]
            aws_access_key_id = my_test_access_key_id
            aws_secret_access_key = my_test_secret_access_key
            aws_session_token = my_test_session_token
            toolkit_artifact_guid = e897c3a2-4ff0-47ec-8a15-d9b99796e190
        ";

        [Fact]
        public void CanReadProfileNamesFromConfigFile()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(_goodFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.ConfigFile);
            var credentialProfileList = configDataManager.Load("test");
            Assert.Equal(2, credentialProfileList.Count);
            Assert.True(credentialProfileList.Count(cp => cp.ProfileName.Equals("default")) == 1 &&
                credentialProfileList.Count(cp => cp.ProfileName.Equals("test_profile"))==1);
        }

        [Fact]
        public void CanReadOutputFromConfigFile()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(_goodFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.ConfigFile);
            var credentialProfileList = configDataManager.Load("test");
            var defaultProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "default");
            var testProfileProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "test_profile");
            Assert.True(defaultProfile.Items[ConfigKey.Output].Value == "json");
            Assert.True(testProfileProfile .Items[ConfigKey.Output].Value == "xml");
        }

        [Fact]
        public void CanReadRegionFromConfigFile()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(_goodFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.ConfigFile);
            var credentialProfileList = configDataManager.Load("test");
            var defaultProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "default");
            var testProfileProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "test_profile");
            Assert.True(defaultProfile.Items[ConfigKey.Region].Value == "us-east-1");
            Assert.True(testProfileProfile.Items[ConfigKey.Region].Value == "eu-west-1");
        }

        [Fact]
        public void CanReadAwsAccessKeyFromFile()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(_goodCredentialsFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.ConfigFile);
            var credentialProfileList = configDataManager.Load("test");
            var defaultProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "default");
            var testProfileProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "test_profile");
            Assert.True(defaultProfile.Items[ConfigKey.AwsAccessKeyId].Value == "my_access_key_id");
            Assert.True(testProfileProfile.Items[ConfigKey.AwsAccessKeyId].Value == "my_test_access_key_id");
        }

        [Fact]
        public void CanReadAwsSessionTokenFromFile()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(_goodCredentialsFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.CredentialsFile);
            var credentialProfileList = configDataManager.Load("test");
            var defaultProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "default");
            var testProfileProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "test_profile");
            Assert.True(defaultProfile.Items[ConfigKey.AwsSessionToken].Value == "my_session_token");
            Assert.True(testProfileProfile.Items[ConfigKey.AwsSessionToken].Value == "my_test_session_token");
        }

        [Fact]
        public void CanReadToolkitArtifactGuidFromFile()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(_goodCredentialsFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.ConfigFile);
            var credentialProfileList = configDataManager.Load("test");
            var testProfileProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "test_profile");
            Assert.True(testProfileProfile.Items[ConfigKey.TookitArtifactGuid].Value == "e897c3a2-4ff0-47ec-8a15-d9b99796e190");
        }

        [Fact]
        public void CanReadAwsSecretKeyFromFile()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(_goodCredentialsFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.ConfigFile);
            var credentialProfileList = configDataManager.Load("test");
            var defaultProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "default");
            var testProfileProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "test_profile");
            Assert.True(defaultProfile.Items[ConfigKey.AwsSecretAccessKey].Value == "my_secret_access_key");
            Assert.True(testProfileProfile.Items[ConfigKey.AwsSecretAccessKey].Value == "my_test_secret_access_key");
        }

        [Fact]
        public void ReadingFromConfigFileSetsCorrectSource()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText(It.IsAny<string>()))
                .Returns(_goodCredentialsFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.CredentialsFile);
            var credentialProfileList = configDataManager.Load("test");
            var defaultProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "default");
            var testProfileProfile = credentialProfileList.FirstOrDefault(cp => cp.ProfileName == "test_profile");
            Assert.True(defaultProfile.Items[ConfigKey.AwsSessionToken].Source == ConfigSource.CredentialsFile);
        }

        [Fact]
        public void CanMergeCredentialxProfileLists()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.File.ReadAllText("credentials"))
                .Returns(_goodCredentialsFile);
            fileSystemMock.Setup(fs => fs.File.ReadAllText("config"))
                .Returns(_goodFile);
            var configDataManager = new ConfigFileDataManager(fileSystemMock.Object,
                ConfigSource.CredentialsFile);
            var credentialProfileList = configDataManager.Load("credentials");
            var configProfileList = configDataManager.Load("config");
            configProfileList.Merge(credentialProfileList);
            var defaultProfile = configProfileList.FirstOrDefault(cp => cp.ProfileName == "default");
            Assert.True(defaultProfile.Items[ConfigKey.Region].Value == "us-east-1" && 
                        defaultProfile.Items[ConfigKey.AwsAccessKeyId].Value == "my_access_key_id");
        }
    }
}