using System;
using System.Collections.Generic;
using System.Text;

namespace AwsConfigurator.Interfaces
{
    public interface ISoftwareManager
    {
        string GetInstalledSoftwareProperty(string displayName, string property);
        bool IsSoftwareValid(string name, Func<bool> validate);
        bool InstallSoftware(string Url);
        bool UninstallSoftware(string displayName);
        string GetMsiProperty(string msiFile, string property);
        bool IsSoftwareInstalled(string name);
        string DownloadSoftware(string uri);
    }
}
