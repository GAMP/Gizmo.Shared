using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client application ratred event args.
    /// </summary>
    public sealed class ApplicationRateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="appId">App id.</param>
        /// <param name="overallRating">Overall rating.</param>
        /// <param name="userRating">User rating.</param>
        public ApplicationRateEventArgs(int appId, IRating overallRating, IRating userRating)
        {
            ApplicationId = appId;
            OverallRating = overallRating ?? throw new ArgumentNullException("overallRating");
            UserRating = userRating ?? throw new ArgumentNullException("userRating");
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets rated application id.
        /// </summary>
        public int ApplicationId
        {
            get;
            init;
        }

        /// <summary>
        /// Gets application overall rating.
        /// </summary>
        public IRating OverallRating
        {
            get;
            init;
        }

        /// <summary>
        /// Gets application user rating.
        /// </summary>
        public IRating UserRating
        {
            get;
            init;
        }

        #endregion
    }
}
