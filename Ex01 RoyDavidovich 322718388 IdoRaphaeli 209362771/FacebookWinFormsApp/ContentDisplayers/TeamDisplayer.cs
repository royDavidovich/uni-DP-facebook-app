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
    public class TeamDisplayer : FacebookContentDisplayer
    {
        private readonly FormMain m_FormMain;

        public TeamDisplayer(FormMain i_FormMain)
        {
            m_FormMain = i_FormMain;
        }

        protected override IEnumerable GetContent(FacebookFacade i_Facade)
        {
            return i_Facade.GetFavoriteTeams();
        }

        protected override string GetContentTypeName()
        {
            return "Favorite Teams";
        }

        public override Action<object> GetSelectionHandler()
        {
            return item =>
            {
                if (item is Page team && team.PictureNormalURL != null)
                {
                    m_FormMain.LoadImageToPictureBox(team.PictureNormalURL);
                }
            };
        }
    }
}