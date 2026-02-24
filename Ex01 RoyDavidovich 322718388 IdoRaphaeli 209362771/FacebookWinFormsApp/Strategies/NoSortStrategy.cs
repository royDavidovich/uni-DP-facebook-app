using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Strategies
{
    public class NoSortStrategy : ISortStrategy
    {
        public IEnumerable<object> Sort(IEnumerable<object> i_Items, string i_PropertyName)
        {
            return i_Items ?? new List<object>();
        }
    }
}