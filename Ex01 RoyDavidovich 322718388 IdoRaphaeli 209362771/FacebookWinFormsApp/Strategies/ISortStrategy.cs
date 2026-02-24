using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Strategies
{
    public interface ISortStrategy
    {
        IEnumerable<object> Sort(IEnumerable<object> i_Items, string i_PropertyName);
    }
}