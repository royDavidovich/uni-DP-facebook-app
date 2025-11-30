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
            this.SuspendLayout();
            // 
            // buttonPostToFb
            // 
            this.buttonPostToFb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPostToFb.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonPostToFb.Enabled = false;
            this.buttonPostToFb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostToFb.ForeColor = System.Drawing.SystemColors.Info;
            this.buttonPostToFb.Location = new System.Drawing.Point(481, 248);
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
            this.textBoxGeneratedText.Location = new System.Drawing.Point(18, 228);
            this.textBoxGeneratedText.Multiline = true;
            this.textBoxGeneratedText.Name = "textBoxGeneratedText";
            this.textBoxGeneratedText.ReadOnly = true;
            this.textBoxGeneratedText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxGeneratedText.Size = new System.Drawing.Size(444, 94);
            this.textBoxGeneratedText.TabIndex = 10;
            // 
            // buttonGeneratePost
            // 
            this.buttonGeneratePost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGeneratePost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGeneratePost.Location = new System.Drawing.Point(649, 185);
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
            this.comboBoxStyles.Location = new System.Drawing.Point(481, 150);
            this.comboBoxStyles.Name = "comboBoxStyles";
            this.comboBoxStyles.Size = new System.Drawing.Size(143, 24);
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
            this.textBoxOriginalText.Size = new System.Drawing.Size(444, 94);
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
            // VibeShifter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.Controls.Add(this.buttonPostToFb);
            this.Controls.Add(this.textBoxGeneratedText);
            this.Controls.Add(this.buttonGeneratePost);
            this.Controls.Add(this.comboBoxStyles);
            this.Controls.Add(this.textBoxOriginalText);
            this.Controls.Add(this.label2);
            this.Name = "VibeShifter";
            this.Size = new System.Drawing.Size(850, 374);
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
    }
}
