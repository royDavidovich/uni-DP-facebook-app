using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Builders
{
    public class FacebookPost
    {
        public string Content { get; set; }
        public string TransformedStyle { get; set; }
        public string TransformedContent { get; set; }
        public User Author { get; set; }
        public ePrivacyLevel Privacy { get; set; }
        public List<string> Tags { get; set; }
        public List<string> ImagePaths { get; set; }
        public DateTime CreatedAt { get; set; }
        public ePostType PostType { get; set; }

        public FacebookPost()
        {
            Tags = new List<string>();
            ImagePaths = new List<string>();
            Privacy = ePrivacyLevel.Public;
            CreatedAt = DateTime.Now;
            PostType = ePostType.TextOnly;
        }

        public override string ToString()
        {
            return $"Post: {Content}\n" +
                   $"Style: {TransformedStyle}\n" +
                   $"Privacy: {Privacy}\n" +
                   $"Type: {PostType}\n" +
                   $"Images: {ImagePaths.Count}";
        }
    }

    public enum ePrivacyLevel
    {
        Public,           // 0 - Anyone can see
        FriendsOnly,      // 1 - Only friends can see
        Private           // 2 - Only me
    }

    public enum ePostType
    {
        TextOnly,
        TextWithImages,
        ImageGallery,
        Link,
        Video
    }
}