using System;
using System.Collections.Generic;
using AwsConfigurator.Configuration;
using AwsConfigurator.Model;
using Xunit;

namespace AwsConfigurationUnitTests
{
    public class ConfigManagerUnitTests
    {
        [Fact]
        public void UpsertingProfileThatDoesNotExistCreatesNewProfile()
        {
            var cm = new ConfigManager();
            var value = "abcde";
            cm.UpsertKey("test", ConfigKey.AwsAccessKeyId, value, ConfigSource.Environment);
            var cp = cm.GetProfile("test");
            Assert.Equal(value, cp.Items[ConfigKey.AwsAccessKeyId].Value);
        }

        [Fact]
        public void UpsertingExistingProfileKeyUpdatesKey()
        {
            var cm = new ConfigManager();
            var value1 = "abcde";
            var value2 = "fghij";
            cm.UpsertKey("test", ConfigKey.AwsAccessKeyId, value1, ConfigSource.Environment);
            cm.UpsertKey("test", ConfigKey.AwsAccessKeyId, value2, ConfigSource.Environment);
            var cp = cm.GetProfile("test");
            Assert.Equal(value2, cp.Items[ConfigKey.AwsAccessKeyId].Value);
        }
        [Fact]
        public void UpsertingAnInvalidKeyThrowsException()
        {
            var cm = new ConfigManager();
            var value = "abcde";
            var ex = Assert.Throws<ArgumentException>(() =>
                cm.UpsertKey("test", "bad_key", value, ConfigSource.Environment));
        }

        [Fact]
        public void CanUpsertAwsAccessKeyId()
        {
            var cm = new ConfigManager();
            var value = "abcde";
            var profile = "test";
            cm.UpsertKey(profile, ConfigKey.AwsAccessKeyId, value, ConfigSource.Environment);
            var cp = cm.GetProfile(profile);
            Assert.Equal(value, cp.Items[ConfigKey.AwsAccessKeyId].Value);
        }

        [Fact]
        public void CanUpsertAwsSecretAccessKey()
        {
            var cm = new ConfigManager();
            var value = "abcde";
            var profile = "test";
            cm.UpsertKey(profile, ConfigKey.AwsSecretAccessKey, value, ConfigSource.Environment);
            var cp = cm.GetProfile(profile);
            Assert.Equal(value, cp.Items[ConfigKey.AwsSecretAccessKey].Value);
        }

        [Fact]
        public void CanUpsertAwsSessionToken()
        {
            var cm = new ConfigManager();
            var value = "abcde";
            var profile = "test";
            cm.UpsertKey(profile, ConfigKey.AwsSessionToken, value, ConfigSource.Environment);
            var cp = cm.GetProfile(profile);
            Assert.Equal(value, cp.Items[ConfigKey.AwsSessionToken].Value);
        }

        [Fact]
        public void CanUpsertRegion()
        {
            var cm = new ConfigManager();
            var value = "abcde";
            var profile = "test";
            cm.UpsertKey(profile, ConfigKey.Region, value, ConfigSource.Environment);
            var cp = cm.GetProfile(profile);
            Assert.Equal(value, cp.Items[ConfigKey.Region].Value);
        }

        [Fact]
        public void CanUpsertOutput()
        {
            var cm = new ConfigManager();
            var value = "abcde";
            var profile = "test";
            cm.UpsertKey(profile, ConfigKey.Output, value, ConfigSource.Environment);
            var cp = cm.GetProfile(profile);
            Assert.Equal(value, cp.Items[ConfigKey.Output].Value);
        }

        [Fact]
        public void CanPassInProfileList()
        {
            var profileListUT = new List<CredentialProfile>()
            {
                new CredentialProfile()
                {
                    ProfileName = "test",
                    Items = new Dictionary<string, CredentialItem>
                    {
                        {
                            ConfigKey.AwsAccessKeyId,
                            new CredentialItem()
                            {
                                Source = ConfigSource.ConfigFile,
                                Value = "accesskey"
                            }
                        }
                    }
                }
            };
            var cm = new ConfigManager(profileListUT);
            Assert.NotNull(cm.GetProfile("test"));
        }
    }
}
