using BasicFacebookFeatures;
using BasicFacebookFeatures;
using BasicFacebookFeatures.Builders;
using BasicFacebookFeatures.ContentDisplayers;
using BasicFacebookFeatures.Facades;
using BasicFacebookFeatures.Observers;
using BasicFacebookFeatures.Strategies;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private TabPage m_PostingTab;
        private TabPage m_MainTab;
        private TabPage m_PhotoEditorTab;
        private FacebookFacade m_FacebookFacade;

        private BasicFacebookFeatures.Decorators.IPhoto m_CurrentPhoto;
        private Action<object> m_OnMainSelectionChanged;
        private FacebookContentDisplayer m_CurrentDisplayer;

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            m_FacebookFacade = FacebookFacade.Instance;
            hidePostEditorControls();

            // ========== Observer Pattern: Register Observers ==========
            // Register VibeShifter (AI Posting tab) as an observer
            m_FacebookFacade.AttachObserver(vibeShifter1);
            // =========================================================
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

            // ========== Observer Pattern: Automatic Updates ==========
            // Login state updates are now handled automatically
            // by the Observer Pattern through FacebookFacade.NotifyObservers()
            // The following manual assignments are NO LONGER NEEDED:
            // vibeShifter1.LoggedInUser = m_FacebookFacade.LoggedInUser;
            // vibeShifter1.AccessToken = m_FacebookFacade.AccessToken;
            // =========================================================

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

        private void showPostEditorControls()
        {
            if (textBoxPostEdit != null)
            {
                textBoxPostEdit.Visible = true;
            }

            if (buttonChangePost != null)
            {
                buttonChangePost.Visible = true;
            }
        }

        private void hidePostEditorControls()
        {
            if (labelAIPost != null)
            {
                labelAIPost.Visible = false;
            }

            if (buttonChangePost != null)
            {
                buttonChangePost.Visible = false;
            }

            if (textBoxPostEdit != null)
            {
                textBoxPostEdit.Visible = false;
            }

            if (textBoxPostEdit != null)
            {
                textBoxPostEdit.Visible = false;
                textBoxPostEdit.Clear();
                textBoxPostEdit.DataBindings.Clear();
            }
        }

        private void loadContentCategory(string i_ContentType, bool i_ShowTextEditor = false)
        {
            m_CurrentDisplayer = FacebookContentDisplayer.Create(i_ContentType, this);

            if (i_ShowTextEditor)
            {
                m_CurrentDisplayer.DisplayContent(listBoxMainTab, textBoxPostEdit, m_FacebookFacade);
                showPostEditorControls();
            }
            else
            {
                m_CurrentDisplayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
                hidePostEditorControls();
            }

            m_OnMainSelectionChanged = m_CurrentDisplayer.GetSelectionHandler();
            resetSortStrategyComboBox();
        }

        private void resetSortStrategyComboBox()
        {
            comboBoxSortStrategy.SelectedIndex = 0;
        }

        private void buttonPosts_Click(object sender, EventArgs e)
            => loadContentCategory("posts", i_ShowTextEditor: true);

        private void buttonAlbums_Click(object sender, EventArgs e)
            => loadContentCategory("albums");

        private void buttonEvent_Click(object sender, EventArgs e)
            => loadContentCategory("events");

        private void buttonGroups_Click(object sender, EventArgs e)
            => loadContentCategory("groups");

        private void buttonFavTeams_Click(object sender, EventArgs e)
            => loadContentCategory("teams");

        private void buttonLikedPaged_Click(object sender, EventArgs e)
            => loadContentCategory("pages");

        private void buttonFavMusic_Click(object sender, EventArgs e)
            => loadContentCategory("music");

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

            // ========== Observer Pattern: Register and Initialize ==========
            // Attach dynamically created chartActivity as observer
            m_FacebookFacade.AttachObserver(activityTabView);
            
            // CRUCIAL: Manually initialize the observer with current login state
            // since it wasn't registered when the user logged in
            activityTabView.UpdateLoginState(m_FacebookFacade.LoggedInUser, m_FacebookFacade.AccessToken);
            // ===============================================================

            activityPage.Controls.Add(activityTabView);
            tabControl1.TabPages.Add(activityPage);
            tabControl1.SelectedTab = activityPage;
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            updateMainLayout();
        }

        private void updateMainLayout()
        {
            listBoxMainTab.Left = (int)(buttonPosts.Left);
            listBoxMainTab.Width = (int)(this.ClientSize.Width * 0.5);
            listBoxMainTab.Height = splitContainer1.Panel1.ClientSize.Height - listBoxMainTab.Top;
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
            pictureBoxMainTab.Top = pictureBoxMainTabLogedInUser.Bottom + (int)(0.2 * (splitContainer1.Panel2.ClientSize.Height - pictureBoxMainTabLogedInUser.Bottom - pictureBoxMainTab.Height));

            textBoxPostEdit.Width = pictureBoxMainTab.Width;
            textBoxPostEdit.Left = pictureBoxMainTab.Left;
            textBoxPostEdit.Top = pictureBoxMainTab.Top;
            textBoxPostEdit.Height = pictureBoxMainTab.Height;

            buttonChangePost.Width = pictureBoxMainTab.Width;
            buttonChangePost.Left = pictureBoxMainTab.Left;
            buttonChangePost.Top = textBoxPostEdit.Bottom + 18;
        }

        private void makePictureCircular(PictureBox i_Pb)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, i_Pb.Width, i_Pb.Height);
            i_Pb.Region = new Region(path);
            i_Pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            m_MainTab = tabPage2;
            tabControl1.TabPages.Remove(tabPage2);

            m_PostingTab = tabPage3;
            tabControl1.TabPages.Remove(tabPage3);

            m_PhotoEditorTab = tabPhotoEditor;
            tabControl1.TabPages.Remove(tabPhotoEditor);

            listBoxMainTab.IntegralHeight = true;
            listBoxMainTab.ItemHeight = 18;

            updateMainLayout();
        }

        private void buttonPostWithAI_Click(object sender, EventArgs e)
        {
            if (!tabControl1.TabPages.Contains(m_PostingTab))
            {
                tabControl1.TabPages.Add(m_PostingTab);
            }

            tabControl1.SelectedTab = m_PostingTab;
        }

        public void LoadImageToPictureBox(string i_Url)
        {
            if (!string.IsNullOrEmpty(i_Url))
            {
                pictureBoxMainTab.LoadAsync(i_Url);
            }
        }

        private void buttonChangePost_Click(object sender, EventArgs e)
        {
            var binding = textBoxPostEdit.DataBindings["Text"];

            if (binding != null)
            {
                binding.WriteValue();
                listBoxMainTab.Refresh();
                MessageBox.Show("Post updated!");
            }
        }

        private void comboBoxSortStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_CurrentDisplayer == null)
            {
                MessageBox.Show("Please select a content category first.");
                return;
            }

            switch (comboBoxSortStrategy.SelectedIndex)
            {
                case 0: // No Sort
                    m_CurrentDisplayer.SortStrategy = new NoSortStrategy();
                    break;
                case 1: // Ascending (A-Z)
                    m_CurrentDisplayer.SortStrategy = new AscendingSortStrategy();
                    break;
                case 2: // Descending (Z-A)
                    m_CurrentDisplayer.SortStrategy = new DescendingSortStrategy();
                    break;
                default:
                    m_CurrentDisplayer.SortStrategy = new NoSortStrategy();
                    break;
            }

            refreshCurrentDisplay();
        }

        private void refreshCurrentDisplay()
        {
            if (m_CurrentDisplayer == null)
            {
                return;
            }

            try
            {
                if (listBoxMainTab.DataBindings.Count > 0 || listBoxMainTab.Items.Count > 0)
                {
                    if (textBoxPostEdit.Visible)
                    {
                        m_CurrentDisplayer.DisplayContent(listBoxMainTab, textBoxPostEdit, m_FacebookFacade);
                    }
                    else
                    {
                        m_CurrentDisplayer.DisplayContent(listBoxMainTab, m_FacebookFacade);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing display: {ex.Message}");
            }
        }

        private void buttonPhotoEditor_Click(object sender, EventArgs e)
        {
            if (!tabControl1.TabPages.Contains(m_PhotoEditorTab))
            {
                tabControl1.TabPages.Add(m_PhotoEditorTab);
            }

            tabControl1.SelectedTab = m_PhotoEditorTab;
            loadAlbumsToPhotoEditor();
        }

        private void loadAlbumsToPhotoEditor()
        {
            listBoxEditorAlbums.Items.Clear();

            listBoxEditorAlbums.DisplayMember = "Name";

            try
            {
                foreach (FacebookWrapper.ObjectModel.Album album in m_FacebookFacade.LoggedInUser.Albums)
                {
                    listBoxEditorAlbums.Items.Add(album);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load albums: " + ex.Message);
            }
        }

        private void listBoxEditorAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEditorAlbums.SelectedItem is FacebookWrapper.ObjectModel.Album selectedAlbum)
            {
                if (selectedAlbum.PictureAlbumURL != null)
                {
                    pictureBoxEditor.Load(selectedAlbum.PictureAlbumURL);

                    m_CurrentPhoto = new BasicFacebookFeatures.Decorators.FacebookPhoto(pictureBoxEditor.Image);

                    pictureBoxMainTab.Image = pictureBoxEditor.Image;
                }
            }
        }

        private void buttonFilterGrayscale_Click(object sender, EventArgs e)
        {
            if (m_CurrentPhoto != null)
            {
                m_CurrentPhoto = new BasicFacebookFeatures.Decorators.GrayscaleFilterDecorator(m_CurrentPhoto);

                pictureBoxEditor.Image = m_CurrentPhoto.GetImage();
                pictureBoxMainTab.Image = pictureBoxEditor.Image;
            }
        }

        private void buttonFilterWatermark_Click(object sender, EventArgs e)
        {
            if (m_CurrentPhoto != null)
            {
                m_CurrentPhoto = new BasicFacebookFeatures.Decorators.WatermarkFilterDecorator(m_CurrentPhoto);

                pictureBoxEditor.Image = m_CurrentPhoto.GetImage();
                pictureBoxMainTab.Image = pictureBoxEditor.Image;
            }
        }
    }
}
