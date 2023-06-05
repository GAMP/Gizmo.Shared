using System.ComponentModel.DataAnnotations;

namespace Gizmo.UI
{
    /// <summary>
    /// Notification service options.
    /// </summary>
    public sealed class NotificationsOptions
    {
        /// <summary>
        /// Gets default notifications timeout.
        /// </summary>
        /// <remarks>
        /// The value is in seconds.
        /// </remarks>
        [Range(1,int.MaxValue)]
        public int? DefaultTimeout
        {
            get;init;
        }
    }
}
