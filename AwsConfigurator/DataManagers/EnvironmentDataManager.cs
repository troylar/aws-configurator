using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Interfaces;

namespace AwsConfigurator.DataManagers
{
    public class EnvironmentDataManager : IEnvironmentDataManager
    {
        IEnvironmentManager _environmentManager;
        public EnvironmentDataManager(IEnvironmentManager environmentManager)
        {
            _environmentManager = environmentManager;
        }
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
