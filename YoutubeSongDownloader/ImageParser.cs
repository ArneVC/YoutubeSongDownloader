using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
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
        public static async Task<System.Drawing.Image> GetImageFromThumbnailList(IReadOnlyList<Thumbnail> thumbnails)
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
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(url);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        using (Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(ms))
                        {
                            using (MemoryStream convertedStream = new MemoryStream())
                            {
                                image.SaveAsPng(convertedStream);
                                convertedStream.Seek(0, SeekOrigin.Begin);
                                return System.Drawing.Image.FromStream(convertedStream);
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }                      
        }
        public static System.Drawing.Image GetFullAlbumCoverImageFromThumbnailImage(System.Drawing.Image thumbnailImage)
        {
            if(thumbnailImage == null)
            {
                return null;
            }
            int thumbnailWidth = thumbnailImage.Width;
            int thumbnailHeight = thumbnailImage.Height;
            int squareSize = Math.Min(thumbnailWidth, thumbnailHeight);
            int x = (thumbnailWidth - squareSize) / 2;
            int y = (thumbnailHeight - squareSize) / 2;
            System.Drawing.Rectangle cropRectangle = new System.Drawing.Rectangle(x, y, squareSize, squareSize);
            Bitmap croppedImage = new Bitmap(squareSize, squareSize);
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(thumbnailImage, new System.Drawing.Rectangle(0, 0, squareSize, squareSize), cropRectangle, GraphicsUnit.Pixel);
            }

            return croppedImage;
        }
    }
}
