using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Search;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeSongDownloader
{
    public static class SongDownloader
    {
        public static async Task<Video> DownloadSongUsingUrl(String url)
        {
            YoutubeClient youtube = new YoutubeClient();
            try
            {
                Video video = await youtube.Videos.GetAsync(url);
                return video;
            }
            catch
            {
                return null;
            }            
        }
        public static async Task<Video> DownloadSongUsingSongName(string songName)
        {
            YoutubeClient youtube = new YoutubeClient();
            try
            {
                IReadOnlyList<ISearchResult> searchResults = await youtube.Search.GetResultsAsync(songName);
                ISearchResult videoSearchResult = searchResults.First();
                string videoUrl = videoSearchResult.Url;
                Video video = await youtube.Videos.GetAsync(videoUrl);
                return video;
            }
            catch
            {
                return null;
            }            
        }
        public static async Task<byte[]> ExtractAudioFromVideo(Video video)
        {
            var youtubeClient = new YoutubeClient();
            try
            {
                var streamInfoSet = await youtubeClient.Videos.Streams.GetManifestAsync(video.Id);
                var audioStreamInfo = streamInfoSet.GetAudioOnlyStreams().GetWithHighestBitrate();
                using (var audioStream = await youtubeClient.Videos.Streams.GetAsync(audioStreamInfo))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await audioStream.CopyToAsync(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return [];
            }
        }
    }
}
