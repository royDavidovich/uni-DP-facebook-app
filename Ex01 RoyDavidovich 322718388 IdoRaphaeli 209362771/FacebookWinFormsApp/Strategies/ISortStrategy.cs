using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Strategies
{
    /// <summary>
    /// Strategy interface for sorting collections
    /// Defines the contract for different sorting algorithms
    /// </summary>
    public interface ISortStrategy
    {
        /// <summary>
        /// Sort a collection of objects by a specific property
        /// </summary>
        /// <param name="i_Items">Collection of items to sort</param>
        /// <param name="i_PropertyName">Name of the property to sort by</param>
        /// <returns>Sorted collection of objects</returns>
        IEnumerable<object> Sort(IEnumerable<object> i_Items, string i_PropertyName);
    }
}