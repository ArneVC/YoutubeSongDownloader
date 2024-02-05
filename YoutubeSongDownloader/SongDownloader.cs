using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Search;
using YoutubeExplode.Videos;

namespace YoutubeSongDownloader
{
    public static class SongDownloader
    {
        public static async Task<Video> DownloadSongUsingUrl(String url)
        {
            YoutubeClient youtube = new YoutubeClient();
            Video video = await youtube.Videos.GetAsync(url);
            return video;
        }
        public static async Task<Video> DownloadSongUsingSongName(string songName)
        {
            YoutubeClient youtube = new YoutubeClient();
            IReadOnlyList<ISearchResult> searchResults = await youtube.Search.GetResultsAsync(songName);
            ISearchResult videoSearchResult = searchResults.First();
            string videoUrl = videoSearchResult.Url;
            Video video = await youtube.Videos.GetAsync(videoUrl);
            return video;
        }
    }
}
