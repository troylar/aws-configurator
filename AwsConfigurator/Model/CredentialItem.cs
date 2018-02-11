using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Configuration;

namespace AwsConfigurator.Model
{
    public class CredentialItem
    {
        public string Value { get; set; }
        public ConfigSource Source { get; set; }
    }
}
