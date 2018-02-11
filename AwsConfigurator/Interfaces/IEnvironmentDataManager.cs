using System;
using System.Collections.Generic;
using System.Text;

namespace AwsConfigurator.Interfaces
{
    public interface IEnvironmentDataManager
    {
        void Load();
        void Save();
    }
}
