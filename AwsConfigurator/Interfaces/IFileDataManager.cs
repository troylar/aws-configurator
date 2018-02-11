using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Model;

namespace AwsConfigurator.Interfaces
{
    public interface IFileDataManager
    {
        List<CredentialProfile> Load(string path);
        void Save();
    }
}
