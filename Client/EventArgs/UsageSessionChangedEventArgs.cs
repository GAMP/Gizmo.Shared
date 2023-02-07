using System;

namespace Gizmo.Client
{
    /// <summary>
    /// User usage session changed event args.
    /// </summary>
    public sealed class UsageSessionChangedEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="usageType">Current usage type.</param>
        /// <param name="timeProduct">Current time product name.</param>
        public UsageSessionChangedEventArgs(int userId, UsageType usageType, string timeProduct)
        {
            UserId = userId;
            CurrentTimeProduct = timeProduct;
            CurrentUsageType = usageType;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user id.
        /// </summary>
        public int UserId
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets current time poroduct name.
        /// </summary>
        public string CurrentTimeProduct
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets current usage type.
        /// </summary>
        public UsageType CurrentUsageType
        {
            get;
            private set;
        }

        #endregion
    }
}
