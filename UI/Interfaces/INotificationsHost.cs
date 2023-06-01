using System.Threading.Tasks;

namespace Gizmo.UI
{
    /// <summary>
    /// Notifications host interface.
    /// </summary>
    /// <remarks>
    /// An manipulation interface used for overlay area that hosts notfications.<br></br>
    /// In WPF it represents an overlay window, in web projects this should be an page overlay.
    /// </remarks>
    public interface INotificationsHost
    {
        /// <summary>
        /// Shows host window.
        /// </summary>
        public Task ShowAsync();

        /// <summary>
        /// Hides host window.
        /// </summary>
        public Task HideAsyc();
    }
}
