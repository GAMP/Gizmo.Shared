using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.UI.View.Services
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

        /// <summary>
        /// Execute the command for the Gizmo.Client.UI from a URL
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        /// <param name="cTocken"></param>
        /// <returns></returns>
        Task ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cTocken = default) where TCommand : notnull, IViewServiceCommand;

        #endregion
    }
}
