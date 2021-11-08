using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Component discovery service.
    /// </summary>
    /// <remarks>
    /// Main purpose of the service is to load external assemblies and provide the means to obtain component metadata information.
    /// </remarks>
    public interface IComponentDiscoveryService
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets additional assemblies to be loaded by router component.
        /// </summary>
        public IEnumerable<Assembly> AdditionalAssemblies { get; }

        /// <summary>
        /// Gets app assembly router component should use.
        /// </summary>
        public Assembly AppAssembly { get; }

        /// <summary>
        /// Gets page module metadata.
        /// </summary>
        IEnumerable<UIPageModuleMetadata> PageModules { get; }

        /// <summary>
        /// Gets root component type.
        /// </summary>
        public Type RootComponentType { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Initializes the service.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        public Task InitializeAsync(CancellationToken ct = default); 

        #endregion
    }
}
