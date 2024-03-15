using NAudio.Wave;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Xml.Linq;
using TagLib;
using YoutubeExplode.Videos;
using YoutubeSongDownloader.Data.Config;
using YoutubeSongDownloader.Data.Enums;
using static System.Windows.Forms.DataFormats;

namespace YoutubeSongDownloader
{
    public partial class Form1 : Form
    {
        private String userInput = "";
        private string outputFolderPath = "./";
        private AppState appState = AppState.Default;
        private Video? selectedVideo = null;
        private Image? selectedImage = null;
        private Image? fullThumbnailImage = null;
        private Image? fullAlbumCoverImage = null;
        public Form1(ProgramConfig config)
        {
            this.outputFolderPath = config.outputFolderPath;
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
                TitleTextBox.Text = selectedVideo.Title;
                ArtistTextBox.Text = selectedVideo.Author.ChannelTitle;
                selectedImage = await ImageParser.GetImageFromThumbnailList(selectedVideo.Thumbnails);
                fullThumbnailImage = selectedImage;
                fullAlbumCoverImage = ImageParser.GetFullAlbumCoverImageFromThumbnailImage(selectedImage);
                AlbumCoverPictureBox.Image = fullThumbnailImage;
                ChangeAppState(AppState.Results);
                DownloadStateLabel.Text = "";
            }
            SetRelevantControls(true);
        }

        private void RadioButtonSongName_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonSongName.Checked)
            {
                LabelUrl.Text = "Song Name";
            }
            else
            {
                LabelUrl.Text = "Youtube Url";
            }
        }
        private void FolderSelectButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = outputFolderPath;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    outputFolderPath = ConfigManager.ChangeOutPutFolderFilePath(fbd.SelectedPath);
                }
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
            DownloadStateLabel.Text = "downloading...";
            DownloadStateLabel.ForeColor = Color.Orange;
            Image? finalAlbumCoverImage = null;
            if (SquareAlbumCoverRadioButton.Checked == true)
            {
                finalAlbumCoverImage = fullAlbumCoverImage;
            }
            else
            {
                finalAlbumCoverImage = fullThumbnailImage;
            }
            byte[] audioStream = await SongDownloader.ExtractAudioFromVideo(selectedVideo);
            if (audioStream.Length > 0)
            {
                SaveAudioToFile(
                    audioStream,
                    ConvertSongTitleIntoFileName(TitleTextBox.Text),
                    finalAlbumCoverImage,
                    TitleTextBox.Text,
                    convertArtistsStringIntoArrayOfArtists(ArtistTextBox.Text),
                    AlbumTextBox.Text,
                    outputFolderPath
                );
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
            FolderSelectButton.Enabled = state;
        }
        private void SaveAudioToFile(byte[] audioBytes, string fileName, Image albumCover, string songTitle, string[] authors, string album, string outputFolder)
        {
            string outputPathWav = Path.Combine(outputFolder, $"{Path.GetFileNameWithoutExtension(fileName)}.mp3");
            string tempWavPath = Path.GetTempFileName();

            try
            {
                //save temp wav file
                System.IO.File.WriteAllBytes(tempWavPath, audioBytes);
                //convert to mp3
                var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                ffMpeg.ConvertMedia(tempWavPath, outputPathWav, "mp3");
                //tag
                TagLib.File outputFile = TagLib.File.Create(outputPathWav, "audio/mpeg", ReadStyle.None);
                outputFile.Tag.Title = songTitle;
                if (authors.Length > 0)
                {
                    outputFile.Tag.Performers = authors;
                }
                outputFile.Tag.Album = album;
                if (albumCover != null)
                {
                    Picture pic = new Picture();
                    pic.Type = PictureType.FrontCover;
                    pic.MimeType = System.Net.Mime.MediaTypeNames.Image.Bmp;
                    MemoryStream ms = new MemoryStream();
                    albumCover.Save(ms, ImageFormat.Bmp);
                    ms.Position = 0;
                    pic.Data = ByteVector.FromStream(ms);
                    outputFile.Tag.Pictures = new IPicture[] { pic };
                }
                outputFile.Save();
                DownloadStateLabel.Text = "downloaded";
                DownloadStateLabel.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                DownloadStateLabel.Text = "download error";
                DownloadStateLabel.ForeColor = Color.Red;
            }
            finally
            {
                //remove temp wav file
                if (System.IO.File.Exists(tempWavPath))
                {
                    System.IO.File.Delete(tempWavPath);
                }
            }
        }
        private string ConvertSongTitleIntoFileName(string songTitle)
        {
            char[] charsNotAllowedInWindowsFileName = { '<', '>', ':', '"', '/', '\\', '|', '?', '*' };
            string songTitleWithoutDissallowedChars = RemoveCharactersFromString(songTitle, charsNotAllowedInWindowsFileName);
            string fileName = songTitleWithoutDissallowedChars.Replace(" ", "_");
            return fileName + ".mp3";
        }
        public static string RemoveCharactersFromString(string input, char[] charactersToRemove)
        {
            foreach (var c in charactersToRemove)
            {
                input = input.Replace(c.ToString(), "");
            }
            return input;
        }
        private string[] convertArtistsStringIntoArrayOfArtists(string artists)
        {
            return artists.Split(';');
        }
    }
}