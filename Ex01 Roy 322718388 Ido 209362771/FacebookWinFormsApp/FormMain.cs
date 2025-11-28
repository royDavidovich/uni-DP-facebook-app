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
        public FormMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(800, 400);
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        LoginResult m_LoginResult;
        User m_LoggedInUser;

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

        private void linkLabelActivity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
         
        private void linkPosts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkAlbums_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkFavoriteTeams_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchFavoriteTeams();
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

        private void linkFacebookEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            catch(Exception ex)
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

        private void linkLikedPages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchLikedPages();
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

        private void linkGroups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void handleGroupSelected(object obj)
        {
            if (listBoxMainTab.SelectedItems.Count == 1)
            {
                Group selectedGroup = listBoxMainTab.SelectedItem as Group;
                pictureBoxMainTab.LoadAsync(selectedGroup.PictureNormalURL);
            }
        }

        private void linkFavoriteMusicArtists_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        }
    }
}
