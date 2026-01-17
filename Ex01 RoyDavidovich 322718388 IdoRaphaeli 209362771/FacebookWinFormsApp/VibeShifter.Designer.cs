namespace BasicFacebookFeatures
{
    partial class VibeShifter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPostToFb = new System.Windows.Forms.Button();
            this.textBoxGeneratedText = new System.Windows.Forms.TextBox();
            this.buttonGeneratePost = new System.Windows.Forms.Button();
            this.comboBoxStyles = new System.Windows.Forms.ComboBox();
            this.textBoxOriginalText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddPicture = new System.Windows.Forms.Button();
            this.comboBoxPrivacy = new System.Windows.Forms.ComboBox();
            this.labelPrivacy = new System.Windows.Forms.Label();
            this.labelSelectedImages = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPreview1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPreview2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPreview3 = new System.Windows.Forms.PictureBox();
            this.labelTags = new System.Windows.Forms.Label();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.flowLayoutPanelTags = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPostToFb
            // 
            this.buttonPostToFb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPostToFb.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonPostToFb.Enabled = false;
            this.buttonPostToFb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostToFb.ForeColor = System.Drawing.SystemColors.Info;
            this.buttonPostToFb.Location = new System.Drawing.Point(670, 278);
            this.buttonPostToFb.Name = "buttonPostToFb";
            this.buttonPostToFb.Size = new System.Drawing.Size(145, 60);
            this.buttonPostToFb.TabIndex = 11;
            this.buttonPostToFb.Text = "Post to Facebook";
            this.buttonPostToFb.UseVisualStyleBackColor = false;
            this.buttonPostToFb.Click += new System.EventHandler(this.buttonPostToFb_Click);
            // 
            // textBoxGeneratedText
            // 
            this.textBoxGeneratedText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGeneratedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGeneratedText.Location = new System.Drawing.Point(18, 240);
            this.textBoxGeneratedText.Multiline = true;
            this.textBoxGeneratedText.Name = "textBoxGeneratedText";
            this.textBoxGeneratedText.ReadOnly = true;
            this.textBoxGeneratedText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxGeneratedText.Size = new System.Drawing.Size(444, 104);
            this.textBoxGeneratedText.TabIndex = 10;
            // 
            // buttonGeneratePost
            // 
            this.buttonGeneratePost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGeneratePost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGeneratePost.Location = new System.Drawing.Point(670, 135);
            this.buttonGeneratePost.Name = "buttonGeneratePost";
            this.buttonGeneratePost.Size = new System.Drawing.Size(145, 60);
            this.buttonGeneratePost.TabIndex = 9;
            this.buttonGeneratePost.Text = "Make it Cool !";
            this.buttonGeneratePost.UseVisualStyleBackColor = true;
            this.buttonGeneratePost.Click += new System.EventHandler(this.buttonGeneratePost_Click);
            // 
            // comboBoxStyles
            // 
            this.comboBoxStyles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStyles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxStyles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStyles.FormattingEnabled = true;
            this.comboBoxStyles.Items.AddRange(new object[] {
            "Original (No AI - Post Direct)",
            "Cool Influencer",
            "Angry Pirate",
            "Yoda from Star Wars",
            "Trump",
            "Sleepy (Joe) Biden",
            "Kanye West",
            "Stephen Hawking",
            "Gordon Ramsay",
            "Nicky Goldstein (Israeli Singer/Actor)"});
            this.comboBoxStyles.Location = new System.Drawing.Point(481, 135);
            this.comboBoxStyles.Name = "comboBoxStyles";
            this.comboBoxStyles.Size = new System.Drawing.Size(148, 24);
            this.comboBoxStyles.TabIndex = 8;
            this.comboBoxStyles.DropDown += new System.EventHandler(this.comboBoxStyles_DropDown);
            // 
            // textBoxOriginalText
            // 
            this.textBoxOriginalText.AcceptsReturn = true;
            this.textBoxOriginalText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOriginalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOriginalText.Location = new System.Drawing.Point(18, 116);
            this.textBoxOriginalText.Multiline = true;
            this.textBoxOriginalText.Name = "textBoxOriginalText";
            this.textBoxOriginalText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOriginalText.Size = new System.Drawing.Size(444, 104);
            this.textBoxOriginalText.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(186, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 85);
            this.label2.TabIndex = 6;
            this.label2.Text = "Create Your Perfect Post\r\n\r\nWrite what\'s on your mind below.\r\nWant to spice it up" +
    "? Select a Vibe and let AI rewrite it for you.\r\nPrefer your own words? Select \"O" +
    "riginal (No AI)\" and post directly!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonAddPicture
            // 
            this.buttonAddPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddPicture.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPicture.ForeColor = System.Drawing.Color.White;
            this.buttonAddPicture.Location = new System.Drawing.Point(481, 249);
            this.buttonAddPicture.Name = "buttonAddPicture";
            this.buttonAddPicture.Size = new System.Drawing.Size(149, 40);
            this.buttonAddPicture.TabIndex = 12;
            this.buttonAddPicture.Text = "Add Picture";
            this.buttonAddPicture.UseVisualStyleBackColor = false;
            this.buttonAddPicture.Click += new System.EventHandler(this.buttonAddPicture_Click);
            // 
            // comboBoxPrivacy
            // 
            this.comboBoxPrivacy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPrivacy.BackColor = System.Drawing.Color.White;
            this.comboBoxPrivacy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrivacy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPrivacy.FormattingEnabled = true;
            this.comboBoxPrivacy.Items.AddRange(new object[] {
            "Public",
            "Friends Only",
            "Private"});
            this.comboBoxPrivacy.Location = new System.Drawing.Point(481, 186);
            this.comboBoxPrivacy.Name = "comboBoxPrivacy";
            this.comboBoxPrivacy.Size = new System.Drawing.Size(148, 24);
            this.comboBoxPrivacy.TabIndex = 13;
            this.comboBoxPrivacy.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrivacy_SelectedIndexChanged);
            // 
            // labelPrivacy
            // 
            this.labelPrivacy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrivacy.AutoSize = true;
            this.labelPrivacy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrivacy.ForeColor = System.Drawing.Color.White;
            this.labelPrivacy.Location = new System.Drawing.Point(478, 168);
            this.labelPrivacy.Name = "labelPrivacy";
            this.labelPrivacy.Size = new System.Drawing.Size(80, 15);
            this.labelPrivacy.TabIndex = 14;
            this.labelPrivacy.Text = "Privacy Level:";
            // 
            // labelSelectedImages
            // 
            this.labelSelectedImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectedImages.AutoSize = true;
            this.labelSelectedImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedImages.ForeColor = System.Drawing.Color.LightGray;
            this.labelSelectedImages.Location = new System.Drawing.Point(478, 230);
            this.labelSelectedImages.Name = "labelSelectedImages";
            this.labelSelectedImages.Size = new System.Drawing.Size(100, 13);
            this.labelSelectedImages.TabIndex = 15;
            this.labelSelectedImages.Text = "No images selected";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(478, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Styles:";
            // 
            // pictureBoxPreview1
            // 
            this.pictureBoxPreview1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pictureBoxPreview1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview1.Location = new System.Drawing.Point(481, 298);
            this.pictureBoxPreview1.Name = "pictureBoxPreview1";
            this.pictureBoxPreview1.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxPreview1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview1.TabIndex = 17;
            this.pictureBoxPreview1.TabStop = false;
            this.pictureBoxPreview1.Visible = false;
            // 
            // pictureBoxPreview2
            // 
            this.pictureBoxPreview2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pictureBoxPreview2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview2.Location = new System.Drawing.Point(533, 298);
            this.pictureBoxPreview2.Name = "pictureBoxPreview2";
            this.pictureBoxPreview2.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxPreview2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview2.TabIndex = 18;
            this.pictureBoxPreview2.TabStop = false;
            this.pictureBoxPreview2.Visible = false;
            // 
            // pictureBoxPreview3
            // 
            this.pictureBoxPreview3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pictureBoxPreview3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview3.Location = new System.Drawing.Point(585, 298);
            this.pictureBoxPreview3.Name = "pictureBoxPreview3";
            this.pictureBoxPreview3.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxPreview3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview3.TabIndex = 19;
            this.pictureBoxPreview3.TabStop = false;
            this.pictureBoxPreview3.Visible = false;
            // 
            // labelTags
            // 
            this.labelTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTags.ForeColor = System.Drawing.Color.White;
            this.labelTags.Location = new System.Drawing.Point(18, 354);
            this.labelTags.Name = "labelTags";
            this.labelTags.Size = new System.Drawing.Size(34, 13);
            this.labelTags.TabIndex = 20;
            this.labelTags.Text = "Tags:";
            // 
            // textBoxTag
            // 
            this.textBoxTag.BackColor = System.Drawing.Color.White;
            this.textBoxTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTag.Location = new System.Drawing.Point(57, 351);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.Size = new System.Drawing.Size(120, 20);
            this.textBoxTag.TabIndex = 21;
            this.textBoxTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTag_KeyDown);
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddTag.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonAddTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddTag.ForeColor = System.Drawing.Color.White;
            this.buttonAddTag.Location = new System.Drawing.Point(183, 351);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(60, 20);
            this.buttonAddTag.TabIndex = 22;
            this.buttonAddTag.Text = "Add";
            this.buttonAddTag.UseVisualStyleBackColor = false;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // flowLayoutPanelTags
            // 
            this.flowLayoutPanelTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelTags.AutoScroll = true;
            this.flowLayoutPanelTags.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelTags.BackColor = System.Drawing.Color.MidnightBlue;
            this.flowLayoutPanelTags.Location = new System.Drawing.Point(249, 351);
            this.flowLayoutPanelTags.Name = "flowLayoutPanelTags";
            this.flowLayoutPanelTags.Size = new System.Drawing.Size(381, 20);
            this.flowLayoutPanelTags.TabIndex = 23;
            // 
            // VibeShifter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.Controls.Add(this.flowLayoutPanelTags);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.labelTags);
            this.Controls.Add(this.pictureBoxPreview3);
            this.Controls.Add(this.pictureBoxPreview2);
            this.Controls.Add(this.pictureBoxPreview1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSelectedImages);
            this.Controls.Add(this.labelPrivacy);
            this.Controls.Add(this.comboBoxPrivacy);
            this.Controls.Add(this.buttonAddPicture);
            this.Controls.Add(this.buttonPostToFb);
            this.Controls.Add(this.textBoxGeneratedText);
            this.Controls.Add(this.buttonGeneratePost);
            this.Controls.Add(this.comboBoxStyles);
            this.Controls.Add(this.textBoxOriginalText);
            this.Controls.Add(this.label2);
            this.Name = "VibeShifter";
            this.Size = new System.Drawing.Size(850, 374);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPostToFb;
        private System.Windows.Forms.TextBox textBoxGeneratedText;
        private System.Windows.Forms.Button buttonGeneratePost;
        private System.Windows.Forms.ComboBox comboBoxStyles;
        private System.Windows.Forms.TextBox textBoxOriginalText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddPicture;
        private System.Windows.Forms.ComboBox comboBoxPrivacy;
        private System.Windows.Forms.Label labelPrivacy;
        private System.Windows.Forms.Label labelSelectedImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxPreview1;
        private System.Windows.Forms.PictureBox pictureBoxPreview2;
        private System.Windows.Forms.PictureBox pictureBoxPreview3;
        private System.Windows.Forms.Label labelTags;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTags;
    }
}