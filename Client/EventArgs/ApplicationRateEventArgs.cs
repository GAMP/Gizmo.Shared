using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client application rated event args.
    /// </summary>
    public sealed class ApplicationRateEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="appId">Application id.</param>
        /// <param name="overallRating">Overall rating.</param>
        /// <param name="userRating">User rating.</param>
        public ApplicationRateEventArgs(int appId, IRating overallRating, IRating userRating)
        {
            ApplicationId = appId;
            OverallRating = overallRating ?? throw new ArgumentNullException(nameof(overallRating));
            UserRating = userRating ?? throw new ArgumentNullException(nameof(userRating));
        }

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
    }
}
