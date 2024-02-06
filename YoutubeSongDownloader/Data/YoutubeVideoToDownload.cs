using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos;

namespace YoutubeSongDownloader.Data
{
    public class YoutubeVideoToDownload
    {
        public Video Video { get; set; }
        public Image AlbumCover { get; set; }
    }
}
