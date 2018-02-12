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
            Task.Run(UpdateApp);
            Application.Run(new mainForm());
        }

        static async Task UpdateApp()
        {
            var githubRepo = System.Configuration.ConfigurationManager.AppSettings["GithubRepo"];
            using (var mgr = UpdateManager.GitHubUpdateManager(githubRepo))
            {
                await mgr.Result.UpdateApp();
            }
        }
    }
}
