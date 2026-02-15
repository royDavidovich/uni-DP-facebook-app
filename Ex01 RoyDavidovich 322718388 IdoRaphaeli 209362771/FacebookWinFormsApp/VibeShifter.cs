using Facebook;
using FacebookWrapper.ObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BasicFacebookFeatures.Builders;
using BasicFacebookFeatures.Forms;
using BasicFacebookFeatures.Observers;
using System.Drawing;
using BasicFacebookFeatures.Utilities;

namespace BasicFacebookFeatures
{
    /// <summary>
    /// VibeShifter UserControl for AI-powered post creation
    /// Implements ILoginObserver to handle automatic login state updates
    /// </summary>
    public partial class VibeShifter : UserControl, ILoginObserver
    {
        private const string k_MakeWebhookUrl = "https://hook.eu2.make.com/4749dpm5svcvbvodicxijf2eqojwusx6";
        private FacebookPostBuilder m_PostBuilder;
        private const int k_MaxImages = 3;
        private const int k_MaxTags = 7;
        private List<string> m_SelectedImagePaths;
        private List<string> m_SelectedTags;

        // Injected from FormMain after login
        public User LoggedInUser { get; set; }
        public string AccessToken { get; set; }

        public VibeShifter()
        {
            InitializeComponent();
            m_PostBuilder = new FacebookPostBuilder();
            m_SelectedImagePaths = new List<string>();
            m_SelectedTags = new List<string>();
            comboBoxStyles.SelectedIndex = 0;
            comboBoxPrivacy.SelectedIndex = 0;
            initializePostOptions();
            setupImagePreviewClickHandlers();
        }

        // ========== Observer Pattern Implementation ==========

        /// <summary>
        /// Observer method: Called when login state changes
        /// Updates the user and access token automatically
        /// </summary>
        public void UpdateLoginState(User i_LoggedInUser, string i_AccessToken)
        {
            LoggedInUser = i_LoggedInUser;
            AccessToken = i_AccessToken;
        }

        // ========== Existing Code ==========

        private void setupImagePreviewClickHandlers()
        {
            pictureBoxPreview1.Click += (s, e) => deleteImageAtIndex(0);
            pictureBoxPreview2.Click += (s, e) => deleteImageAtIndex(1);
            pictureBoxPreview3.Click += (s, e) => deleteImageAtIndex(2);

            pictureBoxPreview1.Cursor = Cursors.Hand;
            pictureBoxPreview2.Cursor = Cursors.Hand;
            pictureBoxPreview3.Cursor = Cursors.Hand;
        }

        private void initializePostOptions()
        {
            updatePrivacyLevel();
        }

        private void comboBoxPrivacy_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePrivacyLevel();
        }

        private void updatePrivacyLevel()
        {
            ePrivacyLevel selectedPrivacy = (ePrivacyLevel)comboBoxPrivacy.SelectedIndex;
            m_PostBuilder.WithPrivacy(selectedPrivacy);
        }

        private void buttonAddPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                openFileDialog.Title = $"Select Images to Add to Your Post (Max {k_MaxImages})";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int imagesToAdd = Math.Min(openFileDialog.FileNames.Length, k_MaxImages - m_SelectedImagePaths.Count);

                    if (imagesToAdd == 0)
                    {
                        MessageBox.Show($"You already have the maximum of {k_MaxImages} images selected.", "Max Images Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    for (int i = 0; i < imagesToAdd; i++)
                    {
                        string filePath = openFileDialog.FileNames[i];

                        if (File.Exists(filePath) && !m_SelectedImagePaths.Contains(filePath))
                        {
                            addImageToBuilder(filePath);
                        }
                    }

                    updateImagePreviews();

                    if (imagesToAdd < openFileDialog.FileNames.Length)
                    {
                        MessageBox.Show($"Only {imagesToAdd} image(s) were added. Maximum {k_MaxImages} images allowed.", "Partial Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void addImageToBuilder(string i_ImagePath)
        {
            m_SelectedImagePaths.Add(i_ImagePath);
            m_PostBuilder.AddImage(i_ImagePath);
        }

        private void deleteImageAtIndex(int i_Index)
        {
            if (i_Index >= 0 && i_Index < m_SelectedImagePaths.Count)
            {
                string imagePath = m_SelectedImagePaths[i_Index];
                m_SelectedImagePaths.RemoveAt(i_Index);
                m_PostBuilder.RemoveImage(imagePath);
                updateImagePreviews();
            }
        }

        private void updateImagePreviews()
        {
            pictureBoxPreview1.Image = null;
            pictureBoxPreview2.Image = null;
            pictureBoxPreview3.Image = null;
            pictureBoxPreview1.Visible = false;
            pictureBoxPreview2.Visible = false;
            pictureBoxPreview3.Visible = false;
            
            PictureBox[] previewBoxes = { pictureBoxPreview1, pictureBoxPreview2, pictureBoxPreview3 };

            for (int i = 0; i < m_SelectedImagePaths.Count && i < k_MaxImages; i++)
            {
                try
                {
                    Image img = ImageHelper.LoadImageWithMemoryManagement(m_SelectedImagePaths[i]);

                    previewBoxes[i].Image = img;
                    previewBoxes[i].Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not load image preview: {ex.Message}");
                }
            }

            updateImageLabelByNumberOfImageSelected();
        }

        private void updateImageLabelByNumberOfImageSelected()
        {
            if (m_SelectedImagePaths.Count == 0)
            {
                labelSelectedImages.Text = "No images selected";
                labelSelectedImages.ForeColor = Color.LightGray;
            }
            else
            {
                labelSelectedImages.Text = $"{m_SelectedImagePaths.Count} image(s) selected";
                labelSelectedImages.ForeColor = Color.LightGreen;
            }
        }

        private void textBoxTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                addTag();
            }
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            addTag();
        }

        private void addTag()
        {
            string tag = textBoxTag.Text.Trim();

            if (string.IsNullOrWhiteSpace(tag))
            {
                MessageBox.Show("Please enter a tag.", "Empty Tag", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m_SelectedTags.Count >= k_MaxTags)
            {
                MessageBox.Show($"Maximum {k_MaxTags} tags allowed.", "Max Tags Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (m_SelectedTags.Contains(tag))
            {
                MessageBox.Show("This tag already exists.", "Duplicate Tag", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            addTagToBuilder(tag);
            textBoxTag.Clear();
            updateTagDisplay();
        }

        private void addTagToBuilder(string i_Tag)
        {
            m_SelectedTags.Add(i_Tag);
            m_PostBuilder.AddTag(i_Tag);
        }

        private void removeTag(string i_Tag)
        {
            if (m_SelectedTags.Contains(i_Tag))
            {
                m_SelectedTags.Remove(i_Tag);
                m_PostBuilder.RemoveTag(i_Tag);
                updateTagDisplay();
            }
        }

        private void updateTagDisplay()
        {
            flowLayoutPanelTags.Controls.Clear();

            foreach (string tag in m_SelectedTags)
            {
                Panel tagPanel = new Panel()
                {
                    Width = 120,
                    Height = 20,
                    BackColor = Color.CornflowerBlue,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(3)
                };

                Label tagLabel = new Label()
                {
                    Text = tag,
                    ForeColor = Color.White,
                    Font = new Font("Microsoft Sans Serif", 9F),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(5, 0, 20, 0)
                };

                Button removeButton = new Button()
                {
                    Text = "X",
                    Font = new Font("Microsoft Sans Serif", 6F, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.Crimson,
                    Dock = DockStyle.Right,
                    Width = 20,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };

                string currentTag = tag;

                removeButton.Click += (s, e) => removeTag(currentTag);
                tagPanel.Controls.Add(tagLabel);
                tagPanel.Controls.Add(removeButton);
                flowLayoutPanelTags.Controls.Add(tagPanel);
            }
        }

        private void buttonGeneratePost_Click(object sender, EventArgs e)
        {
            string originalText = textBoxOriginalText.Text;

            if (string.IsNullOrWhiteSpace(originalText))
            {
                MessageBox.Show("Please enter some text first!");

                return;
            }

            if (comboBoxStyles.SelectedItem == null)
            {
                MessageBox.Show("Please select a style!");

                return;
            }

            string selectedStyle = comboBoxStyles.SelectedItem.ToString();

            disableActionButtons();
            updateUIOnMainThread(() =>
            {
                buttonGeneratePost.Text = "Processing......";
                textBoxGeneratedText.Text = "Thinking....... ";
            });

            Thread aiTextTransformationThread = new Thread(() =>
            {
                transformPostInBackground(originalText, selectedStyle);
            });

            aiTextTransformationThread.IsBackground = true;
            aiTextTransformationThread.Start();
        }

        private void transformPostInBackground(string i_OriginalText, string i_Style)
        {
            try
            {
                string transformedText = transformTextBlocking(i_OriginalText, i_Style);

                buildPostWithCurrentState(i_OriginalText, i_Style, transformedText);
                updateUIOnMainThread(() =>
                {
                    textBoxGeneratedText.Text = transformedText;
                    buttonPostToFb.Enabled = true;
                    buttonGeneratePost.Text = "Make it Cool!";
                    enableActionButtons();
                });
            }
            catch (Exception ex)
            {
                updateUIOnMainThread(() =>
                {
                    MessageBox.Show("Transformation Error: " + ex.Message);
                    textBoxGeneratedText.Text = "Error.";
                    buttonPostToFb.Enabled = false;
                    buttonGeneratePost.Text = "Make it Cool!";
                    enableActionButtons();
                });
            }
        }

        private string transformTextBlocking(string i_Text, string i_Style)
        {
            if (i_Style.Contains("Original"))
            {
                return i_Text;
            }

            if (string.IsNullOrWhiteSpace(i_Text))
            {
                throw new ArgumentException("Text cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(i_Style))
            {
                throw new ArgumentException("Style cannot be empty");
            }

            try
            {
                var dataPayload = new { text = i_Text, style = i_Style };
                string jsonContent = JsonConvert.SerializeObject(dataPayload);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("User-Agent", "VibeShifter-App/1.0");

                    HttpResponseMessage response = client.PostAsync(k_MakeWebhookUrl, httpContent).Result;
                    string responseContent = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string resultText = responseContent;

                        if (resultText.StartsWith("\"") && resultText.EndsWith("\""))
                        {
                            resultText = resultText.Trim('"');
                        }

                        resultText = System.Text.RegularExpressions.Regex.Unescape(resultText);
                        if (string.IsNullOrWhiteSpace(resultText))
                        {
                            throw new Exception("Webhook returned empty response");
                        }

                        return resultText;
                    }
                    else
                    {
                        string errorDetails = $"Status: {response.StatusCode}\n" +
                                            $"Reason: {response.ReasonPhrase}\n" +
                                            $"Response: {responseContent.Substring(0, Math.Min(200, responseContent.Length))}";

                        throw new Exception($"Transform service failed:\n{errorDetails}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Network error connecting to Make.com: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Transformation failed: {ex.Message}", ex);
            }
        }

        private void updateUIOnMainThread(Action i_UiAction)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(i_UiAction);
            }
            else
            {
                i_UiAction();
            }
        }

        private void disableActionButtons()
        {
            updateUIOnMainThread(() =>
            {
                buttonGeneratePost.Enabled = false;
                buttonPostToFb.Enabled = false;
            });
        }

        private void enableActionButtons()
        {
            updateUIOnMainThread(() =>
            {
                buttonGeneratePost.Enabled = true;
            });
        }

        private void buildPostWithCurrentState(string i_OriginalText, string i_Style, string i_TransformedText)
        {
            m_PostBuilder.Reset()
                .WithContent(i_OriginalText)
                .WithStyle(i_Style)
                .SetTransformedContent(i_TransformedText)
                .WithAuthor(LoggedInUser)
                .WithPrivacy((ePrivacyLevel)comboBoxPrivacy.SelectedIndex);

            m_PostBuilder.AddImages(m_SelectedImagePaths);
            m_PostBuilder.AddTags(m_SelectedTags);
        }

        private void buttonPostToFb_Click(object sender, EventArgs e)
        {
            string textToPost = textBoxGeneratedText.Text;

            if (string.IsNullOrWhiteSpace(textToPost) || textToPost == "Error.")
            {
                MessageBox.Show("There is no valid text to post.");
                return;
            }

            if (string.IsNullOrEmpty(AccessToken))
            {
                MessageBox.Show("Error: Access Token is missing. Please login again.");
                return;
            }

            bool success = m_PostBuilder.TryBuild(out FacebookPost post, out string error);

            if (!success)
            {
                MessageBox.Show($"Cannot post:\n{error}");
                return;
            }

            Thread postingThread = new Thread(() =>
            {
                postToFacebookInBackground(post);
            });

            postingThread.IsBackground = true;
            postingThread.Start();
        }

        private void postToFacebookInBackground(FacebookPost i_Post)
        {
            disableActionButtons();
            updateUIOnMainThread(() => { buttonPostToFb.Text = "Posting...."; });

            try
            {
                FacebookClient fbClient = new FacebookClient(AccessToken);

                fbClient.Post("me/feed", new { message = i_Post.Content });
                Status postedStatus = LoggedInUser.PostStatus(i_Post.Content);

                updateUIOnMainThread(() =>
                    {
                        MessageBox.Show("Success! status posted to Facebook");
                        resetUiAfterSuccessfulPost();
                    });
            }
            catch(Exception ex)
            {
                updateUIOnMainThread(() =>
                    {
                        MessageBox.Show(
                            $"Facebook API Error: {ex.Message}\n\nShowing mock preview of your post...",
                            "Post Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        showMockPostDisplay(i_Post);
                        enableActionButtons();
                        buttonPostToFb.Text = "Post to Facebook";
                    });
            }
        }

        private void resetUiAfterSuccessfulPost()
        {
            textBoxOriginalText.Clear();
            textBoxGeneratedText.Clear();
            buttonPostToFb.Enabled = false;
            buttonPostToFb.Text = "Post to Facebook";
            ClearImages();
            ClearTags();
            m_PostBuilder.Reset();
            enableActionButtons();
        }

        private void showMockPostDisplay(FacebookPost i_Post)
        {
            using (MockPostDisplay mockDisplay = new MockPostDisplay(i_Post))
            {
                mockDisplay.ShowDialog(this.FindForm());
            }
        }

        public void ClearImages()
        {
            Image img1 = pictureBoxPreview1.Image;
            ImageHelper.SafeDisposeImage(ref img1);
            pictureBoxPreview1.Image = null;

            Image img2 = pictureBoxPreview2.Image;
            ImageHelper.SafeDisposeImage(ref img2);
            pictureBoxPreview2.Image = null;

            Image img3 = pictureBoxPreview3.Image;
            ImageHelper.SafeDisposeImage(ref img3);
            pictureBoxPreview3.Image = null;

            m_SelectedImagePaths.Clear();
            m_PostBuilder.ClearImages();

            pictureBoxPreview1.Visible = false;
            pictureBoxPreview2.Visible = false;
            pictureBoxPreview3.Visible = false;

            updateImageLabelByNumberOfImageSelected();
        }

        public void ClearTags()
        {
            m_SelectedTags.Clear();
            m_PostBuilder.ClearTags();
            updateTagDisplay();
        }

        private void comboBoxStyles_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int dropDownWidth = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;

            int verticalScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                                         ? SystemInformation.VerticalScrollBarWidth : 0;

            foreach (object s in senderComboBox.Items)
            {
                int newWidth = (int)g.MeasureString(s.ToString(), font).Width + verticalScrollBarWidth;

                if (dropDownWidth < newWidth)
                {
                    dropDownWidth = newWidth;
                }
            }

            senderComboBox.DropDownWidth = dropDownWidth;
        }
    }
}