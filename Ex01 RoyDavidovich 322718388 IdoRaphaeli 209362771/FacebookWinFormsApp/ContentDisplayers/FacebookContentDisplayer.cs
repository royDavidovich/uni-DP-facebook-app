using BasicFacebookFeatures.Facades;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

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
            listBox.DataSource = null;
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

        public void DisplayContent(ListBox listBox, TextBox textBox, FacebookFacade facade, Label labelCount = null)
        {
            listBox.DataSource = null;
            listBox.Items.Clear();
            if (textBox != null)
            {
                textBox.DataBindings.Clear();
                textBox.Clear();
            }

            listBox.DisplayMember = GetDisplayMember();

            try
            {
                IEnumerable data = GetContent(facade);
                if (data == null) return;

                var list = new List<object>();
                foreach (var item in data) list.Add(item);

                if (list.Count == 0) return;

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = list;
                listBox.DataSource = bindingSource;

                if (textBox != null)
                {
                    textBox.DataBindings.Add("Text", bindingSource, GetDisplayMember(), true, DataSourceUpdateMode.Never);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}