using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BasicFacebookFeatures.Strategies
{
    /// <summary>
    /// Concrete strategy: Ascending sort (A-Z)
    /// Sorts items alphabetically in ascending order using Reflection
    /// </summary>
    public class AscendingSortStrategy : ISortStrategy
    {
        /// <summary>
        /// Sort items in ascending order (A-Z) by the specified property
        /// Uses Reflection to access property values for comparison
        /// </summary>
        public IEnumerable<object> Sort(IEnumerable<object> i_Items, string i_PropertyName)
        {
            if (i_Items == null)
            {
                return new List<object>();
            }

            try
            {
                return i_Items.OrderBy(item => GetPropertyValue(item, i_PropertyName)).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Error sorting items by property '{i_PropertyName}' in ascending order: {ex.Message}",
                    ex);
            }
        }

        /// <summary>
        /// Get property value from an object using Reflection
        /// </summary>
        private object GetPropertyValue(object i_Item, string i_PropertyName)
        {
            if (i_Item == null)
            {
                return null;
            }

            Type itemType = i_Item.GetType();
            PropertyInfo propertyInfo = itemType.GetProperty(
                i_PropertyName,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (propertyInfo == null)
            {
                throw new InvalidOperationException(
                    $"Property '{i_PropertyName}' not found on type '{itemType.Name}'");
            }

            return propertyInfo.GetValue(i_Item, null) ?? string.Empty;
        }
    }
}