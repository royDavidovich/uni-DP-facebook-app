using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Windows.Forms.DataVisualization.Charting;
using BasicFacebookFeatures;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private TabPage m_PostingTab;
        LoginResult m_LoginResult;
        User m_LoggedInUser;

        public FormMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(800, 400);
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        // This delegate will handle the selected item depending on current mode
        private Action<object> m_OnMainSelectionChanged;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if (m_LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login(
                /// (This is Desig Patter's App ID. replace it with your own) 
                textBoxAppID.Text,
                /// requested permissions:
                "email",
                "public_profile",
                "user_age_range",
                "user_birthday",
                "user_events",
                "user_friends",
                "user_gender",
                "user_hometown",
                "user_likes",
                "user_link",
                "user_location",
                "user_photos",
                "user_posts",
                "user_videos");

            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                afterLogin();
            }
        }

        private void buttonConnectAsDesig_Click(object sender, EventArgs e)
        {
            try
            {
                m_LoginResult = FacebookService.Connect("EAAUm6cZC4eUEBPZCFs9rJRpwlUmdHcPvU1tUNkIyP37zRZCjSvfdHaW5t3xsOnUL0bEKHL8Snjk6AZC3O32KWEbaItglEnXWQ2zEMXHqsdfdv0ecXNs3hO69juHrZCfRN9FGvfuJZAXhP4Pm57DRRoDeB8De6ZABnfrRflh6zgPwnavpyHS3ZCYX1E6K1QLTHff5sAZDZD");

                afterLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
            }
        }

        private void afterLogin()
        {
            tabControl1.SelectedTab = tabPage2;
            m_LoggedInUser = m_LoginResult.LoggedInUser;
            buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
            buttonLogin.BackColor = Color.LightGreen;
            pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
            pictureBoxMainTabLogedInUser.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
            vibeShifter1.LoggedInUser = m_LoggedInUser;
            vibeShifter1.AccessToken = m_LoginResult.AccessToken;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        /// <summary>
        /// Fetching posts *** made by the logged-in user ***:
        /// </summary>
        private void fetchPosts()
        {
            listBoxMainTab.Items.Clear();

            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxMainTab.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBoxMainTab.Items.Add(post.Caption);
                }
                else
                {
                    listBoxMainTab.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if (listBoxMainTab.Items.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
        }

        private void fetchAlbums()
        {
            m_OnMainSelectionChanged = handleAlbumSelected;
            listBoxMainTab.Items.Clear();
            listBoxMainTab.DisplayMember = "Name";
            foreach (Album album in m_LoggedInUser.Albums)
            {
                listBoxMainTab.Items.Add(album);
            }

            if (listBoxMainTab.Items.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve :(");
            }
        }

        private void handleAlbumSelected(object i_Item)
        {
            if (i_Item is Album album && album.PictureAlbumURL != null)
            {
                pictureBoxMainTab.LoadAsync(album.PictureAlbumURL);
            }
        }

        private void fetchFavoriteTeams()
        {
            listBoxMainTab.Items.Clear();
            m_OnMainSelectionChanged = handleTeamSelected;
            listBoxMainTab.DisplayMember = "Name";
            foreach (Page team in m_LoggedInUser.FavofriteTeams)
            {
                listBoxMainTab.Items.Add(team);
            }

            if (listBoxMainTab.Items.Count == 0)
            {
                MessageBox.Show("No teams to retrieve :(");
            }
        }

        private void handleTeamSelected(object i_Item)
        {
            if (i_Item is Page team && team.PictureNormalURL != null)
            {
                pictureBoxMainTab.LoadAsync(team.PictureNormalURL);
            }
        }

        private void listBoxMainTabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_OnMainSelectionChanged == null || listBoxMainTab.SelectedItems.Count != 1)
            {
                return;
            }

            m_OnMainSelectionChanged(listBoxMainTab.SelectedItem);
        }

        private void fetchEvents()
        {
            listBoxMainTab.Items.Clear();
            listBoxMainTab.DisplayMember = "Name";
            m_OnMainSelectionChanged = handleEventSelected;
            try
            {
                foreach (Event fbEvent in m_LoggedInUser.Events)
                {
                    listBoxMainTab.Items.Add(fbEvent);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listBoxMainTab.Items.Count == 0)
            {
                MessageBox.Show("No Events to retrieve :(");
            }
        }

        private void handleEventSelected(object i_Item)
        {
            if (i_Item is Event fbEvent && fbEvent.Cover != null)
            {
                pictureBoxMainTab.LoadAsync(fbEvent.Cover.SourceURL);
            }
        }

        private void fetchLikedPages()
        {
            listBoxMainTab.Items.Clear();
            listBoxMainTab.DisplayMember = "Name";
            m_OnMainSelectionChanged = handleLikedPageSelected;
            try
            {
                foreach (Page page in m_LoggedInUser.LikedPages)
                {
                    listBoxMainTab.Items.Add(page);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listBoxMainTab.Items.Count == 0)
            {
                MessageBox.Show("No liked pages to retrieve :(");
            }
        }

        private void handleLikedPageSelected(object obj)
        {
            if (listBoxMainTab.SelectedItems.Count == 1)
            {
                Page selectedPage = listBoxMainTab.SelectedItem as Page;
                pictureBoxMainTab.LoadAsync(selectedPage.PictureNormalURL);
            }
        }

        private void handleGroupSelected(object obj)
        {
            if (listBoxMainTab.SelectedItems.Count == 1)
            {
                Group selectedGroup = listBoxMainTab.SelectedItem as Group;
                pictureBoxMainTab.LoadAsync(selectedGroup.PictureNormalURL);
            }
        }

        private void fetchMusic()
        {
            listBoxMainTab.Items.Clear();
            listBoxMainTab.DisplayMember = "Name";
            m_OnMainSelectionChanged = handleMusicArtistSelected;
            foreach (Page artistPage in m_LoggedInUser.Music)
            {
                listBoxMainTab.Items.Add(artistPage);
            }

            if (listBoxMainTab.Items.Count == 0)
            {
                MessageBox.Show("No artsits to retrieve :(");
            }
        }

        private void handleMusicArtistSelected(object obj)
        {
            if (listBoxMainTab.SelectedItems.Count == 1)
            {
                Page selectedItem = listBoxMainTab.SelectedItem as Page;
                pictureBoxMainTab.LoadAsync(selectedItem.PictureNormalURL);
            }
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            try
            {
                fetchPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            try
            {
                fetchAlbums();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEvent_Click(object sender, EventArgs e)
        {
            try
            {
                fetchEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            listBoxMainTab.Items.Clear();
            listBoxMainTab.DisplayMember = "Name";
            m_OnMainSelectionChanged = handleGroupSelected;

            try
            {
                foreach (Group group in m_LoggedInUser.Groups)
                {
                    listBoxMainTab.Items.Add(group);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listBoxMainTab.Items.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
        }

        private void buttonFavTeams_Click(object sender, EventArgs e)
        {
            fetchFavoriteTeams();
        }

        private void buttonLikedPaged_Click(object sender, EventArgs e)
        {
            fetchLikedPages();
        }

        private void buttonFavMusic_Click(object sender, EventArgs e)
        {
            try
            {
                fetchMusic();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonActivity_Click(object sender, EventArgs e)
        {
            if (m_LoginResult == null || m_LoginResult.LoggedInUser == null)
            {
                MessageBox.Show("Please login to Facebook first.");
                return;
            }

            foreach (TabPage page in tabControl1.TabPages)
            {
                if (page.Name == "tabActivity")
                {
                    tabControl1.SelectedTab = page;
                    return;
                }
            }

            TabPage activityPage = new TabPage("Activity");
            activityPage.Name = "tabActivity";

            chartActivity activityTabView = new chartActivity();
            activityTabView.Dock = DockStyle.Fill;

            activityTabView.SetLoggedInUser(m_LoginResult.LoggedInUser);

            activityPage.Controls.Add(activityTabView);
            tabControl1.TabPages.Add(activityPage);
            tabControl1.SelectedTab = activityPage;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            UpdateMainLayout();
        }

        private void UpdateMainLayout()
        {
            listBoxMainTab.Left = (int)(buttonPosts.Left);
            listBoxMainTab.Width = (int)(this.ClientSize.Width * 0.5);
            listBoxMainTab.Height = this.ClientSize.Height - listBoxMainTab.Top;
            listBoxMainTab.BorderStyle = BorderStyle.None;

            int leftAfterListBox = listBoxMainTab.Right;
            int freeSpace = splitContainer1.Panel2.ClientSize.Width - leftAfterListBox;
            pictureBoxMainTabLogedInUser.Width = (int)(freeSpace * 0.4);
            pictureBoxMainTabLogedInUser.Height = pictureBoxMainTabLogedInUser.Width;
            pictureBoxMainTabLogedInUser.Left = leftAfterListBox + (freeSpace - pictureBoxMainTabLogedInUser.Width) / 2;
            pictureBoxMainTabLogedInUser.Top = (int)(0.1 * splitContainer1.Panel2.ClientSize.Height);
            MakePictureCircular(pictureBoxMainTabLogedInUser);

            pictureBoxMainTab.Width = (int)(freeSpace * 0.8);
            pictureBoxMainTab.Height = pictureBoxMainTab.Width;
            pictureBoxMainTab.Left = leftAfterListBox + (freeSpace - pictureBoxMainTab.Width) / 2;
            pictureBoxMainTab.Top = pictureBoxMainTabLogedInUser.Bottom + (int)(0.5*(splitContainer1.Panel2.ClientSize.Height - pictureBoxMainTabLogedInUser.Bottom - pictureBoxMainTab.Height));

        }

        private void MakePictureCircular(PictureBox pb)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pb.Width, pb.Height);
            pb.Region = new Region(path);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            m_PostingTab = tabPage3;
            tabControl1.TabPages.Remove(tabPage3);
            UpdateMainLayout();
        }

        private void buttonPostWithAI_Click(object sender, EventArgs e)
        {
            if (!tabControl1.TabPages.Contains(m_PostingTab))
            {
                tabControl1.TabPages.Add(m_PostingTab);
            }

            tabControl1.SelectedTab = m_PostingTab;
        }
    }
}
