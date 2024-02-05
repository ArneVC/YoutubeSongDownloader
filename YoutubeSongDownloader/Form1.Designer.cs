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
            PanelError = new Panel();
            PanelResult = new Panel();
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
            PanelLoading.Location = new Point(12, 85);
            PanelLoading.Name = "PanelLoading";
            PanelLoading.Size = new Size(776, 353);
            PanelLoading.TabIndex = 5;
            // 
            // PanelError
            // 
            PanelError.Location = new Point(12, 85);
            PanelError.Name = "PanelError";
            PanelError.Size = new Size(776, 353);
            PanelError.TabIndex = 0;
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
            Controls.Add(PanelResult);
            Controls.Add(PanelError);
            Controls.Add(PanelLoading);
            Controls.Add(RadioButtonSongName);
            Controls.Add(RadioButtonUrl);
            Controls.Add(ButtonDownload);
            Controls.Add(LabelUrl);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Youtube Song Downloader";
            Load += Form1_Load;
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
    }
}
