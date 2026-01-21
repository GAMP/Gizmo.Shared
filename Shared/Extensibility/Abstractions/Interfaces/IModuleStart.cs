using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    public interface IModuleStart
    {
        /// <summary>
        /// Starts the module.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task StartAsync(CancellationToken cancellationToken = default);
    }
}
