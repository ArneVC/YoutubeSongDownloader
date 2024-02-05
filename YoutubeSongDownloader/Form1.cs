using System.Diagnostics;

namespace YoutubeSongDownloader
{
    public partial class Form1 : Form
    {
        private String userInput = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RadioButtonSongName.Checked = true;
            LabelUrl.Text = "Song Name:";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userInput = textBox1.Text;
        }

        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            ButtonDownload.Enabled = false;
            bool result = false;
            if(RadioButtonSongName.Checked)
            {
                result = SongDownloader.DownloadSongUsingSongName(userInput);
            }
            else
            {
                result = SongDownloader.DownloadSongUsingUrl(userInput);
            }
            if(result == true)
            {

            }
            else
            {

            }
        }

        private void RadioButtonSongName_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioButtonSongName.Checked)
            {
                LabelUrl.Text = "Song Name:";
            }
            else
            {
                LabelUrl.Text = "Youtube Url:";
            }
        }
    }
}
