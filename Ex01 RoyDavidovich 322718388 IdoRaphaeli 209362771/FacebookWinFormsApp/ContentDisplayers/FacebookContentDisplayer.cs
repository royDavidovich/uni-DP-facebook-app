using BasicFacebookFeatures.Facades;
using BasicFacebookFeatures.Strategies;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures.ContentDisplayers
{
    public abstract class FacebookContentDisplayer
    {
        /// <summary>
        /// Strategy for sorting displayed content
        /// Defaults to NoSortStrategy (no sorting)
        /// </summary>
        public ISortStrategy SortStrategy { get; set; }

        public FacebookContentDisplayer()
        {
            SortStrategy = new NoSortStrategy();
        }

        public static FacebookContentDisplayer Create(string i_Type, FormMain i_FormMain)
        {
            switch (i_Type.ToLower())
            {
                case "albums":
                    return new AlbumDisplayer(i_FormMain);
                case "posts":
                    return new PostDisplayer();
                case "events":
                    return new EventDisplayer(i_FormMain);
                case "groups":
                    return new GroupDisplayer(i_FormMain);
                case "pages":
                    return new LikedPagesDisplayer(i_FormMain);
                case "teams":
                    return new TeamDisplayer(i_FormMain);
                case "music":
                    return new MusicDisplayer(i_FormMain);
                default:
                    throw new ArgumentException($"The content type '{i_Type}' is not supported.");
            }
        }

        public void DisplayContent(ListBox i_ListBox, FacebookFacade i_Facade)
        {
            i_ListBox.DataSource = null;
            i_ListBox.Items.Clear();
            i_ListBox.DisplayMember = GetDisplayMember();

            try
            {
                IEnumerable data = GetContent(i_Facade);

                if (data == null)
                {
                    return;
                }

                // Convert to list of objects for sorting
                List<object> itemsList = new List<object>();
                foreach (var item in data)
                {
                    itemsList.Add(item);
                }

                // Apply sorting strategy
                IEnumerable<object> sortedItems = SortStrategy.Sort(itemsList, GetDisplayMember());

                // Add sorted items to ListBox
                foreach (var item in sortedItems)
                {
                    i_ListBox.Items.Add(item);
                }

                if (i_ListBox.Items.Count == 0)
                {
                    MessageBox.Show($"No {GetContentTypeName()} to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching {GetContentTypeName()}: {ex.Message}");
            }
        }

        public void DisplayContent(ListBox i_ListBox, TextBox i_TextBox, FacebookFacade i_Facade, Label i_LabelCount = null)
        {
            i_ListBox.DataSource = null;
            i_ListBox.Items.Clear();
            
            if (i_TextBox != null)
            {
                i_TextBox.DataBindings.Clear();
                i_TextBox.Clear();
            }

            i_ListBox.DisplayMember = GetDisplayMember();

            try
            {
                IEnumerable data = GetContent(i_Facade);
                
                if (data == null)
                {
                    return;
                }

                // Convert to list of objects
                List<object> itemsList = new List<object>();
                foreach (var item in data)
                {
                    itemsList.Add(item);
                }

                if (itemsList.Count == 0)
                {
                    return;
                }

                // Apply sorting strategy
                IEnumerable<object> sortedItems = SortStrategy.Sort(itemsList, GetDisplayMember());

                // Create BindingSource with sorted data
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sortedItems.ToList();
                i_ListBox.DataSource = bindingSource;

                if (i_TextBox != null)
                {
                    i_TextBox.DataBindings.Add("Text", bindingSource, GetDisplayMember(), true, DataSourceUpdateMode.Never);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected abstract IEnumerable GetContent(FacebookFacade i_Facade);
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