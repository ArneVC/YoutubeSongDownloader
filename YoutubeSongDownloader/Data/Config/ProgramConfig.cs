﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSongDownloader.Data.Config
{
    public class ProgramConfig
    {
        public string outputFolderPath { get; set; }
        public ProgramConfig(string outputFolder)
        {
            outputFolderPath = outputFolder;
        }
        public override string ToString()
        {
            return "ProgramConfig(outputFolderPath: " + outputFolderPath + ")";
        }
    }
}
