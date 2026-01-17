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
    public class EventDisplayer : FacebookContentDisplayer
    {
        private readonly FormMain m_FormMain;

        public EventDisplayer(FormMain formMain)
        {
            m_FormMain = formMain;
        }

        protected override IEnumerable GetContent(FacebookFacade facade)
        {
            return facade.GetUserEvents();
        }

        protected override string GetContentTypeName()
        {
            return "Events";
        }

        public override Action<object> GetSelectionHandler()
        {
            return item =>
            {
                if (item is Event fbEvent && fbEvent.Cover != null)
                {
                    m_FormMain.LoadImageToPictureBox(fbEvent.Cover.SourceURL);
                }
            };
        }
    }
}