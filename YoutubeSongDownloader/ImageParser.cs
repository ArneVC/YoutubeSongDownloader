using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSongDownloader
{
    public static class ImageParser
    {
        public static async Task<Image> GetImageFromUrl(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] data = await webClient.DownloadDataTaskAsync(url);
                using (MemoryStream mem = new MemoryStream(data))
                {
                    return Image.FromStream(mem);
                }
            }
        }
    }
}
