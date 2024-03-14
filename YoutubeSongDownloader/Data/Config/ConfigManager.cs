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
        private static string configFilePath = "./config.json";
        public static void CreateConfigFileIfItDoesntExist()
        {
            if (!File.Exists(configFilePath))
            {
                using (StreamWriter writer = File.CreateText(configFilePath))
                {
                    ProgramConfig defaultConfig = new ProgramConfig(KnownFolders.GetPath(KnownFolder.Downloads));
                    string json = JsonConvert.SerializeObject(defaultConfig);
                    writer.Write(json);
                }
            }
        }
        public static ProgramConfig ReadConfigFile()
        {
            string json = File.ReadAllText(configFilePath);
            ProgramConfig savedConfig = JsonConvert.DeserializeObject<ProgramConfig>(json);
            return savedConfig;
        }
    }
}
