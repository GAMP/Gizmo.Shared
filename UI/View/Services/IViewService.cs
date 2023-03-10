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
        /// Execute the command of the service.
        /// </summary>
        /// <typeparam name="TCommand">Command type that implements IViewServiceCommand interface.</typeparam>
        /// <param name="command">Command from URL.</param>
        /// <param name="cToken">CancellationToken.</param>
        /// <returns>Task of the command.</returns>
        Task ExecuteCommandAsync<TCommand>(TCommand command, CancellationToken cToken = default) where TCommand : notnull, IViewServiceCommand;

        #endregion
    }
}
