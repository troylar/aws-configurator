using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Amazon.Polly.Model;
using AwsConfigurator.Model;

namespace AwsConfigurator.Extensions
{
    public static class ExtensionMethods
    {
        public static List<CredentialProfile> Merge(this List<CredentialProfile> value, List<CredentialProfile> listToMerge)
        {
            foreach (var credentialProfile in listToMerge)
            {
                if (value.Any(v => v.ProfileName == credentialProfile.ProfileName))
                {
                    var p = value.FirstOrDefault(v => v.ProfileName == credentialProfile.ProfileName);
                    foreach (var item in credentialProfile.Items)
                    {
                        p.Items[item.Key] = item.Value;
                    }
                }
            }

            return value;
        }

        public static string TokenKeyName(this Voice voice)
        {
            return $"TTS_AMZN_{voice.LanguageCode.Value.ToUpper()}_{voice.Name.ToUpper()}";
        }

        public static string LCID(this Voice voice)
        {
            var cultureInfo = new CultureInfo(voice.LanguageCode, false);
            return cultureInfo.LCID.ToString();
        }

        public static string LCIDInHex(this Voice voice)
        {
            return int.Parse(voice.LCID()).ToString("X");
        }

        public static string NameAndLanguage(this Voice voice)
        {
            return $"Amazon Polly {voice.Name} - {voice.LanguageName}";
        }
    }
}
