using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Facades;

namespace BasicFacebookFeatures.ContentDisplayers
{
    public class LikedPagesDisplayer : FacebookContentDisplayer
    {
        private readonly FormMain m_FormMain;

        public LikedPagesDisplayer(FormMain formMain)
        {
            m_FormMain = formMain;
        }

        protected override IEnumerable GetContent(FacebookFacade facade)
        {
            return facade.GetLikedPages();
        }

        protected override string GetContentTypeName()
        {
            return "Liked Pages";
        }

        public override Action<object> GetSelectionHandler()
        {
            return item =>
            {
                if (item is Page page && page.PictureNormalURL != null)
                {
                    m_FormMain.LoadImageToPictureBox(page.PictureNormalURL);
                }
            };
        }
    }
}
