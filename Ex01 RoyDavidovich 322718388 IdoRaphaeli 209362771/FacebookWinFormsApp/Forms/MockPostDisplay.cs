using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BasicFacebookFeatures.Builders;
using BasicFacebookFeatures.Utilities;

namespace BasicFacebookFeatures.Forms
{
    /// <summary>
    /// Mock display form simulating how a Facebook post would appear
    /// REQUIREMENT: Strategy Pattern - receives complete FacebookPost object
    /// Shows: Author, Timestamp, Content, Images (Thumbnails), Tags, Action Bar
    /// 
    /// DESIGN PRINCIPLE: Pure "Viewer" Strategy
    /// - Extracts ALL content EXCLUSIVELY from the FacebookPost object passed to constructor
    /// - Does NOT query data from any other source (VibeShifter, Builder, etc.)
    /// - Displays data as-is without modification
    /// 
    /// IMAGE DISPLAY: Compact Thumbnails
    /// - Fixed-size squares (150x150 px) to optimize screen real estate
    /// - FlowLayoutPanel arranges thumbnails side-by-side
    /// - PictureBox.SizeMode = Zoom for neat fitting
    /// </summary>
    public partial class MockPostDisplay : Form
    {
        private FacebookPost m_Post;

        // Color palette
        private static readonly Color MIDNIGHT_BLUE = Color.MidnightBlue;
        private static readonly Color DARK_SLATE_BLUE = Color.DarkSlateBlue;
        private static readonly Color ROYAL_BLUE = Color.RoyalBlue;
        private static readonly Color WHITE = Color.White;
        private static readonly Color LIGHT_GRAY = Color.LightGray;
        private static readonly Color FACEBOOK_BLUE = Color.FromArgb(59, 89, 152);

        // Image thumbnail constants - COMPACT DISPLAY
        private const int k_ThumbnailSize = 150;  // Fixed square size (150x150 px)
        private const int k_ThumbnailSpacing = 5; // Spacing between thumbnails

        /// <summary>
        /// Constructor receives FacebookPost object
        /// REQUIREMENT: Pure Viewer Strategy - data source authority
        /// All display data comes EXCLUSIVELY from i_Post parameter
        /// </summary>
        public MockPostDisplay(FacebookPost i_Post)
        {
            m_Post = i_Post ?? throw new ArgumentNullException(nameof(i_Post));
            InitializeComponent();
            BuildDisplay();
        }

        private void BuildDisplay()
        {
            this.Text = "Post Preview - Facebook Feed";
            this.BackColor = MIDNIGHT_BLUE;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(650, 850);
            this.Font = new Font("Segoe UI", 9);

            Panel mainPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = MIDNIGHT_BLUE,
                AutoScroll = true,
                Padding = new Padding(20)
            };

            // Post card - Facebook-like design
            Panel postCard = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = WHITE,
                Margin = new Padding(0, 0, 0, 20)
            };

            // REQUIREMENT a: Author & Date
            // Data source: m_Post.Author, m_Post.Privacy, m_Post.CreatedAt
            Panel headerPanel = createHeaderPanel();
            postCard.Controls.Add(headerPanel);

            // REQUIREMENT c: Transformed Text
            // Data source: m_Post.TransformedContent (fallback to m_Post.Content)
            Panel contentPanel = createContentPanel();
            postCard.Controls.Add(contentPanel);

            // REQUIREMENT b: Compact Image Thumbnails (if images exist)
            // Data source: m_Post.ImagePaths list
            if (m_Post.ImagePaths != null && m_Post.ImagePaths.Count > 0)
            {
                Panel imagePanel = createCompactImagePanel();
                postCard.Controls.Add(imagePanel);
            }

            // REQUIREMENT d: Tags
            // Data source: m_Post.Tags list
            if (m_Post.Tags != null && m_Post.Tags.Count > 0)
            {
                Panel tagsPanel = createTagsPanel();
                postCard.Controls.Add(tagsPanel);
            }

            // REQUIREMENT e: Action Bar
            Panel actionBarPanel = createActionBarPanel();
            postCard.Controls.Add(actionBarPanel);

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
                Margin = new Padding(0, 20, 0, 0)
            };

            mainPanel.Controls.Add(closeButton);
            mainPanel.Controls.Add(postCard);
            this.Controls.Add(mainPanel);
        }

        /// <summary>
        /// REQUIREMENT a: Author Name & Date of Posting
        /// DATA SOURCE: m_Post.Author (name), m_Post.Privacy (privacy level), m_Post.CreatedAt (timestamp)
        /// </summary>
        private Panel createHeaderPanel()
        {
            Panel headerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = WHITE,
                Padding = new Padding(12),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Author name - DATA SOURCE: m_Post.Author?.Name
            Label authorLabel = new Label()
            {
                Text = m_Post.Author?.Name ?? "Unknown User",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };

            // Timestamp & Privacy - DATA SOURCE: m_Post.Privacy
            string privacyIcon = getPrivacyIcon(m_Post.Privacy);
            Label timestampLabel = new Label()
            {
                Text = $"Just now • {privacyIcon} {getPrivacyDisplay(m_Post.Privacy)}",
                Font = new Font("Segoe UI", 9),
                ForeColor = LIGHT_GRAY,
                Dock = DockStyle.Top,
                AutoSize = true
            };

            headerPanel.Controls.Add(timestampLabel);
            headerPanel.Controls.Add(authorLabel);

            return headerPanel;
        }

        /// <summary>
        /// REQUIREMENT c: Transformed/Generated Text
        /// DATA SOURCE: m_Post.TransformedContent (priority), fallback to m_Post.Content
        /// This is the AI-generated text from the Builder
        /// </summary>
        private Panel createContentPanel()
        {
            Panel contentPanel = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = WHITE,
                Padding = new Padding(12),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 1)
            };

            // Display transformed text if available, otherwise original content
            string displayText = !string.IsNullOrEmpty(m_Post.TransformedContent)
                ? m_Post.TransformedContent
                : m_Post.Content;

            Label contentLabel = new Label()
            {
                Text = displayText,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                AutoSize = true,
                MaximumSize = new Size(580, 0),
                Margin = new Padding(0, 0, 0, 12)
            };

            contentPanel.Controls.Add(contentLabel);

            return contentPanel;
        }

        /// <summary>
        /// REQUIREMENT b: Compact Image Thumbnails
        /// DATA SOURCE: m_Post.ImagePaths list (EXCLUSIVE)
        /// 
        /// DESIGN: Fixed-Size Thumbnails (150x150 px)
        /// - FlowLayoutPanel arranges thumbnails horizontally
        /// - PictureBox.SizeMode = Zoom for proper aspect ratio fit
        /// - Each thumbnail has border and consistent spacing
        /// - Optimizes screen real estate vs full-resolution display
        /// </summary>
        private Panel createCompactImagePanel()
        {
            Panel imageContainerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = WHITE,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 1),
                Padding = new Padding(10)
            };

            // FlowLayoutPanel for compact thumbnail arrangement
            FlowLayoutPanel flowLayoutThumbnails = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,  // Wrap to next row if needed
                BackColor = WHITE
            };

            // REQUIREMENT: Loop through m_Post.ImagePaths and create thumbnail for EACH image
            // DATA SOURCE: m_Post.ImagePaths list (this is the ONLY source of truth)
            for (int i = 0; i < m_Post.ImagePaths.Count; i++)
            {
                string imagePath = m_Post.ImagePaths[i];
                PictureBox thumbnail = createImageThumbnail(imagePath, i + 1, m_Post.ImagePaths.Count);
                flowLayoutThumbnails.Controls.Add(thumbnail);
            }

            // Image count label
            Label imageCountLabel = new Label()
            {
                Text = $"{m_Post.ImagePaths.Count} image{(m_Post.ImagePaths.Count != 1 ? "s" : "")} in this post",
                Font = new Font("Segoe UI", 8),
                ForeColor = LIGHT_GRAY,
                Dock = DockStyle.Bottom,
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 0)
            };

            imageContainerPanel.Controls.Add(imageCountLabel);
            imageContainerPanel.Controls.Add(flowLayoutThumbnails);

            return imageContainerPanel;
        }

        /// <summary>
        /// Create a single compact thumbnail (150x150 px)
        /// DESIGN: Fixed square with Zoom mode for aspect ratio preservation
        /// 
        /// Constraints:
        /// - Width: k_ThumbnailSize (150 px)
        /// - Height: k_ThumbnailSize (150 px)
        /// - SizeMode: Zoom (maintains aspect ratio)
        /// - Error handling: Shows placeholder if image fails to load
        /// </summary>
        private PictureBox createImageThumbnail(string i_ImagePath, int i_ImageNumber, int i_TotalImages)
        {
            PictureBox thumbnail = new PictureBox()
            {
                Width = k_ThumbnailSize,
                Height = k_ThumbnailSize,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(k_ThumbnailSpacing),
                Tag = i_ImageNumber
            };

            try
            {
                thumbnail.ImageLocation = i_ImagePath;
            }
            catch (Exception _)
            {
                thumbnail.BackColor = Color.DarkGray;

                Label placeholderLabel = new Label()
                {
                    Text = $"📷\nImg {i_ImageNumber}",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = LIGHT_GRAY,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.DarkGray
                };

                thumbnail.Controls.Add(placeholderLabel);
            }

            return thumbnail;
        }

        /// <summary>
        /// REQUIREMENT d: Tagged Friends
        /// DATA SOURCE: m_Post.Tags list (EXCLUSIVE)
        /// </summary>
        private Panel createTagsPanel()
        {
            Panel tagsPanel = new Panel()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = WHITE,
                Padding = new Padding(12),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 1)
            };

            // Display all tags from m_Post.Tags list
            string tagsDisplay = string.Join(", ", m_Post.Tags);
            Label tagsLabel = new Label()
            {
                Text = $"🏷️ Tagged with: {tagsDisplay}",
                Font = new Font("Segoe UI", 9),
                ForeColor = FACEBOOK_BLUE,
                Dock = DockStyle.Top,
                AutoSize = true,
                MaximumSize = new Size(580, 0)
            };

            tagsPanel.Controls.Add(tagsLabel);

            return tagsPanel;
        }

        /// <summary>
        /// REQUIREMENT e: Dummy Action Bar
        /// Visual representation of Like, Comment, Share
        /// These buttons are NOT functional (Enabled = false) - visual only
        /// </summary>
        private Panel createActionBarPanel()
        {
            Panel actionBarPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = WHITE,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 0),
                Padding = new Padding(5)
            };

            // Like button - VISUAL ONLY
            Button likeButton = new Button()
            {
                Text = "👍 Like",
                Width = 190,
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9),
                FlatStyle = FlatStyle.Flat,
                Enabled = false,  // Visual only - not functional
                Dock = DockStyle.Left,
                Margin = new Padding(2)
            };

            // Comment button - VISUAL ONLY
            Button commentButton = new Button()
            {
                Text = "💬 Comment",
                Width = 190,
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9),
                FlatStyle = FlatStyle.Flat,
                Enabled = false,  // Visual only - not functional
                Dock = DockStyle.Left,
                Margin = new Padding(2)
            };

            // Share button - VISUAL ONLY
            Button shareButton = new Button()
            {
                Text = "↗️ Share",
                Width = 190,
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9),
                FlatStyle = FlatStyle.Flat,
                Enabled = false,  // Visual only - not functional
                Dock = DockStyle.Left,
                Margin = new Padding(2)
            };

            actionBarPanel.Controls.Add(shareButton);
            actionBarPanel.Controls.Add(commentButton);
            actionBarPanel.Controls.Add(likeButton);

            return actionBarPanel;
        }

        /// <summary>
        /// Convert PrivacyLevel enum to icon emoji
        /// </summary>
        private string getPrivacyIcon(ePrivacyLevel i_Privacy)
        {
            return i_Privacy == ePrivacyLevel.Private ? "🔒" :
                   i_Privacy == ePrivacyLevel.FriendsOnly ? "👥" : "🌍";
        }

        /// <summary>
        /// Convert PrivacyLevel enum to user-friendly display string
        /// </summary>
        private string getPrivacyDisplay(ePrivacyLevel i_Privacy)
        {
            return i_Privacy == ePrivacyLevel.Public ? "Public" :
                   i_Privacy == ePrivacyLevel.FriendsOnly ? "Friends Only" : "Private";
        }
    }
}