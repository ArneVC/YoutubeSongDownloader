using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSongDownloader.Data.Config
{
    public static class ConfigManager
    {
        public static void CreateConfigFileIfItDoesntExist()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.ProgramConfig))
            {
                ProgramConfig defaultConfig = new ProgramConfig(KnownFolders.GetPath(KnownFolder.Downloads));
                string json = JsonConvert.SerializeObject(defaultConfig);
                Properties.Settings.Default.ProgramConfig = json; // Save JSON string to settings
                Properties.Settings.Default.Save();
            }
        }

        public static ProgramConfig ReadConfigFile()
        {
            CreateConfigFileIfItDoesntExist();
            string json = Properties.Settings.Default.ProgramConfig;
            return JsonConvert.DeserializeObject<ProgramConfig>(json);
        }

        public static void ChangeOutputFolder(string newFolderPath)
        {
            ProgramConfig currentConfig = ReadConfigFile();
            currentConfig.outputFolderPath = newFolderPath;
            string json = JsonConvert.SerializeObject(currentConfig);
            Properties.Settings.Default.ProgramConfig = json; // Update JSON string in settings
            Properties.Settings.Default.Save();
        }
    }
}
