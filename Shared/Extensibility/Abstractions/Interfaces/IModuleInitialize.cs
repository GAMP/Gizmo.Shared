using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Module initialization contract.
    /// </summary>
    public interface IModuleInitialize
    {
        /// <summary>
        /// Initializes module.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        Task InitializeAsync(CancellationToken cancellationToken = default);
    }
}
