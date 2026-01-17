using Facebook;
using FacebookWrapper.ObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicFacebookFeatures.Builders;
using BasicFacebookFeatures.Forms;
using System.Drawing;

namespace BasicFacebookFeatures
{
    public partial class VibeShifter : UserControl
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
                    Image img = loadImageWithMemoryManagement(m_SelectedImagePaths[i]);
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

            // Add to both UI state and builder
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
                // Create panel for each tag
                Panel tagPanel = new Panel()
                {
                    Width = 120,
                    Height = 20,
                    BackColor = Color.CornflowerBlue,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(3)
                };

                // Create Tag label
                Label tagLabel = new Label()
                {
                    Text = tag,
                    ForeColor = Color.White,
                    Font = new Font("Microsoft Sans Serif", 9F),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(5, 0, 20, 0)
                };

                // Create Remove button (X)
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

                // Merge tagLabel and removeButton for closure
                string currentTag = tag;
                removeButton.Click += (s, e) => removeTag(currentTag);

                tagPanel.Controls.Add(tagLabel);
                tagPanel.Controls.Add(removeButton);
                flowLayoutPanelTags.Controls.Add(tagPanel);
            }
        }

        // ========== IMAGE HELPERS (code wouldn't let us load regular images) ==========
        private static Image loadImageWithMemoryManagement(string i_ImagePath)
        {
            if (string.IsNullOrEmpty(i_ImagePath) || !File.Exists(i_ImagePath))
            {
                return null;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(i_ImagePath);
                long fileSizeInBytes = fileInfo.Length;
                const long k_MaxSizeInBytes = 5 * 1024 * 1024;

                if (fileSizeInBytes > k_MaxSizeInBytes)
                {
                    MessageBox.Show($"Image file size ({fileSizeInBytes / (1024 * 1024)}MB) is large. Resizing for preview...", "Large File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                using (FileStream fileStream = new FileStream(i_ImagePath, FileMode.Open, FileAccess.Read))
                {
                    Image originalImage = Image.FromStream(fileStream);

                    if (originalImage.Width > 800 || originalImage.Height > 800)
                    {
                        Image resizedImage = resizeImage(originalImage, 100, 100);
                        originalImage.Dispose();
                        return resizedImage;
                    }

                    return originalImage;
                }
            }
            catch (OutOfMemoryException)
            {
                throw new OutOfMemoryException("Image is too large to load.");
            }
        }

        private static Image resizeImage(Image i_Image, int i_MaxWidth, int i_MaxHeight)
        {
            try
            {
                double ratioX = (double)i_MaxWidth / i_Image.Width;
                double ratioY = (double)i_MaxHeight / i_Image.Height;
                double ratio = Math.Min(ratioX, ratioY);

                int newWidth = (int)(i_Image.Width * ratio);
                int newHeight = (int)(i_Image.Height * ratio);

                Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);
                Graphics graphics = Graphics.FromImage(resizedBitmap);

                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(i_Image, 0, 0, newWidth, newHeight);

                graphics.Dispose();

                return resizedBitmap;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to resize image: {ex.Message}");
            }
        }
        // ====================

        private async void buttonGeneratePost_Click(object sender, EventArgs e)
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

            buttonGeneratePost.Text = "Processing......";
            buttonGeneratePost.Enabled = false;
            textBoxGeneratedText.Text = "Thinking....... ";

            try
            {
                string transformedText = await transformTextAsync(originalText, selectedStyle);
                textBoxGeneratedText.Text = transformedText;
                buildPostWithCurrentState(originalText, selectedStyle, transformedText);
                buttonPostToFb.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transformation Error: " + ex.Message);
                textBoxGeneratedText.Text = "Error.";
                buttonPostToFb.Enabled = false;
            }
            finally
            {
                buttonGeneratePost.Text = "Make it Cool!";
                buttonGeneratePost.Enabled = true;
            }
        }

        private void buildPostWithCurrentState(string i_OriginalText, string i_Style, string i_TransformedText)
        {
            m_PostBuilder.Reset()
                .WithContent(i_OriginalText)
                .WithStyle(i_Style)
                .SetTransformedContent(i_TransformedText)
                .WithAuthor(LoggedInUser)
                .WithPrivacy((ePrivacyLevel)comboBoxPrivacy.SelectedIndex);
        }

        private async Task<string> transformTextAsync(string i_Text, string i_Style)
        {
            if (i_Style.Contains("Original"))
            {
                return i_Text;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(i_Text))
                {
                    throw new ArgumentException("Text cannot be empty");
                }

                if (string.IsNullOrWhiteSpace(i_Style))
                {
                    throw new ArgumentException("Style cannot be empty");
                }

                var dataPayload = new { text = i_Text, style = i_Style };
                string jsonContent = JsonConvert.SerializeObject(dataPayload);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("User-Agent", "VibeShifter-App/1.0");

                    HttpResponseMessage response = await client.PostAsync(k_MakeWebhookUrl, httpContent);
                    string responseContent = await response.Content.ReadAsStringAsync();

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
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Request timeout - Make.com service took too long to respond: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"JSON parsing error: {ex.Message}", ex);
            }
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

            (bool success, FacebookPost post, string error) = m_PostBuilder.TryBuild();

            if (!success)
            {
                MessageBox.Show($"Cannot post:\n{error}");
                return;
            }

            postToFacebook(post);
        }

        private void postToFacebook(FacebookPost i_Post)
        {
            try
            {
                FacebookClient fbClient = new FacebookClient(AccessToken);
                fbClient.Post("me/feed", new { message = i_Post.Content });
                Status postedStatus = LoggedInUser.PostStatus(i_Post.Content);

                string imageInfo = i_Post.ImagePaths.Count > 0
                    ? $"\nImages: {i_Post.ImagePaths.Count}"
                    : "";

                string tagInfo = i_Post.Tags.Count > 0
                    ? $"\nTags: {string.Join(", ", i_Post.Tags)}"
                    : "";

                MessageBox.Show(
                    $"Status Posted Successfully!\nPost ID: {postedStatus.Id}\n" +
                    $"Type: {i_Post.PostType}\n" +
                    $"Privacy: {i_Post.Privacy}" +
                    imageInfo +
                    tagInfo,
                    "Success"
                );

                resetUiAfterSuccessfulPost();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Facebook API Error: {ex.Message}\n\nShowing mock preview of your post...", "Post Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showMockPostDisplay(i_Post);
            }
        }

        private void resetUiAfterSuccessfulPost()
        {
            textBoxOriginalText.Clear();
            textBoxGeneratedText.Clear();
            buttonPostToFb.Enabled = false;
            ClearImages();
            ClearTags();
            m_PostBuilder.Reset();
        }

        private void showMockPostDisplay(FacebookPost i_Post)
        {
            using (MockPostDisplay mockDisplay = new MockPostDisplay(i_Post))
            {
                mockDisplay.ShowDialog(this.FindForm());
            }
        }

        public void AddImageToPost(string i_ImagePath)
        {
            if (File.Exists(i_ImagePath))
            {
                if (!m_SelectedImagePaths.Contains(i_ImagePath) && m_SelectedImagePaths.Count < k_MaxImages)
                {
                    addImageToBuilder(i_ImagePath);
                    updateImagePreviews();
                }
                else if (m_SelectedImagePaths.Count >= k_MaxImages)
                {
                    MessageBox.Show($"Maximum {k_MaxImages} images allowed.", "Max Images", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show($"Image not found: {i_ImagePath}");
            }
        }

        public void SetPostPrivacy(ePrivacyLevel i_PrivacyLevel)
        {
            m_PostBuilder.WithPrivacy(i_PrivacyLevel);
            comboBoxPrivacy.SelectedIndex = (int)i_PrivacyLevel;
        }

        public void AddPostTags(params string[] i_Tags)
        {
            foreach (string tag in i_Tags)
            {
                if (!m_SelectedTags.Contains(tag) && m_SelectedTags.Count < k_MaxTags)
                {
                    addTagToBuilder(tag);
                }
            }
            updateTagDisplay();
        }

        public List<string> GetValidationErrors()
        {
            return m_PostBuilder.GetValidationErrors();
        }

        public void ClearImages()
        {
            // Dispose images
            if (pictureBoxPreview1.Image != null)
            {
                pictureBoxPreview1.Image.Dispose();
                pictureBoxPreview1.Image = null;
            }
            if (pictureBoxPreview2.Image != null)
            {
                pictureBoxPreview2.Image.Dispose();
                pictureBoxPreview2.Image = null;
            }
            if (pictureBoxPreview3.Image != null)
            {
                pictureBoxPreview3.Image.Dispose();
                pictureBoxPreview3.Image = null;
            }

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

        // Making style comboBox's width auto adjust
        private void comboBoxStyles_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int dropDownWidth = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;

            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                                         ? SystemInformation.VerticalScrollBarWidth : 0;

            foreach (object s in senderComboBox.Items)
            {
                int newWidth = (int)g.MeasureString(s.ToString(), font).Width + vertScrollBarWidth;

                if (dropDownWidth < newWidth)
                {
                    dropDownWidth = newWidth;
                }
            }

            senderComboBox.DropDownWidth = dropDownWidth;
        }
    }
}