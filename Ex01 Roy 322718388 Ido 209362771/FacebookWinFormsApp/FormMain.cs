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

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        LoginResult m_LoginResult;
        User m_LoggedInUser;

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
        /// Fetching posts *** made by the logged in user ***:
        /// </summary>
        private void fetchPosts()
        {
            listBoxMainTabMain.Items.Clear();

            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxMainTabMain.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBoxMainTabMain.Items.Add(post.Caption);
                }
                else
                {
                    listBoxMainTabMain.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if (listBoxMainTabMain.Items.Count == 0)
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
            listBoxMainTabMain.Items.Clear();
            listBoxMainTabMain.DisplayMember = "Name";
            foreach (Album album in m_LoggedInUser.Albums)
            {
                listBoxMainTabMain.Items.Add(album);
                //album.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            if (listBoxMainTabMain.Items.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve :(");
            }
        }
    }
}
