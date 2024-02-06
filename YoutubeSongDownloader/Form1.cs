using System.Diagnostics;
using YoutubeExplode.Videos;
using YoutubeSongDownloader.Data.Enums;

namespace YoutubeSongDownloader
{
    public partial class Form1 : Form
    {
        private String userInput = "";
        private AppState appState = AppState.Default;
        private Video selectedVideo = null;
        private Image selectedImage = null;
        private Image fullThumbnailImage = null;
        private Image fullAlbumCoverImage = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeAppState(AppState.Default);
            AlbumCoverPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            RadioButtonUrl.Checked = true;
            LabelUrl.Text = "Youtube Url:";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ErrorLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userInput = textBox1.Text;
        }

        private async void ButtonDownload_Click(object sender, EventArgs e)
        {
            SetRelevantControls(false);
            ChangeAppState(AppState.Loading);
            selectedVideo = null;
            selectedImage = null;
            fullThumbnailImage = null;
            fullAlbumCoverImage = null;
            FullAlbumCoverRadioButton.Checked = true;
            if (RadioButtonSongName.Checked)
            {
                selectedVideo = await SongDownloader.DownloadSongUsingSongName(userInput);
            }
            else
            {
                selectedVideo = await SongDownloader.DownloadSongUsingUrl(userInput);
            }
            if (selectedVideo == null)
            {
                ChangeAppState(AppState.Error);
            }
            else
            {
                ChangeAppState(AppState.Results);
                TitleTextBox.Text = selectedVideo.Title;
                ArtistTextBox.Text = selectedVideo.Author.ChannelTitle;
                selectedImage = await ImageParser.GetImageFromThumbnailList(selectedVideo.Thumbnails);
                fullThumbnailImage = selectedImage;
                fullAlbumCoverImage = ImageParser.GetFullAlbumCoverImageFromThumbnailImage(selectedImage);
                AlbumCoverPictureBox.Image = fullThumbnailImage;
            }
            SetRelevantControls(true);
        }

        private void RadioButtonSongName_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonSongName.Checked)
            {
                LabelUrl.Text = "Song Name:";
            }
            else
            {
                LabelUrl.Text = "Youtube Url:";
            }
        }
        private void SquareAlbumCoverRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SquareAlbumCoverRadioButton.Checked == true)
            {
                AlbumCoverPictureBox.Image = fullAlbumCoverImage;
            }
            else
            {
                AlbumCoverPictureBox.Image = fullThumbnailImage;
            }
        }
        private async void FinalDownloadButton_Click(object sender, EventArgs e)
        {
            Image finalAlbumCoverImage = null;
            if(SquareAlbumCoverRadioButton.Checked == true)
            {
                finalAlbumCoverImage = fullAlbumCoverImage;
            }
            else
            {
                finalAlbumCoverImage = fullThumbnailImage;
            }
            byte[] audioStream = await SongDownloader.ExtractAudioFromVideo(selectedVideo);
            if(audioStream != null)
            {
                SaveAudioToFile(audioStream, "test.mp3");
            }            
        }
        private void ChangeAppState(AppState newState)
        {
            appState = newState;
            switch (appState)
            {
                case AppState.Default:
                    PanelLoading.Visible = false;
                    PanelError.Visible = false;
                    PanelResult.Visible = false;
                    break;
                case AppState.Loading:
                    PanelLoading.Visible = true;
                    PanelError.Visible = false;
                    PanelResult.Visible = false;
                    break;
                case AppState.Error:
                    PanelLoading.Visible = false;
                    PanelError.Visible = true;
                    PanelResult.Visible = false;
                    break;
                case AppState.Results:
                    PanelLoading.Visible = false;
                    PanelError.Visible = false;
                    PanelResult.Visible = true;
                    break;
            }
        }
        private void SetRelevantControls(bool state)
        {
            ButtonDownload.Enabled = state;
            textBox1.Enabled = state;
            RadioButtonSongName.Enabled = state;
            RadioButtonUrl.Enabled = state;
        }
        private static async Task SaveAudioToFile(byte[] audioBytes, string fileName)
        {
            await File.WriteAllBytesAsync(fileName, audioBytes);
        }
    }
}
