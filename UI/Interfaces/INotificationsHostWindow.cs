using System.Threading.Tasks;

namespace Gizmo.UI
{
    /// <summary>
    /// Desktop UI notifications host window interface.
    /// </summary>
    public interface INotificationsHostWindow
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
