using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace BasicFacebookFeatures.Builders
{
    /// <summary>
    /// Fluent Builder for constructing FacebookPost objects step-by-step.
    /// Follows the Builder pattern to create complex post objects with optional features.
    /// Enables: text, styles, images, privacy, tags, and validation.
    /// </summary>
    public class FacebookPostBuilder
    {
        private FacebookPost m_Post;
        private List<string> m_ValidationErrors;

        public FacebookPostBuilder()
        {
            m_Post = new FacebookPost();
            m_ValidationErrors = new List<string>();
        }

        public FacebookPostBuilder WithContent(string i_Content)
        {
            if (string.IsNullOrWhiteSpace(i_Content))
            {
                m_ValidationErrors.Add("Content cannot be empty.");
            }
            else
            {
                m_Post.Content = i_Content;
                if (m_Post.PostType == ePostType.TextOnly && m_Post.ImagePaths.Count == 0)
                {
                    m_Post.PostType = ePostType.TextOnly;
                }
            }

            return this;
        }

        public FacebookPostBuilder WithStyle(string i_Style)
        {
            if (string.IsNullOrWhiteSpace(i_Style))
            {
                m_ValidationErrors.Add("Style cannot be empty.");
            }
            else
            {
                m_Post.TransformedStyle = i_Style;
            }

            return this;
        }

        public FacebookPostBuilder SetTransformedContent(string i_TransformedContent)
        {
            if (!string.IsNullOrWhiteSpace(i_TransformedContent))
            {
                m_Post.TransformedContent = i_TransformedContent;
            }

            return this;
        }

        public FacebookPostBuilder WithAuthor(User i_Author)
        {
            if (i_Author == null)
            {
                m_ValidationErrors.Add("Author (User) is required.");
            }
            else
            {
                m_Post.Author = i_Author;
            }

            return this;
        }

        public FacebookPostBuilder WithPrivacy(ePrivacyLevel i_PrivacyLevel)
        {
            m_Post.Privacy = i_PrivacyLevel;

            return this;
        }

        public FacebookPostBuilder AddImage(string i_ImagePath)
        {
            if (string.IsNullOrWhiteSpace(i_ImagePath))
            {
                m_ValidationErrors.Add("Image path cannot be empty.");
            }
            else if (!File.Exists(i_ImagePath))
            {
                m_ValidationErrors.Add($"Image file not found: {i_ImagePath}");
            }
            else
            {
                m_Post.ImagePaths.Add(i_ImagePath);
                m_Post.PostType = m_Post.ImagePaths.Count > 1 ? ePostType.ImageGallery : ePostType.TextWithImages;
            }

            return this;
        }

        public FacebookPostBuilder AddImages(List<string> i_ImagePaths)
        {
            if (i_ImagePaths != null)
            {
                foreach (string path in i_ImagePaths)
                {
                    AddImage(path);
                }
            }

            return this;
        }

        public FacebookPostBuilder RemoveImage(string i_ImagePath)
        {
            if (m_Post.ImagePaths.Contains(i_ImagePath))
            {
                m_Post.ImagePaths.Remove(i_ImagePath);
                if (m_Post.ImagePaths.Count == 0)
                {
                    m_Post.PostType = ePostType.TextOnly;
                }
                else if (m_Post.ImagePaths.Count == 1)
                {
                    m_Post.PostType = ePostType.TextWithImages;
                }
            }

            return this;
        }

        public FacebookPostBuilder ClearImages()
        {
            m_Post.ImagePaths.Clear();
            m_Post.PostType = ePostType.TextOnly;
            return this;
        }

        public FacebookPostBuilder AddTag(string i_Tag)
        {
            if (!string.IsNullOrWhiteSpace(i_Tag) && !m_Post.Tags.Contains(i_Tag))
            {
                m_Post.Tags.Add(i_Tag);
            }

            return this;
        }

        public FacebookPostBuilder AddTags(List<string> i_Tags)
        {
            if (i_Tags != null)
            {
                foreach (string tag in i_Tags)
                {
                    AddTag(tag);
                }
            }

            return this;
        }

        public FacebookPostBuilder RemoveTag(string i_Tag)
        {
            m_Post.Tags.Remove(i_Tag);
            return this;
        }

        public FacebookPostBuilder ClearTags()
        {
            m_Post.Tags.Clear();
            return this;
        }

        public bool Validate()
        {
            m_ValidationErrors.Clear();

            // Required fields
            if (string.IsNullOrWhiteSpace(m_Post.Content))
                m_ValidationErrors.Add("Content is required.");

            if (string.IsNullOrWhiteSpace(m_Post.TransformedStyle))
                m_ValidationErrors.Add("Style is required.");

            if (m_Post.Author == null)
                m_ValidationErrors.Add("Author (logged-in user) is required.");

            // Image validation
            if (m_Post.PostType == ePostType.TextWithImages || m_Post.PostType == ePostType.ImageGallery)
            {
                if (m_Post.ImagePaths.Count == 0)
                    m_ValidationErrors.Add("Post type requires images but none were added.");
            }

            return m_ValidationErrors.Count == 0;
        }

        public string GetValidationErrorsAsString()
        {
            return string.Join("\n• ", m_ValidationErrors);
        }

        // ========== Building ==========

        /// <summary>
        /// Build and return the FacebookPost object
        /// Throws exception if validation fails
        /// </summary>
        public FacebookPost Build()
        {
            if (!Validate())
            {
                throw new InvalidOperationException(
                    "Cannot build post. Validation errors:\n• " + GetValidationErrorsAsString()
                );
            }

            // Return a copy to prevent external modification
            return new FacebookPost
            {
                Content = m_Post.Content,
                TransformedStyle = m_Post.TransformedStyle,
                TransformedContent = m_Post.TransformedContent,
                Author = m_Post.Author,
                Privacy = m_Post.Privacy,
                Tags = new List<string>(m_Post.Tags),
                ImagePaths = new List<string>(m_Post.ImagePaths),
                CreatedAt = m_Post.CreatedAt,
                PostType = m_Post.PostType
            };
        }

        public bool TryBuild(out FacebookPost o_Post, out string o_ErrorMessage)
        {
            o_Post = null;
            o_ErrorMessage = null;

            if (!Validate())
            {
                o_ErrorMessage = GetValidationErrorsAsString();
                return false;
            }

            try
            {
                o_Post = Build();
                return true;
            }
            catch (Exception ex)
            {
                o_ErrorMessage = ex.Message;
                return false;
            }
        }

        public FacebookPostBuilder Reset()
        {
            m_Post = new FacebookPost();
            m_ValidationErrors.Clear();
            return this;
        }
    }
}