using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Client.UI.View.Services
{
    /// <summary>
    /// View service interface.
    /// </summary>
    public interface IViewService : IDisposable
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Initializes the service.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        Task IntializeAsync(CancellationToken ct = default); 

        #endregion
    }
}
