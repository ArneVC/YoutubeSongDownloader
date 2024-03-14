using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;
using YoutubeSongDownloader.Data.Config;

namespace YoutubeSongDownloader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigManager.CreateConfigFileIfItDoesntExist();
            ProgramConfig configToInit = ConfigManager.ReadConfigFile();
            if(configToInit != null)
            {
                Debug.WriteLine(configToInit.ToString());
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1(configToInit));
            }
            else
            {
                MessageBox.Show("Config file error!\nPlease fix or delete config file");
            }
        }
    }
}