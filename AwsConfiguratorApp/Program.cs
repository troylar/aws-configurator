using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            using (var mgr = UpdateManager.GitHubUpdateManager(githubRepo))
            {
                try
                {
                    Debugger.Break();
                    var updates = await mgr.Result.CheckForUpdate();
                    if (updates.ReleasesToApply.Any())
                    {
                        var lastVersion = updates.ReleasesToApply.OrderBy(x => x.Version).Last();
                        await mgr.Result.DownloadReleases(new[] { lastVersion });
                        await mgr.Result.ApplyReleases(updates);
                        await mgr.Result.UpdateApp();
                        restartNeeded = true;
                        MessageBox.Show(Resources.Resources.ApplicationHasUpdated);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            if (restartNeeded)
            {
                UpdateManager.RestartApp();
            }
        }
    }
}
