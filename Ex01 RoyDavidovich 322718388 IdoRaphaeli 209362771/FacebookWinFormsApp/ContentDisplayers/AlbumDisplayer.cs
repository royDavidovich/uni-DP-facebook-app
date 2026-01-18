using System;
using System.Collections;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Facades;

namespace BasicFacebookFeatures.ContentDisplayers
{
    public class AlbumDisplayer : FacebookContentDisplayer
    {
        private readonly FormMain m_FormMain;

        public AlbumDisplayer(FormMain i_FormMain)
        {
            m_FormMain = i_FormMain;
        }

        protected override IEnumerable GetContent(FacebookFacade i_Facade)
        {
            return i_Facade.GetUserAlbums();
        }

        protected override string GetContentTypeName()
        {
            return "Albums";
        }

        public override Action<object> GetSelectionHandler()
        {
            return item =>
            {
                if (item is Album album && album.PictureAlbumURL != null)
                {
                    m_FormMain.LoadImageToPictureBox(album.PictureAlbumURL);
                }
            };
        }
    }
}