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
    public class GroupDisplayer : FacebookContentDisplayer
    {
        private readonly FormMain m_FormMain;

        public GroupDisplayer(FormMain i_FormMain)
        {
            m_FormMain = i_FormMain;
        }

        protected override IEnumerable GetContent(FacebookFacade i_Facade)
        {
            return i_Facade.GetUserGroups();
        }

        protected override string GetContentTypeName()
        {
            return "Groups";
        }

        public override Action<object> GetSelectionHandler()
        {
            return item =>
            {
                if (item is Group group && group.PictureNormalURL != null)
                {
                    m_FormMain.LoadImageToPictureBox(group.PictureNormalURL);
                }
            };
        }
    }
}
