using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YoutubeExplode.Common;

namespace YoutubeSongDownloader
{
    public static class ImageParser
    {
        public static async Task<Image> GetImageFromThumbnailList(IReadOnlyList<Thumbnail> thumbnails)
        {
            String url = "";
            Resolution resolution = new Resolution(0, 0);
            foreach(Thumbnail thumbnail in thumbnails)
            {
                if((thumbnail.Resolution.Width *  thumbnail.Resolution.Height) > resolution.Width *  resolution.Height)
                {
                    url = thumbnail.Url;
                    resolution = thumbnail.Resolution;
                }
            }
            Debug.WriteLine("chosen resolution: " + resolution.ToString());
            return null;
        }
    }
}
