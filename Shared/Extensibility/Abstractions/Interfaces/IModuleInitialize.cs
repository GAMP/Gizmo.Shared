using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    public interface IModuleInitialize
    {
        Task InitializeAsync(CancellationToken cancellationToken = default);
    }
}
