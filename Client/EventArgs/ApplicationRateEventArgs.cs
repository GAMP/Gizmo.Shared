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
        public ApplicationRateEventArgs(int appId, Rating overallRating, Rating userRating)
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
        public Rating OverallRating
        {
            get;
            init;
        }

        /// <summary>
        /// Gets application user rating.
        /// </summary>
        public Rating UserRating
        {
            get;
            init;
        }

        #endregion
    }
}
