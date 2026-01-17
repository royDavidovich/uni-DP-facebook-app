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
using BasicFacebookFeatures.Facades;
using BasicFacebookFeatures.ContentDisplayers;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private TabPage m_PostingTab;
        private TabPage m_MainTab;
        private FacebookFacade m_FacebookFacade;

        private Action<object> m_OnMainSelectionChanged;

        public FormMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(800, 400);
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            m_FacebookFacade = FacebookFacade.Instance;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if (!m_FacebookFacade.IsLoggedIn)
            {
                login();
            }
        }

        private void login()
        {
            var loginResult = m_FacebookFacade.Login(
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

            if (string.IsNullOrEmpty(loginResult.ErrorMessage))
            {
                afterLogin();
            }
        }

        private void buttonConnectAsDesig_Click(object sender, EventArgs e)
        {
            try
            {
                var loginResult = m_FacebookFacade.ConnectWithToken("EAAUm6cZC4eUEBQTAa3rRgO39UZCIJLeD9OpF5SYAevqSaFI16sfjT6JznpAUbyX5Soyj4Uv2ZBRkesoHO9omNcJ3KSYPZCExgaKrIprACUMIVnhiHzT5a46zbdC2VkvZC04n1ZARj8WmvOCYyuIdmRZBNjtWZCFJrbjFoms5t3sU8G9dO1xDCYH7kkfU67heIUZCFDIuTtL0CzF2JUHBpRpwPdXYilOJW811z3C5fY9TOyBiUwZAqx4ZAV6YS5ZBBtYKdsb7");

                afterLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed");
            }
        }

        private void afterLogin()
        {
            buttonLogin.Text = $"Logged in as {m_FacebookFacade.GetUserName()}";
            buttonLogin.BackColor = Color.LightGreen;

            string profileUrl = m_FacebookFacade.GetUserProfileImageUrl();
            if (!string.IsNullOrEmpty(profileUrl))
            {
                pictureBoxProfile.ImageLocation = profileUrl;
                pictureBoxMainTabLogedInUser.ImageLocation = profileUrl;
            }

            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
            vibeShifter1.LoggedInUser = m_FacebookFacade.LoggedInUser;
            vibeShifter1.AccessToken = m_FacebookFacade.AccessToken;

            if (!tabControl1.TabPages.Contains(m_MainTab))
            {
                tabControl1.TabPages.Add(m_MainTab);
            }

            tabControl1.SelectedTab = m_MainTab;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_FacebookFacade.Logout();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private void listBoxMainTabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_OnMainSelectionChanged == null || listBoxMainTab.SelectedItems.Count != 1)
            {
                return;
            }

            m_OnMainSelectionChanged(listBoxMainTab.SelectedItem);
        }

        private void handleMusicArtistSelected(object obj)
        {
            FacebookContentDisplayer displayer = FacebookContentDisplayer.Create("music", this);
            displayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
            m_OnMainSelectionChanged = displayer.GetSelectionHandler();
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            FacebookContentDisplayer displayer = FacebookContentDisplayer.Create("posts", this);
            displayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
            m_OnMainSelectionChanged = displayer.GetSelectionHandler();
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            FacebookContentDisplayer displayer = FacebookContentDisplayer.Create("albums", this);
            displayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
            m_OnMainSelectionChanged = displayer.GetSelectionHandler();
        }

        private void buttonEvent_Click(object sender, EventArgs e)
        {
            FacebookContentDisplayer displayer = FacebookContentDisplayer.Create("events", this);
            displayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
            m_OnMainSelectionChanged = displayer.GetSelectionHandler();
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            FacebookContentDisplayer displayer = FacebookContentDisplayer.Create("groups", this);
            displayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
            m_OnMainSelectionChanged = displayer.GetSelectionHandler();
        }

        private void buttonFavTeams_Click(object sender, EventArgs e)
        {
            FacebookContentDisplayer displayer = FacebookContentDisplayer.Create("teams", this);
            displayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
            m_OnMainSelectionChanged = displayer.GetSelectionHandler();
        }

        private void buttonLikedPaged_Click(object sender, EventArgs e)
        {
            FacebookContentDisplayer displayer = FacebookContentDisplayer.Create("pages", this);
            displayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
            m_OnMainSelectionChanged = displayer.GetSelectionHandler();
        }

        private void buttonFavMusic_Click(object sender, EventArgs e)
        {
            FacebookContentDisplayer displayer = FacebookContentDisplayer.Create("music", this);
            displayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
            m_OnMainSelectionChanged = displayer.GetSelectionHandler();
        }

        private void buttonActivity_Click(object sender, EventArgs e)
        {
            if (!m_FacebookFacade.IsLoggedIn)
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

            activityTabView.SetLoggedInUser(m_FacebookFacade.LoggedInUser);

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
            makePictureCircular(pictureBoxMainTabLogedInUser);

            pictureBoxMainTab.Width = (int)(freeSpace * 0.8);
            pictureBoxMainTab.Height = pictureBoxMainTab.Width;
            pictureBoxMainTab.Left = leftAfterListBox + (freeSpace - pictureBoxMainTab.Width) / 2;
            pictureBoxMainTab.Top = pictureBoxMainTabLogedInUser.Bottom + (int)(0.5 * (splitContainer1.Panel2.ClientSize.Height - pictureBoxMainTabLogedInUser.Bottom - pictureBoxMainTab.Height));
        }

        private void makePictureCircular(PictureBox pb)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pb.Width, pb.Height);
            pb.Region = new Region(path);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            m_MainTab = tabPage2;
            tabControl1.TabPages.Remove(tabPage2);

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

        public void LoadImageToPictureBox(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                pictureBoxMainTab.LoadAsync(url);
            }
        }
    }
}
