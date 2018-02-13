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
            UpdateApp();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }

        public static async Task UpdateApp()
        {
            bool restartNeeded = false;
            var githubRepo = System.Configuration.ConfigurationManager.AppSettings["GithubRepo"];
            using (var mgr = UpdateManager.GitHubUpdateManager(githubRepo).Result)
            {
                var updates = await mgr.CheckForUpdate();
                if (updates.ReleasesToApply.Any())
                {
                    var lastVersion = updates.ReleasesToApply.OrderBy(x => x.Version).Last();
                    await mgr.DownloadReleases(new[] { lastVersion });
                    await mgr.ApplyReleases(updates);
                    await mgr.UpdateApp();
                    restartNeeded = true;
                    MessageBox.Show(Resources.Resources.ApplicationHasUpdated);
                }
                else
                {
                    MessageBox.Show("No Updates are available at this time.");
                }
            }
            if (restartNeeded)
            {
                UpdateManager.RestartApp();
            }
        }
    }
}
