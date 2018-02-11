using System;
using System.Collections.Generic;
using System.Text;
using AwsConfigurator.Configuration;
using AwsConfigurator.DataManagers;
using AwsConfigurator.Interfaces;
using Moq;
using Xunit;

namespace AwsConfigurationUnitTests
{
    public class EnvironmentDataManagerUnitTests
    {
        [Fact]
        public void CanReadAllEnvironmentVariables()
        {
            var keyId = "MyKeyId";
            var profileId = "MyProfile";
            var environmentManagerMock = new Mock<IEnvironmentManager>();
            environmentManagerMock.Setup(em => em.GetValue(EnvironmentVariables.AWS_ACCESS_KEY_ID)).Returns(keyId);
            var environmentDataManager = new EnvironmentDataManager(environmentManagerMock.Object);
        }

    }
}
