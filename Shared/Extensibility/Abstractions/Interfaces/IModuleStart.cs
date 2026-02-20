using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Module start contract.
    /// </summary>
    public interface IModuleStart
    {
        /// <summary>
        /// Starts module.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        public Task StartAsync(CancellationToken cancellationToken = default);
    }
}
