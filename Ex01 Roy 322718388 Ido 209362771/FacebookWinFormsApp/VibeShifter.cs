using Facebook;
using FacebookWrapper.ObjectModel;
using FacebookWrapper.ObjectModel;
using Newtonsoft.Json; // Ensure "Newtonsoft.Json" is installed via NuGet
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BasicFacebookFeatures
{
    public partial class VibeShifter : UserControl
    {
        private const string k_MakeWebhookUrl = "https://hook.eu2.make.com/4749dpm5svcvbvodicxijf2eqojwusx6";

        // Injected from FormMain after login
        public User LoggedInUser { get; set; }
        public string AccessToken { get; set; }

        public VibeShifter()
        {
            InitializeComponent();
            comboBoxStyles.SelectedIndex = 0;
        }

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

            if (selectedStyle.Contains("Original"))
            {
                textBoxGeneratedText.Text = originalText;
                buttonPostToFb.Enabled = true;
                return; 
            }

            // UI Feedback
            buttonGeneratePost.Text = "Processing......";
            buttonGeneratePost.Enabled = false;
            textBoxGeneratedText.Text = "Thinking....... ";

            try
            {
                var dataPayload = new
                {
                    text = originalText,
                    style = selectedStyle
                };

                string jsonContent = JsonConvert.SerializeObject(dataPayload);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(k_MakeWebhookUrl, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string resultText = await response.Content.ReadAsStringAsync();

                        // Cleanup: Trim quotes if the response is a JSON string
                        textBoxGeneratedText.Text = resultText.Trim('"');

                        buttonPostToFb.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show($"Error from Make: {response.ReasonPhrase}");
                        textBoxGeneratedText.Text = "Error occurred.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
                textBoxGeneratedText.Text = "Error.";
            }
            finally
            {
                // Reset UI state
                buttonGeneratePost.Text = "Make it Cool!";
                buttonGeneratePost.Enabled = true;
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

            // Validation: Ensure we have the AccessToken injected from FormMain
            if (string.IsNullOrEmpty(AccessToken))
            {
                MessageBox.Show("Error: Access Token is missing. Please login again.");
                return;
            }

            try
            {
                // FIX: Use FacebookClient directly to bypass the broken wrapper method
                // This avoids the "OAuthException - #2500" error
                var fbClient = new FacebookClient(AccessToken);

                // API call to post on the user's feed
                fbClient.Post("me/feed", new { message = textToPost });
                Status postedStatus = LoggedInUser.PostStatus(textToPost);
                MessageBox.Show("Status Posted Successfully!\npost ID: " + postedStatus.Id);

                // UI Cleanup
                textBoxOriginalText.Clear();
                textBoxGeneratedText.Clear();
                buttonPostToFb.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Facebook Error: " + ex.Message);
            }
        }

        // Handles dynamic width adjustment when opening the dropdown
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
