using System;
using System.Collections.Generic;
using System.Text;
using Amazon.Polly.Model;

namespace AwsConfigurator.Interfaces
{
    public interface IVoiceManager
    {
        void AddVoice(Voice voice);
        void DeleteVoice(Voice voice);
        string ClsId { get; set; }
        bool IsVoiceInstalled(Voice voice);
    }
}
