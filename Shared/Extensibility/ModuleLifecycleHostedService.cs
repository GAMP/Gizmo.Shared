using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Extensibility.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Gizmo.Extensibility
{
    /// <summary>
    /// An <see cref="IHostedService"/> that drives the three-phase module lifecycle.
    /// </summary>
    /// <remarks>
    /// <para>
    /// On <see cref="StartAsync"/>:
    /// <list type="number">
    ///   <item><description>
    ///     All <see cref="IModuleInitialize"/> implementations are called in registration order.
    ///     Initialization is intended for one-time setup that must complete before any module starts
    ///     (e.g. schema migrations, resource pre-warming).
    ///   </description></item>
    ///   <item><description>
    ///     All <see cref="IModuleStart"/> implementations are called in registration order.
    ///     Starting is intended for activating background work, opening connections, or subscribing
    ///     to events — anything that should run only after the whole DI container is ready.
    ///   </description></item>
    /// </list>
    /// </para>
    /// <para>
    /// On <see cref="StopAsync"/> all <see cref="IModuleStop"/> implementations are called in
    /// <em>reverse</em> registration order, mirroring a LIFO teardown so that a module that
    /// depends on another stops before the module it depends on.
    /// </para>
    /// <para>
    /// Modules are registered into the three collections by <see cref="ModuleLoader"/> via
    /// factory descriptors that forward to the concrete singleton implementation type, ensuring
    /// the same instance is resolved regardless of which lifecycle interface is requested.
    /// </para>
    /// </remarks>
    public sealed class ModuleLifecycleHostedService : IHostedService
    {
        private readonly IEnumerable<IModuleInitialize> _initializers;
        private readonly IEnumerable<IModuleStart> _starters;
        private readonly IEnumerable<IModuleStop> _stoppers;
        private readonly ILogger<ModuleLifecycleHostedService> _logger;

        public ModuleLifecycleHostedService(
            IEnumerable<IModuleInitialize> initializers,
            IEnumerable<IModuleStart> starters,
            IEnumerable<IModuleStop> stoppers,
            ILogger<ModuleLifecycleHostedService> logger)
        {
            _initializers = initializers;
            _starters = starters;
            _stoppers = stoppers;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            foreach (var init in _initializers)
            {
                _logger.LogDebug("Initializing module: {Type}", init.GetType().Name);
                await init.InitializeAsync(cancellationToken);
            }

            foreach (var start in _starters)
            {
                _logger.LogDebug("Starting module: {Type}", start.GetType().Name);
                await start.StartAsync(cancellationToken);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            foreach (var stop in _stoppers.Reverse())
            {
                _logger.LogDebug("Stopping module: {Type}", stop.GetType().Name);
                await stop.StopAsync(cancellationToken);
            }
        }
    }
}
