using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BasicFacebookFeatures.Facades;

namespace BasicFacebookFeatures.ContentDisplayers
{
    public class PostDisplayer : FacebookContentDisplayer
    {
        protected override IEnumerable GetContent(FacebookFacade facade)
        {
            return facade.GetUserPosts();
        }

        protected override string GetContentTypeName()
        {
            return "Posts";
        }

        protected override string GetDisplayMember()
        {
            return "Message";
        }
    }
}
