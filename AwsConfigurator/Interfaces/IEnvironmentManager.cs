using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Configuration;

namespace AwsConfigurator.Interfaces
{
    public interface IEnvironmentManager
    {
        string GetValue(EnvironmentVariables variable);
    }
}
