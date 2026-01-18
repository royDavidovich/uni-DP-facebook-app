using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Facades;

namespace BasicFacebookFeatures.ContentDisplayers
{
    public class MusicDisplayer : FacebookContentDisplayer
    {
        private readonly FormMain m_FormMain;

        public MusicDisplayer(FormMain i_FormMain)
        {
            m_FormMain = i_FormMain;
        }

        protected override IEnumerable GetContent(FacebookFacade i_Facade)
        {
            return i_Facade.GetMusic();
        }

        protected override string GetContentTypeName()
        {
            return "Favorite Music";
        }

        public override Action<object> GetSelectionHandler()
        {
            return item =>
            {
                if (item is Page music && music.PictureNormalURL != null)
                {
                    m_FormMain.LoadImageToPictureBox(music.PictureNormalURL);
                }
            };
        }
    }
}