using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Squirrel;

namespace AwsConfiguratorApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
            UpdateApp().Wait();
        }

        static async Task UpdateApp()
        {
            using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/troylar/aws-configurator"))
            {
                await mgr.Result.UpdateApp();
            }
        }
    }
}
