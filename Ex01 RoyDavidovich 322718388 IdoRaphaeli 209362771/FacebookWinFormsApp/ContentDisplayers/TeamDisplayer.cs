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

        public TeamDisplayer(FormMain formMain)
        {
            m_FormMain = formMain;
        }

        protected override IEnumerable GetContent(FacebookFacade facade)
        {
            return facade.GetFavoriteTeams();
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