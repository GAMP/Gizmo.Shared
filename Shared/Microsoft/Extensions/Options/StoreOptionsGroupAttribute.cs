using System;
using System.Linq;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Provides options unique store group name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class StoreOptionsGroupAttribute : Attribute
    {
        #region CONSTRUCTOR
        public StoreOptionsGroupAttribute(string groupName)
        {
            if(groupName == null)
                throw new ArgumentNullException(nameof(groupName));

            //dont allow white spaces in group names
            if(groupName.Any(c=> char.IsWhiteSpace(c)))
                throw new ArgumentNullException(nameof(groupName));
            
            GroupName = groupName;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets settings group name.
        /// </summary>
        public string GroupName
        {
            get;
        }

        #endregion
    }
}
