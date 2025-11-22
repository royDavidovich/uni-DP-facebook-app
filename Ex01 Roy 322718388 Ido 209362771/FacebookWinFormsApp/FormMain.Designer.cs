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
            this.linkFavoriteMusicArtists = new System.Windows.Forms.LinkLabel();
            this.linkLikedPages = new System.Windows.Forms.LinkLabel();
            this.linkFavoriteTeams = new System.Windows.Forms.LinkLabel();
            this.linkGroups = new System.Windows.Forms.LinkLabel();
            this.linkFacebookEvents = new System.Windows.Forms.LinkLabel();
            this.linkAlbums = new System.Windows.Forms.LinkLabel();
            this.linkPosts = new System.Windows.Forms.LinkLabel();
            this.pictureBoxMainTabLogedInUser = new System.Windows.Forms.PictureBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.pictureBoxMainTab = new System.Windows.Forms.PictureBox();
            this.listBoxMainTab = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 411);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonConnectAsDesig);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(856, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "loginTab";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(856, 380);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "mainTab";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.linkFavoriteMusicArtists);
            this.splitContainer1.Panel1.Controls.Add(this.linkLikedPages);
            this.splitContainer1.Panel1.Controls.Add(this.linkFavoriteTeams);
            this.splitContainer1.Panel1.Controls.Add(this.linkGroups);
            this.splitContainer1.Panel1.Controls.Add(this.linkFacebookEvents);
            this.splitContainer1.Panel1.Controls.Add(this.linkAlbums);
            this.splitContainer1.Panel1.Controls.Add(this.linkPosts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxMainTabLogedInUser);
            this.splitContainer1.Panel2.Controls.Add(this.listBox2);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxMainTab);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxMainTab);
            this.splitContainer1.Size = new System.Drawing.Size(850, 374);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 0;
            // 
            // linkFavoriteMusicArtists
            // 
            this.linkFavoriteMusicArtists.AutoSize = true;
            this.linkFavoriteMusicArtists.Location = new System.Drawing.Point(5, 224);
            this.linkFavoriteMusicArtists.Name = "linkFavoriteMusicArtists";
            this.linkFavoriteMusicArtists.Size = new System.Drawing.Size(150, 18);
            this.linkFavoriteMusicArtists.TabIndex = 6;
            this.linkFavoriteMusicArtists.TabStop = true;
            this.linkFavoriteMusicArtists.Text = "Favorite Music Artists";
            // 
            // linkLikedPages
            // 
            this.linkLikedPages.AutoSize = true;
            this.linkLikedPages.Location = new System.Drawing.Point(5, 187);
            this.linkLikedPages.Name = "linkLikedPages";
            this.linkLikedPages.Size = new System.Drawing.Size(89, 18);
            this.linkLikedPages.TabIndex = 5;
            this.linkLikedPages.TabStop = true;
            this.linkLikedPages.Text = "Liked Pages";
            this.linkLikedPages.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLikedPages_LinkClicked);
            // 
            // linkFavoriteTeams
            // 
            this.linkFavoriteTeams.AutoSize = true;
            this.linkFavoriteTeams.Location = new System.Drawing.Point(5, 149);
            this.linkFavoriteTeams.Name = "linkFavoriteTeams";
            this.linkFavoriteTeams.Size = new System.Drawing.Size(111, 18);
            this.linkFavoriteTeams.TabIndex = 4;
            this.linkFavoriteTeams.TabStop = true;
            this.linkFavoriteTeams.Text = "Favorite Teams";
            this.linkFavoriteTeams.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFavoriteTeams_LinkClicked_1);
            // 
            // linkGroups
            // 
            this.linkGroups.AutoSize = true;
            this.linkGroups.Location = new System.Drawing.Point(5, 115);
            this.linkGroups.Name = "linkGroups";
            this.linkGroups.Size = new System.Drawing.Size(58, 18);
            this.linkGroups.TabIndex = 3;
            this.linkGroups.TabStop = true;
            this.linkGroups.Text = "Groups";
            // 
            // linkFacebookEvents
            // 
            this.linkFacebookEvents.AutoSize = true;
            this.linkFacebookEvents.Location = new System.Drawing.Point(5, 79);
            this.linkFacebookEvents.Name = "linkFacebookEvents";
            this.linkFacebookEvents.Size = new System.Drawing.Size(53, 18);
            this.linkFacebookEvents.TabIndex = 2;
            this.linkFacebookEvents.TabStop = true;
            this.linkFacebookEvents.Text = "Events";
            this.linkFacebookEvents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFacebookEvents_LinkClicked);
            // 
            // linkAlbums
            // 
            this.linkAlbums.AutoSize = true;
            this.linkAlbums.Location = new System.Drawing.Point(5, 44);
            this.linkAlbums.Name = "linkAlbums";
            this.linkAlbums.Size = new System.Drawing.Size(57, 18);
            this.linkAlbums.TabIndex = 1;
            this.linkAlbums.TabStop = true;
            this.linkAlbums.Text = "Albums";
            this.linkAlbums.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAlbums_LinkClicked);
            // 
            // linkPosts
            // 
            this.linkPosts.AutoSize = true;
            this.linkPosts.Location = new System.Drawing.Point(5, 9);
            this.linkPosts.Name = "linkPosts";
            this.linkPosts.Size = new System.Drawing.Size(47, 18);
            this.linkPosts.TabIndex = 0;
            this.linkPosts.TabStop = true;
            this.linkPosts.Text = "Posts";
            this.linkPosts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPosts_LinkClicked);
            // 
            // pictureBoxMainTabLogedInUser
            // 
            this.pictureBoxMainTabLogedInUser.Location = new System.Drawing.Point(571, 3);
            this.pictureBoxMainTabLogedInUser.Name = "pictureBoxMainTabLogedInUser";
            this.pictureBoxMainTabLogedInUser.Size = new System.Drawing.Size(82, 82);
            this.pictureBoxMainTabLogedInUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMainTabLogedInUser.TabIndex = 3;
            this.pictureBoxMainTabLogedInUser.TabStop = false;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 18;
            this.listBox2.Location = new System.Drawing.Point(185, 247);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(468, 112);
            this.listBox2.TabIndex = 2;
            // 
            // pictureBoxMainTab
            // 
            this.pictureBoxMainTab.Location = new System.Drawing.Point(477, 91);
            this.pictureBoxMainTab.Name = "pictureBoxMainTab";
            this.pictureBoxMainTab.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxMainTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMainTab.TabIndex = 1;
            this.pictureBoxMainTab.TabStop = false;
            // 
            // listBoxMainTab
            // 
            this.listBoxMainTab.FormattingEnabled = true;
            this.listBoxMainTab.ItemHeight = 18;
            this.listBoxMainTab.Location = new System.Drawing.Point(3, 3);
            this.listBoxMainTab.Name = "listBoxMainTab";
            this.listBoxMainTab.Size = new System.Drawing.Size(468, 238);
            this.listBoxMainTab.TabIndex = 0;
            this.listBoxMainTab.SelectedIndexChanged += new System.EventHandler(this.listBoxMainTabMain_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(856, 380);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 411);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainTabLogedInUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainTab)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.LinkLabel linkFavoriteTeams;
        private System.Windows.Forms.LinkLabel linkGroups;
        private System.Windows.Forms.LinkLabel linkFacebookEvents;
        private System.Windows.Forms.LinkLabel linkAlbums;
        private System.Windows.Forms.LinkLabel linkPosts;
        private System.Windows.Forms.LinkLabel linkFavoriteMusicArtists;
        private System.Windows.Forms.LinkLabel linkLikedPages;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.PictureBox pictureBoxMainTab;
        private System.Windows.Forms.ListBox listBoxMainTab;
        private System.Windows.Forms.PictureBox pictureBoxMainTabLogedInUser;
    }
}

