using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Strategies
{
    /// <summary>
    /// Concrete strategy: No sorting
    /// Returns the collection in its original order
    /// </summary>
    public class NoSortStrategy : ISortStrategy
    {
        /// <summary>
        /// Returns items without any sorting
        /// </summary>
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