using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Extensibility.Abstractions
{
    public interface IModuleStop
    {
        public Task StopAsync(CancellationToken cancellationToken = default);
    }
}
