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

        public GroupDisplayer(FormMain formMain)
        {
            m_FormMain = formMain;
        }

        protected override IEnumerable GetContent(FacebookFacade facade)
        {
            return facade.GetUserGroups();
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
