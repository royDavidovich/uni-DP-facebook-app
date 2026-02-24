using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Strategies
{
    public class NoSortStrategy : ISortStrategy
    {
        public IEnumerable<object> Sort(IEnumerable<object> i_Items, string i_PropertyName)
        {
            if (i_Items == null)
            {
                return new List<object>();
            }

            return i_Items;
        }
    }
}