using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSongDownloader.Data
{
    public class ProgramConfig
    {
        public string outputFolderPath { get; set; }
        public override string ToString()
        {
            return "ProgramConfig(outputFolderPath" + outputFolderPath + ")";
        }
    }
}
