using System;
using System.Collections;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Facades;

namespace BasicFacebookFeatures.ContentDisplayers
{
    public class AlbumDisplayer : FacebookContentDisplayer
    {
        private readonly FormMain m_FormMain;

        public AlbumDisplayer(FormMain formMain)
        {
            m_FormMain = formMain;
        }

        protected override IEnumerable GetContent(FacebookFacade facade)
        {
            return facade.GetUserAlbums();
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