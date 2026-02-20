using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Module stop contract.
    /// </summary>
    public interface IModuleStop
    {
        /// <summary>
        /// Stops module.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        public Task StopAsync(CancellationToken cancellationToken = default);
    }
}
