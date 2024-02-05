using System.Diagnostics;
using YoutubeExplode.Videos;
using YoutubeSongDownloader.Data.Enums;

namespace YoutubeSongDownloader
{
    public partial class Form1 : Form
    {
        private String userInput = "";
        private AppState appState = AppState.Default;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeAppState(AppState.Results);
            RadioButtonSongName.Checked = true;
            LabelUrl.Text = "Song Name:";
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
            Video result = null;
            if (RadioButtonSongName.Checked)
            {
                result = await SongDownloader.DownloadSongUsingSongName(userInput);
            }
            else
            {
                result = await SongDownloader.DownloadSongUsingUrl(userInput);
            }
            ChangeAppState(AppState.Results);
            if (result == null)
            {

            }
            else
            {
                TitleTextBox.Text = result.Title;
                ArtistTextBox.Text = result.Author.ChannelTitle;
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
    }
}
