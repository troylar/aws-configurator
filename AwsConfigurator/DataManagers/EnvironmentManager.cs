using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Configuration;
using AwsConfigurator.Interfaces;

namespace AwsConfigurator.DataManagers
{
    public class EnvironmentManager : IEnvironmentManager
    {
        public string GetValue(EnvironmentVariables variable)
        {
            return Environment.GetEnvironmentVariable(variable.ToString());
        }
    }
}
