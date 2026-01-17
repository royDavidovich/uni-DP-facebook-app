using System;
using System.Drawing;
using System.Windows.Forms;
using BasicFacebookFeatures.Builders;

namespace BasicFacebookFeatures.Forms
{
    /// PLEASE NOTE -
    /// this whole class was AI generated to ease our use
    /// because posting isn't available due to project permissions limitations

    /// <summary>
    /// Mock display form simulating how a Facebook post would appear
    /// Uses the app's color palette (MidnightBlue theme)
    /// Fixed: Shows transformed text and up to 3 images in separate PictureBoxes
    /// </summary>
    public partial class MockPostDisplay : Form
    {
        private FacebookPost m_Post;
        private PictureBox[] m_ImageBoxes; // Array to hold 3 image boxes

        // Color palette matching the app
        private static readonly Color MIDNIGHT_BLUE = Color.MidnightBlue;
        private static readonly Color DARK_SLATE_BLUE = Color.DarkSlateBlue;
        private static readonly Color ROYAL_BLUE = Color.RoyalBlue;
        private static readonly Color WHITE = Color.White;
        private static readonly Color LIGHT_GRAY = Color.LightGray;
        private static readonly Color DARK_GRAY = Color.DarkGray;

        public MockPostDisplay(FacebookPost post)
        {
            m_Post = post;
            InitializeComponent();
            m_ImageBoxes = new PictureBox[3]; // Initialize array
            BuildDisplay();
        }

        /// <summary>
        /// Build the mock Facebook post display
        /// </summary>
        private void BuildDisplay()
        {
            this.Text = "Post Preview - Mock Facebook Feed";
            this.BackColor = MIDNIGHT_BLUE;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(550, 700);
            this.Font = new Font("Segoe UI", 9);

            // Main scroll panel
            Panel mainPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = MIDNIGHT_BLUE,
                AutoScroll = true,
                Padding = new Padding(15)
            };

            // Post container (Facebook-like card)
            Panel postCard = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = DARK_SLATE_BLUE,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(12),
                Margin = new Padding(0, 0, 0, 10)
            };

            // Header with user info
            Panel headerPanel = CreateHeaderPanel();
            postCard.Controls.Add(headerPanel);

            // Divider
            Panel divider1 = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = ROYAL_BLUE,
                Margin = new Padding(0, 10, 0, 10)
            };
            postCard.Controls.Add(divider1);

            // Content section
            Panel contentPanel = CreateContentPanel();
            postCard.Controls.Add(contentPanel);

            // Divider before stats
            Panel divider2 = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = ROYAL_BLUE,
                Margin = new Padding(0, 10, 0, 10)
            };
            postCard.Controls.Add(divider2);

            // Stats section
            Panel statsPanel = CreateStatsPanel();
            postCard.Controls.Add(statsPanel);

            // Divider before interactions
            Panel divider3 = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = ROYAL_BLUE,
                Margin = new Padding(0, 5, 0, 5)
            };
            postCard.Controls.Add(divider3);

            // Interaction buttons
            Panel interactionPanel = CreateInteractionPanel();
            postCard.Controls.Add(interactionPanel);

            // Footer with warning
            Panel footerPanel = CreateFooterPanel();

            mainPanel.Controls.Add(footerPanel);
            mainPanel.Controls.Add(postCard);

            this.Controls.Add(mainPanel);
        }

        /// <summary>
        /// Create header with user info and timestamp
        /// </summary>
        private Panel CreateHeaderPanel()
        {
            Panel headerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(0, 0, 0, 10)
            };

            // User name
            Label userLabel = new Label()
            {
                Text = m_Post.Author?.Name ?? "Unknown User",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = WHITE,
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };

            // Time and privacy info
            string privacyDisplay = GetPrivacyLevelDisplay(m_Post.Privacy);
            Label timePrivacyLabel = new Label()
            {
                Text = $"Just now • 🔒 {privacyDisplay}",
                Font = new Font("Segoe UI", 9),
                ForeColor = LIGHT_GRAY,
                Dock = DockStyle.Top,
                AutoSize = true
            };

            headerPanel.Controls.Add(timePrivacyLabel);
            headerPanel.Controls.Add(userLabel);

            return headerPanel;
        }

        /// <summary>
        /// Convert PrivacyLevel enum to user-friendly display string
        /// </summary>
        private static string GetPrivacyLevelDisplay(ePrivacyLevel i_Privacy)
        {
            switch (i_Privacy)
            {
                case ePrivacyLevel.Public:
                    return "Public";
                case ePrivacyLevel.FriendsOnly:
                    return "Friends Only";
                case ePrivacyLevel.Private:
                    return "Private";
                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Create content panel with text and images
        /// Fixed: Shows transformed text and 3 separate image boxes
        /// </summary>
        private Panel CreateContentPanel()
        {
            Panel contentPanel = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0, 0, 0, 10)
            };

            // Main post text - Shows the TRANSFORMED TEXT (FIXED)
            string displayText = !string.IsNullOrEmpty(m_Post.TransformedContent)
                ? m_Post.TransformedContent
                : m_Post.Content;

            Label contentLabel = new Label()
            {
                Text = displayText,
                Font = new Font("Segoe UI", 10),
                ForeColor = WHITE,
                Dock = DockStyle.Top,
                AutoSize = true,
                MaximumSize = new Size(480, 0),
                Margin = new Padding(0, 0, 0, 12)
            };

            contentPanel.Controls.Add(contentLabel);

            // Image preview - Create 3 PictureBoxes and populate them (FIXED)
            if (m_Post.ImagePaths.Count > 0)
            {
                Panel imagesContainer = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = 160,
                    Margin = new Padding(0, 0, 0, 10)
                };

                // Create 3 PictureBoxes side by side
                for (int i = 0; i < 3; i++)
                {
                    PictureBox imagePictureBox = new PictureBox()
                    {
                        Height = 150,
                        Width = 150,
                        BackColor = MIDNIGHT_BLUE,
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(0, 0, 5, 0),
                        Dock = DockStyle.Left
                    };

                    m_ImageBoxes[i] = imagePictureBox;

                    // Load image if it exists in the list
                    if (i < m_Post.ImagePaths.Count)
                    {
                        try
                        {
                            imagePictureBox.ImageLocation = m_Post.ImagePaths[i];
                            imagePictureBox.Visible = true;
                        }
                        catch
                        {
                            imagePictureBox.BackColor = Color.DarkGray;
                            Label placeholderLabel = new Label()
                            {
                                Text = "📷",
                                Font = new Font("Segoe UI", 24),
                                ForeColor = LIGHT_GRAY,
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            imagePictureBox.Controls.Add(placeholderLabel);
                            imagePictureBox.Visible = true;
                        }
                    }
                    else
                    {
                        // Hide empty slots
                        imagePictureBox.Visible = false;
                    }

                    imagesContainer.Controls.Add(imagePictureBox);
                }

                contentPanel.Controls.Add(imagesContainer);
            }

            // Tags display
            if (m_Post.Tags.Count > 0)
            {
                Label tagsLabel = new Label()
                {
                    Text = $"🏷️ Tags: {string.Join(", ", m_Post.Tags)}",
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.LightBlue,
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    MaximumSize = new Size(480, 0),
                    Margin = new Padding(0, 10, 0, 0)
                };

                contentPanel.Controls.Add(tagsLabel);
            }

            return contentPanel;
        }

        /// <summary>
        /// Create post stats panel (likes, comments, shares count)
        /// </summary>
        private Panel CreateStatsPanel()
        {
            Panel statsPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 30,
                Padding = new Padding(0, 5, 0, 5)
            };

            Label statsLabel = new Label()
            {
                Text = "👍 0 Likes   💬 0 Comments   ↗️ 0 Shares",
                Font = new Font("Segoe UI", 9),
                ForeColor = LIGHT_GRAY,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            statsPanel.Controls.Add(statsLabel);

            return statsPanel;
        }

        /// <summary>
        /// Create interaction buttons (Like, Comment, Share)
        /// </summary>
        private Panel CreateInteractionPanel()
        {
            Panel interactionPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 45,
                Padding = new Padding(5)
            };

            // Like button
            Button likeButton = new Button()
            {
                Text = "👍 Like",
                Width = 145,
                Height = 35,
                BackColor = ROYAL_BLUE,
                ForeColor = WHITE,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Enabled = false,
                Margin = new Padding(2),
                Dock = DockStyle.Left
            };

            // Comment button
            Button commentButton = new Button()
            {
                Text = "💬 Comment",
                Width = 145,
                Height = 35,
                BackColor = ROYAL_BLUE,
                ForeColor = WHITE,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Enabled = false,
                Margin = new Padding(2),
                Dock = DockStyle.Left
            };

            // Share button
            Button shareButton = new Button()
            {
                Text = "↗️ Share",
                Width = 145,
                Height = 35,
                BackColor = ROYAL_BLUE,
                ForeColor = WHITE,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Enabled = false,
                Margin = new Padding(2),
                Dock = DockStyle.Left
            };

            interactionPanel.Controls.Add(shareButton);
            interactionPanel.Controls.Add(commentButton);
            interactionPanel.Controls.Add(likeButton);

            return interactionPanel;
        }

        /// <summary>
        /// Create footer with warning and close button
        /// </summary>
        private Panel CreateFooterPanel()
        {
            Panel footerPanel = new Panel()
            {
                Dock = DockStyle.Bottom,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0, 10, 0, 0)
            };

            // Warning banner
            Panel warningBanner = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Orange,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(12)
            };

            Label warningLabel = new Label()
            {
                Text = "⚠️ MOCK PREVIEW\n\nFacebook API posting is currently unavailable due to project limitations.\nThis is how your post would appear on Facebook.",
                Font = new Font("Segoe UI", 9),
                ForeColor = MIDNIGHT_BLUE,
                Dock = DockStyle.Top,
                AutoSize = true,
                MaximumSize = new Size(500, 0)
            };

            warningBanner.Controls.Add(warningLabel);

            // Close button
            Button closeButton = new Button()
            {
                Text = "Close Preview",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = ROYAL_BLUE,
                ForeColor = WHITE,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(0, 10, 0, 0)
            };

            footerPanel.Controls.Add(closeButton);
            footerPanel.Controls.Add(warningBanner);

            return footerPanel;
        }
    }
}