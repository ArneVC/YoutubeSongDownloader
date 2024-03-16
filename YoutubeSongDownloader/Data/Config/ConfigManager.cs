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
            try
            {
                string json = File.ReadAllText(configFilePath);
                ProgramConfig savedConfig = JsonConvert.DeserializeObject<ProgramConfig>(json);
                return savedConfig;
            }
            catch
            {
                DeleteConfigFileIfItExists();
                CreateConfigFileIfItDoesntExist();
                return new ProgramConfig(KnownFolders.GetPath(KnownFolder.Downloads));
            }
        }
        public static string ChangeOutPutFolderFilePath(string newFilePath)
        {
            ProgramConfig currentConfig = ReadConfigFile();
            currentConfig.outputFolderPath = newFilePath;
            string json = JsonConvert.SerializeObject(currentConfig);
            CreateConfigFileIfItDoesntExist();
            File.WriteAllText(configFilePath, json);
            return newFilePath;
        }
        private static void DeleteConfigFileIfItExists()
        {
            if (File.Exists(configFilePath))
            {
                File.Delete(configFilePath);
            }
        }
    }
}
