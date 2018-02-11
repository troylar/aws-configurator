using System;
using System.Collections.Generic;
using System.Text;
// ReSharper disable InconsistentNaming

namespace AwsConfigurator.Configuration
{
    public enum EnvironmentVariables
    {
        AWS_CONFIG_FILE,
        AWS_SECRET_ACCESS_KEY,
        AWS_ACCESS_KEY_ID,
        AWS_SESSION_TOKEN,
        AWS_DEFAULT_REGION,
        AWS_DEFAULT_OUTPUT,
        AWS_PROFILE,
        AWS_CA_BUNDLE,
        AWS_SHARED_CREDENTIALS_FILE
    }
}
