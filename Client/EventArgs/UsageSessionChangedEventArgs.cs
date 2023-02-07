using System;

namespace Gizmo.Client
{
    /// <summary>
    /// User usage session changed event args.
    /// </summary>
    public sealed class UsageSessionChangedEventArgs : EventArgs
    {
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

        /// <summary>
        /// Gets user id.
        /// </summary>
        public int UserId
        {
            get;
            init;
        }

        /// <summary>
        /// Gets current time poroduct name.
        /// </summary>
        public string CurrentTimeProduct
        {
            get;
            init;
        }

        /// <summary>
        /// Gets current usage type.
        /// </summary>
        public UsageType CurrentUsageType
        {
            get;
            init;
        }
    }
}
