namespace BasicFacebookFeatures
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonConnectAsDesig = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonActivity = new System.Windows.Forms.Button();
            this.buttonFavMusic = new System.Windows.Forms.Button();
            this.buttonLikedPaged = new System.Windows.Forms.Button();
            this.buttonFavTeams = new System.Windows.Forms.Button();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.buttonEvent = new System.Windows.Forms.Button();
            this.buttonAlbums = new System.Windows.Forms.Button();
            this.buttonPosts = new System.Windows.Forms.Button();
            this.pictureBoxMainTabLogedInUser = new System.Windows.Forms.PictureBox();
            this.pictureBoxMainTab = new System.Windows.Forms.PictureBox();
            this.listBoxMainTab = new System.Windows.Forms.ListBox();
            this.buttonPostWithAI = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.vibeShifter1 = new BasicFacebookFeatures.VibeShifter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainTabLogedInUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainTab)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(18, 17);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(268, 44);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(18, 121);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(268, 43);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 54);
            this.label1.TabIndex = 53;
            this.label1.Text = "This is the AppID of \"Design Patterns App 2.4\".\r\nThe grader will use it to test y" +
    "our app.\r\nType here your own AppID to test it:\r\n";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 446);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage1.Controls.Add(this.buttonConnectAsDesig);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(856, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "loginTab";
            // 
            // buttonConnectAsDesig
            // 
            this.buttonConnectAsDesig.Location = new System.Drawing.Point(18, 69);
            this.buttonConnectAsDesig.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConnectAsDesig.Name = "buttonConnectAsDesig";
            this.buttonConnectAsDesig.Size = new System.Drawing.Size(268, 44);
            this.buttonConnectAsDesig.TabIndex = 56;
            this.buttonConnectAsDesig.Text = "Connect As Desig";
            this.buttonConnectAsDesig.UseVisualStyleBackColor = true;
            this.buttonConnectAsDesig.Click += new System.EventHandler(this.buttonConnectAsDesig_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(18, 171);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(79, 78);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(319, 126);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(446, 24);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "1919347028928660";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Navy;
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(856, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "mainTab";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.splitContainer1.Panel1.Controls.Add(this.buttonPostWithAI);
            this.splitContainer1.Panel1.Controls.Add(this.buttonActivity);
            this.splitContainer1.Panel1.Controls.Add(this.buttonFavMusic);
            this.splitContainer1.Panel1.Controls.Add(this.buttonLikedPaged);
            this.splitContainer1.Panel1.Controls.Add(this.buttonFavTeams);
            this.splitContainer1.Panel1.Controls.Add(this.buttonGroups);
            this.splitContainer1.Panel1.Controls.Add(this.buttonEvent);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAlbums);
            this.splitContainer1.Panel1.Controls.Add(this.buttonPosts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxMainTabLogedInUser);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxMainTab);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxMainTab);
            this.splitContainer1.Size = new System.Drawing.Size(850, 405);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonActivity
            // 
            this.buttonActivity.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonActivity.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActivity.FlatAppearance.BorderSize = 0;
            this.buttonActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActivity.ForeColor = System.Drawing.Color.White;
            this.buttonActivity.Location = new System.Drawing.Point(0, 287);
            this.buttonActivity.Name = "buttonActivity";
            this.buttonActivity.Size = new System.Drawing.Size(190, 41);
            this.buttonActivity.TabIndex = 15;
            this.buttonActivity.Text = "Activity";
            this.buttonActivity.UseVisualStyleBackColor = false;
            this.buttonActivity.Click += new System.EventHandler(this.buttonActivity_Click);
            // 
            // buttonFavMusic
            // 
            this.buttonFavMusic.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonFavMusic.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFavMusic.FlatAppearance.BorderSize = 0;
            this.buttonFavMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFavMusic.ForeColor = System.Drawing.Color.White;
            this.buttonFavMusic.Location = new System.Drawing.Point(0, 246);
            this.buttonFavMusic.Name = "buttonFavMusic";
            this.buttonFavMusic.Size = new System.Drawing.Size(190, 41);
            this.buttonFavMusic.TabIndex = 14;
            this.buttonFavMusic.Text = "Favorite Music";
            this.buttonFavMusic.UseVisualStyleBackColor = false;
            this.buttonFavMusic.Click += new System.EventHandler(this.buttonFavMusic_Click);
            // 
            // buttonLikedPaged
            // 
            this.buttonLikedPaged.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonLikedPaged.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLikedPaged.FlatAppearance.BorderSize = 0;
            this.buttonLikedPaged.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLikedPaged.ForeColor = System.Drawing.Color.White;
            this.buttonLikedPaged.Location = new System.Drawing.Point(0, 205);
            this.buttonLikedPaged.Name = "buttonLikedPaged";
            this.buttonLikedPaged.Size = new System.Drawing.Size(190, 41);
            this.buttonLikedPaged.TabIndex = 13;
            this.buttonLikedPaged.Text = "Liked Paged";
            this.buttonLikedPaged.UseVisualStyleBackColor = false;
            this.buttonLikedPaged.Click += new System.EventHandler(this.buttonLikedPaged_Click);
            // 
            // buttonFavTeams
            // 
            this.buttonFavTeams.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonFavTeams.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFavTeams.FlatAppearance.BorderSize = 0;
            this.buttonFavTeams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFavTeams.ForeColor = System.Drawing.Color.White;
            this.buttonFavTeams.Location = new System.Drawing.Point(0, 164);
            this.buttonFavTeams.Name = "buttonFavTeams";
            this.buttonFavTeams.Size = new System.Drawing.Size(190, 41);
            this.buttonFavTeams.TabIndex = 12;
            this.buttonFavTeams.Text = "Favorite Teams";
            this.buttonFavTeams.UseVisualStyleBackColor = false;
            this.buttonFavTeams.Click += new System.EventHandler(this.buttonFavTeams_Click);
            // 
            // buttonGroups
            // 
            this.buttonGroups.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGroups.FlatAppearance.BorderSize = 0;
            this.buttonGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGroups.ForeColor = System.Drawing.Color.White;
            this.buttonGroups.Location = new System.Drawing.Point(0, 123);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(190, 41);
            this.buttonGroups.TabIndex = 11;
            this.buttonGroups.Text = "Groups";
            this.buttonGroups.UseVisualStyleBackColor = false;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // buttonEvent
            // 
            this.buttonEvent.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEvent.FlatAppearance.BorderSize = 0;
            this.buttonEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEvent.ForeColor = System.Drawing.Color.White;
            this.buttonEvent.Location = new System.Drawing.Point(0, 82);
            this.buttonEvent.Name = "buttonEvent";
            this.buttonEvent.Size = new System.Drawing.Size(190, 41);
            this.buttonEvent.TabIndex = 10;
            this.buttonEvent.Text = "Event";
            this.buttonEvent.UseVisualStyleBackColor = false;
            this.buttonEvent.Click += new System.EventHandler(this.buttonEvent_Click);
            // 
            // buttonAlbums
            // 
            this.buttonAlbums.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAlbums.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAlbums.FlatAppearance.BorderSize = 0;
            this.buttonAlbums.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlbums.ForeColor = System.Drawing.Color.White;
            this.buttonAlbums.Location = new System.Drawing.Point(0, 41);
            this.buttonAlbums.Name = "buttonAlbums";
            this.buttonAlbums.Size = new System.Drawing.Size(190, 41);
            this.buttonAlbums.TabIndex = 9;
            this.buttonAlbums.Text = "Albums";
            this.buttonAlbums.UseVisualStyleBackColor = false;
            this.buttonAlbums.Click += new System.EventHandler(this.buttonAlbums_Click);
            // 
            // buttonPosts
            // 
            this.buttonPosts.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonPosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPosts.FlatAppearance.BorderSize = 0;
            this.buttonPosts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPosts.ForeColor = System.Drawing.Color.White;
            this.buttonPosts.Location = new System.Drawing.Point(0, 0);
            this.buttonPosts.Name = "buttonPosts";
            this.buttonPosts.Size = new System.Drawing.Size(190, 41);
            this.buttonPosts.TabIndex = 8;
            this.buttonPosts.Text = "Posts";
            this.buttonPosts.UseVisualStyleBackColor = false;
            this.buttonPosts.Click += new System.EventHandler(this.buttonPosts_Click);
            // 
            // linkLabelActivity
            // 
            this.linkLabelActivity.AutoSize = true;
            this.linkLabelActivity.Location = new System.Drawing.Point(5, 262);
            this.linkLabelActivity.Name = "linkLabelActivity";
            this.linkLabelActivity.Size = new System.Drawing.Size(53, 18);
            this.linkLabelActivity.TabIndex = 7;
            this.linkLabelActivity.TabStop = true;
            this.linkLabelActivity.Text = "Activity";
            this.linkLabelActivity.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelActivity_LinkClicked);
            // 
            // pictureBoxMainTabLogedInUser
            // 
            this.pictureBoxMainTabLogedInUser.Location = new System.Drawing.Point(591, 6);
            this.pictureBoxMainTabLogedInUser.Name = "pictureBoxMainTabLogedInUser";
            this.pictureBoxMainTabLogedInUser.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxMainTabLogedInUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMainTabLogedInUser.TabIndex = 3;
            this.pictureBoxMainTabLogedInUser.TabStop = false;
            // 
            // pictureBoxMainTab
            // 
            this.pictureBoxMainTab.Location = new System.Drawing.Point(477, 72);
            this.pictureBoxMainTab.Name = "pictureBoxMainTab";
            this.pictureBoxMainTab.Size = new System.Drawing.Size(170, 170);
            this.pictureBoxMainTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMainTab.TabIndex = 1;
            this.pictureBoxMainTab.TabStop = false;
            // 
            // listBoxMainTab
            // 
            this.listBoxMainTab.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.listBoxMainTab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxMainTab.FormattingEnabled = true;
            this.listBoxMainTab.ItemHeight = 22;
            this.listBoxMainTab.Location = new System.Drawing.Point(3, 3);
            this.listBoxMainTab.Name = "listBoxMainTab";
            this.listBoxMainTab.Size = new System.Drawing.Size(468, 220);
            this.listBoxMainTab.TabIndex = 0;
            this.listBoxMainTab.SelectedIndexChanged += new System.EventHandler(this.listBoxMainTabMain_SelectedIndexChanged);
            // 
            // buttonPostWithAI
            // 
            this.buttonPostWithAI.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonPostWithAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPostWithAI.FlatAppearance.BorderSize = 0;
            this.buttonPostWithAI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPostWithAI.ForeColor = System.Drawing.Color.White;
            this.buttonPostWithAI.Location = new System.Drawing.Point(0, 328);
            this.buttonPostWithAI.Name = "buttonPostWithAI";
            this.buttonPostWithAI.Size = new System.Drawing.Size(190, 41);
            this.buttonPostWithAI.TabIndex = 16;
            this.buttonPostWithAI.Text = "Post With AI";
            this.buttonPostWithAI.UseVisualStyleBackColor = false;
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.vibeShifter1);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(856, 380);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "postingTab";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // vibeShifter1
            // 
            this.vibeShifter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vibeShifter1.Location = new System.Drawing.Point(3, 3);
            this.vibeShifter1.LoggedInUser = null;
            this.vibeShifter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vibeShifter1.Name = "vibeShifter1";
            this.vibeShifter1.Size = new System.Drawing.Size(850, 374);
            this.vibeShifter1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 446);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Facebook";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainTabLogedInUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainTab)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonConnectAsDesig;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBoxMainTab;
        private System.Windows.Forms.ListBox listBoxMainTab;
        private System.Windows.Forms.PictureBox pictureBoxMainTabLogedInUser;
        private System.Windows.Forms.Button buttonAlbums;
        private System.Windows.Forms.Button buttonPosts;
        private System.Windows.Forms.Button buttonFavMusic;
        private System.Windows.Forms.Button buttonLikedPaged;
        private System.Windows.Forms.Button buttonFavTeams;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.Button buttonEvent;
        private System.Windows.Forms.Button buttonActivity;
        private System.Windows.Forms.Button buttonPostWithAI;
        private System.Windows.Forms.LinkLabel linkLabelActivity;
        private VibeShifter vibeShifter1;
    }
}

