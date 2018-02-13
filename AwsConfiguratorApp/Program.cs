using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuGet;
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
            Update();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }

        private static void Update()
        {
            SemanticVersion newVersion = null;
            var updated = false;
            var githubRepo = System.Configuration.ConfigurationManager.AppSettings["GithubRepo"];
            using (var mgr = UpdateManager.GitHubUpdateManager(githubRepo).Result)
            {
                var updateInfo = mgr.CheckForUpdate().Result;

                var currentVersion = updateInfo.CurrentlyInstalledVersion.Version;

                if (updateInfo.ReleasesToApply.Any())
                {
                    newVersion = updateInfo.FutureReleaseEntry.Version;
                    mgr.DownloadReleases(updateInfo.ReleasesToApply).Wait();
                    mgr.ApplyReleases(updateInfo).Wait();
                    mgr.CreateUninstallerRegistryEntry().Wait();
                    updated = true;
                }
            }

            if (!updated || newVersion == null) return;
            MessageBox.Show("Restarting . . . ");
            UpdateManager.RestartApp();
        }
    }
}
