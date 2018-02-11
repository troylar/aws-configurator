using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Configuration;

namespace AwsConfigurator.Model
{
    public class CredentialProfile
    {
        public CredentialProfile()
        {
            Items = new Dictionary<string, CredentialItem>();
        }
        public string ProfileName { get; set; }
        public Dictionary<string, CredentialItem> Items { get; set; }
    }
}
