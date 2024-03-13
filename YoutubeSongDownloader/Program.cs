using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;
using YoutubeSongDownloader.Data.Config;

namespace YoutubeSongDownloader
{
    internal static class Program
    {
        private static string configFilePath = "./config.json";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateConfigFileIfItDoesntExist();
            ProgramConfig configToInit = ReadConfigFile();
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
        //TODO: refactor into config utility class (changing config in other classes)
        private static void CreateConfigFileIfItDoesntExist()
        {
            if(!File.Exists(configFilePath))
            {
                using (StreamWriter writer = File.CreateText(configFilePath))
                {
                    ProgramConfig defaultConfig = new ProgramConfig(KnownFolders.GetPath(KnownFolder.Downloads));
                    string json = JsonConvert.SerializeObject(defaultConfig);
                    writer.Write(json);
                }
            }
        }
        private static ProgramConfig ReadConfigFile()
        {
            string json = File.ReadAllText(configFilePath);
            ProgramConfig savedConfig = JsonConvert.DeserializeObject<ProgramConfig>(json);
            return savedConfig;
        }
    }
}