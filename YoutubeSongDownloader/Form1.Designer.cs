namespace YoutubeSongDownloader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            LabelUrl = new Label();
            ButtonDownload = new Button();
            RadioButtonUrl = new RadioButton();
            RadioButtonSongName = new RadioButton();
            PanelLoading = new Panel();
            LoadingGifPictureBox = new PictureBox();
            PanelError = new Panel();
            ErrorLabel = new Label();
            PanelResult = new Panel();
            PanelLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LoadingGifPictureBox).BeginInit();
            PanelError.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(776, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // LabelUrl
            // 
            LabelUrl.AutoSize = true;
            LabelUrl.Location = new Point(12, 9);
            LabelUrl.Name = "LabelUrl";
            LabelUrl.Size = new Size(69, 15);
            LabelUrl.TabIndex = 1;
            LabelUrl.Text = "Youtube Url";
            LabelUrl.Click += label1_Click;
            // 
            // ButtonDownload
            // 
            ButtonDownload.Location = new Point(12, 56);
            ButtonDownload.Name = "ButtonDownload";
            ButtonDownload.Size = new Size(776, 23);
            ButtonDownload.TabIndex = 2;
            ButtonDownload.Text = "Download";
            ButtonDownload.UseVisualStyleBackColor = true;
            ButtonDownload.Click += ButtonDownload_Click;
            // 
            // RadioButtonUrl
            // 
            RadioButtonUrl.AutoSize = true;
            RadioButtonUrl.Location = new Point(673, 5);
            RadioButtonUrl.Name = "RadioButtonUrl";
            RadioButtonUrl.Size = new Size(115, 19);
            RadioButtonUrl.TabIndex = 3;
            RadioButtonUrl.TabStop = true;
            RadioButtonUrl.Text = "Use Youtube URL";
            RadioButtonUrl.UseVisualStyleBackColor = true;
            // 
            // RadioButtonSongName
            // 
            RadioButtonSongName.AutoSize = true;
            RadioButtonSongName.Location = new Point(558, 5);
            RadioButtonSongName.Name = "RadioButtonSongName";
            RadioButtonSongName.Size = new Size(109, 19);
            RadioButtonSongName.TabIndex = 4;
            RadioButtonSongName.TabStop = true;
            RadioButtonSongName.Text = "Use Song Name";
            RadioButtonSongName.UseVisualStyleBackColor = true;
            RadioButtonSongName.CheckedChanged += RadioButtonSongName_CheckedChanged;
            // 
            // PanelLoading
            // 
            PanelLoading.Controls.Add(LoadingGifPictureBox);
            PanelLoading.Location = new Point(12, 85);
            PanelLoading.Name = "PanelLoading";
            PanelLoading.Size = new Size(776, 353);
            PanelLoading.TabIndex = 5;
            PanelLoading.UseWaitCursor = true;
            // 
            // LoadingGifPictureBox
            // 
            LoadingGifPictureBox.Image = (Image)resources.GetObject("LoadingGifPictureBox.Image");
            LoadingGifPictureBox.Location = new Point(3, 3);
            LoadingGifPictureBox.Name = "LoadingGifPictureBox";
            LoadingGifPictureBox.Size = new Size(770, 347);
            LoadingGifPictureBox.TabIndex = 0;
            LoadingGifPictureBox.TabStop = false;
            LoadingGifPictureBox.UseWaitCursor = true;
            // 
            // PanelError
            // 
            PanelError.Controls.Add(ErrorLabel);
            PanelError.Location = new Point(12, 85);
            PanelError.Name = "PanelError";
            PanelError.Size = new Size(776, 353);
            PanelError.TabIndex = 0;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.ForeColor = Color.Red;
            ErrorLabel.Location = new Point(3, 3);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(35, 15);
            ErrorLabel.TabIndex = 0;
            ErrorLabel.Text = "Error:";
            ErrorLabel.Click += ErrorLabel_Click;
            // 
            // PanelResult
            // 
            PanelResult.Location = new Point(12, 85);
            PanelResult.Name = "PanelResult";
            PanelResult.Size = new Size(776, 353);
            PanelResult.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RadioButtonSongName);
            Controls.Add(RadioButtonUrl);
            Controls.Add(ButtonDownload);
            Controls.Add(LabelUrl);
            Controls.Add(textBox1);
            Controls.Add(PanelResult);
            Controls.Add(PanelError);
            Controls.Add(PanelLoading);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Youtube Song Downloader";
            Load += Form1_Load;
            PanelLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LoadingGifPictureBox).EndInit();
            PanelError.ResumeLayout(false);
            PanelError.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label LabelUrl;
        private Button ButtonDownload;
        private RadioButton RadioButtonUrl;
        private RadioButton RadioButtonSongName;
        private Panel PanelLoading;
        private Panel PanelError;
        private Panel PanelResult;
        private PictureBox LoadingGifPictureBox;
        private Label ErrorLabel;
    }
}
