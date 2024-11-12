namespace Video_Loder
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
            splitContainer1 = new SplitContainer();
            btn_fetch = new Button();
            tbx_urlField = new TextBox();
            splitContainer2 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            pbx_thumbnailPreview = new PictureBox();
            pbr_progress = new ProgressBar();
            splitContainer3 = new SplitContainer();
            btn_download = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbx_thumbnailPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btn_fetch);
            splitContainer1.Panel1.Controls.Add(tbx_urlField);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 43;
            splitContainer1.TabIndex = 0;
            // 
            // btn_fetch
            // 
            btn_fetch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btn_fetch.Location = new Point(653, 7);
            btn_fetch.Margin = new Padding(0);
            btn_fetch.Name = "btn_fetch";
            btn_fetch.Size = new Size(142, 30);
            btn_fetch.TabIndex = 1;
            btn_fetch.Text = "Fetch";
            btn_fetch.UseVisualStyleBackColor = true;
            btn_fetch.Click += btn_fetch_Click;
            // 
            // tbx_urlField
            // 
            tbx_urlField.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbx_urlField.Location = new Point(12, 8);
            tbx_urlField.Name = "tbx_urlField";
            tbx_urlField.Size = new Size(638, 27);
            tbx_urlField.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(800, 403);
            splitContainer2.SplitterDistance = 639;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.FixedPanel = FixedPanel.Panel2;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(pbx_thumbnailPreview);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(pbr_progress);
            splitContainer4.Size = new Size(639, 403);
            splitContainer4.SplitterDistance = 364;
            splitContainer4.TabIndex = 0;
            // 
            // pbx_thumbnailPreview
            // 
            pbx_thumbnailPreview.BorderStyle = BorderStyle.FixedSingle;
            pbx_thumbnailPreview.Dock = DockStyle.Fill;
            pbx_thumbnailPreview.Location = new Point(0, 0);
            pbx_thumbnailPreview.Margin = new Padding(5);
            pbx_thumbnailPreview.Name = "pbx_thumbnailPreview";
            pbx_thumbnailPreview.Size = new Size(639, 364);
            pbx_thumbnailPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbx_thumbnailPreview.TabIndex = 0;
            pbx_thumbnailPreview.TabStop = false;
            // 
            // pbr_progress
            // 
            pbr_progress.Dock = DockStyle.Fill;
            pbr_progress.Location = new Point(0, 0);
            pbr_progress.Name = "pbr_progress";
            pbr_progress.Size = new Size(639, 35);
            pbr_progress.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.FixedPanel = FixedPanel.Panel2;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(btn_download);
            splitContainer3.Size = new Size(157, 403);
            splitContainer3.SplitterDistance = 364;
            splitContainer3.TabIndex = 0;
            // 
            // btn_download
            // 
            btn_download.Dock = DockStyle.Fill;
            btn_download.Location = new Point(0, 0);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(157, 35);
            btn_download.TabIndex = 0;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btn_download_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Youtube Loader";
            TopMost = true;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbx_thumbnailPreview).EndInit();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox tbx_urlField;
        private Button btn_fetch;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button btn_download;
        private SplitContainer splitContainer4;
        private ProgressBar pbr_progress;
        private PictureBox pbx_thumbnailPreview;
    }
}
