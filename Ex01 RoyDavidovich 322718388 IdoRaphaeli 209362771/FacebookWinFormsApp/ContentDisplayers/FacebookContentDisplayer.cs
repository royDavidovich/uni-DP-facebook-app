using System;
using System.Collections;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Facades;

namespace BasicFacebookFeatures.ContentDisplayers
{
    public abstract class FacebookContentDisplayer
    {
        public static FacebookContentDisplayer Create(string type, FormMain formMain)
        {
            switch (type.ToLower())
            {
                case "albums":
                    return new AlbumDisplayer(formMain);
                case "posts":
                    return new PostDisplayer();
                case "events":
                    return new EventDisplayer(formMain);
                case "groups":
                    return new GroupDisplayer(formMain);
                case "pages":
                    return new LikedPagesDisplayer(formMain);
                case "teams":
                    return new TeamDisplayer(formMain);
                case "music":
                    return new MusicDisplayer(formMain);
                default:
                    throw new ArgumentException($"The content type '{type}' is not supported.");
            }
        }

        public void DisplayContent(ListBox listBox, FacebookFacade facade)
        {
            listBox.Items.Clear();
            listBox.DisplayMember = GetDisplayMember();

            try
            {
                IEnumerable data = GetContent(facade);

                if (data == null) return;

                foreach (var item in data)
                {
                    listBox.Items.Add(item);
                }

                if (listBox.Items.Count == 0)
                {
                    MessageBox.Show($"No {GetContentTypeName()} to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching {GetContentTypeName()}: {ex.Message}");
            }
        }

        protected abstract IEnumerable GetContent(FacebookFacade facade);
        protected abstract string GetContentTypeName();

        protected virtual string GetDisplayMember()
        {
            return "Name";
        }

        public virtual Action<object> GetSelectionHandler()
        {
            return null;
        }
    }
}