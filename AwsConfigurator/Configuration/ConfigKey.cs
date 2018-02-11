using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AwsConfigurator.Configuration
{
    public static class ConfigKey
    {
        public static string AwsAccessKeyId = "aws_access_key_id";
        public static string AwsSecretAccessKey = "aws_secret_access_key";
        public static string AwsSessionToken = "aws_session_token";
        public static string Region = "region";
        public static string Output = "output";
        public static string TookitArtifactGuid = "toolkit_artifact_guid";

        public static bool IsValid(string key)
        {
            return typeof(ConfigKey)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string))
                .Any(f => (string)f.GetValue(null) == key);
        }
    }
}
