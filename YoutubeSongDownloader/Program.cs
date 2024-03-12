using System.Diagnostics;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            CreateConfigFileIfItDoesntExist();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        static void CreateConfigFileIfItDoesntExist()
        {
            if(!File.Exists(configFilePath))
            {
                File.Create("config.json").Dispose();
            }
        }
    }
}