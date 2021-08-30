using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Component discovery service base implementation.
    /// </summary>
    public abstract class ComponentDiscoveryServiceBase : IComponentDiscoveryService
    {
        #region CONSTRUCTOR
        public ComponentDiscoveryServiceBase(IConfiguration configuration,ILogger logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }
        #endregion

        #region FIELDS
        protected HashSet<Assembly> _addtionalAssemblies = new();
        protected Assembly _appAssembly = default;       
        protected List<UIPageModuleMetadata> _pageModules = new();
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region PROPERTIES

        /// <inheritdoc/>
        public virtual IEnumerable<Assembly> AdditionalAssemblies
        {
            get { return _addtionalAssemblies; }
        }

        /// <inheritdoc/>
        public virtual Assembly AppAssembly
        {
            get { return _appAssembly; }
        }        

        /// <inheritdoc/>
        public IEnumerable<UIPageModuleMetadata> PageModules
        {
            get { return _pageModules; }
        }     

        #region PROTECTED

        /// <summary>
        /// Gets configuration instance.
        /// </summary>
        protected IConfiguration Configuration
        {
            get { return _configuration; }
        }

        /// <summary>
        /// Gets logger instance.
        /// </summary>
        protected ILogger Logger
        {
            get { return _logger; }
        }

        /// <summary>
        /// Gets service provider.
        /// </summary>
        protected IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
        }

        #endregion

        #endregion

        #region FUNCTIONS

        /// <inheritdoc/>
        public virtual async Task InitializeAsync(CancellationToken ct)
        {
            //here we should attempt to load any dependent assemblies

            //first we need to get the additional assemblies from configuration
            //second step is to try to download them and load them into current app domain

            //get client app settings
            var appConfiguration = ServiceProvider.GetRequiredService<IOptions<ClientAppSettings>>();

            //get external assemblies from the configuration
            string[] externalAssemblies = appConfiguration.Value.AdditionalAssemblies.ToArray();

            //try to load external librares configured in our settings file
            foreach (var externalAssembly in externalAssemblies)
            {
                try
                {
                    //load external assembly
                    await LoadAssemblyAsync(externalAssembly, ct);
                }
                catch (Exception ex)
                {
                    Logger.LogWarning(ex, "Could not load external assembly, assembly name : {AssemblyName}", externalAssembly);
                }
            }

            //create list of all assembiles
            var targetAssemblies = AdditionalAssemblies
                .ToArray()
                .Append(AppAssembly)
                .ToArray();

            _pageModules = targetAssemblies
                .SelectMany(assembly => assembly.GetTypes().Where(type => type.GetCustomAttribute<PageUIModuleAttribute>() != null))
                .Select(type => new UIPageModuleMetadata()
                {
                    Title = type.GetCustomAttribute<PageUIModuleAttribute>()?.Title,
                    TitleLocalizationKey = type.GetCustomAttribute<PageUIModuleAttribute>()?.TitleLocalizationKey,
                    Description = type.GetCustomAttribute<PageUIModuleAttribute>()?.Description,
                    DescriptionLocalizationKey = type.GetCustomAttribute<PageUIModuleAttribute>()?.DescriptionLocalizationKey,
                    DefaultRoute = type.GetCustomAttribute<DefaultRouteAttribute>()?.Template,
                    DefaultRouteMatch = type.GetCustomAttribute<DefaultRouteAttribute>()?.DefaultRouteMatch ?? NavlinkMatch.All,
                    Routes = GetRoutes(type),
                    DisplayOrder = type.GetCustomAttribute<ModuleDisplayOrderAttribute>()?.DisplayOrder ?? 0,                                 
                    Guid = type.GetCustomAttribute<ModuleGuidAttribute>()?.Guid,
                    Type = type
                })
                .OrderBy(metaData => metaData.DisplayOrder)
                .ToList();

            foreach (var pageModule in _pageModules)
            {
                Logger.LogInformation("Found page module {ModuleType}", pageModule.Type.Name);
                Logger.LogInformation("Default route {DefaultRoute}", pageModule.DefaultRoute);
                foreach (var route in pageModule.Routes)
                {
                    Logger.LogInformation("Found route template {Route}", route);
                }
            }
        }

        /// <summary>
        /// Loads the specified library into current appdomain and service.
        /// </summary>
        /// <param name="assemblyName">Assembly name.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        protected virtual Task LoadAssemblyAsync(string assemblyName, CancellationToken ct)
        {
            string fullAssemblyPath = Path.Combine(Environment.CurrentDirectory, assemblyName);
            
            var assembly = AppDomain.CurrentDomain.Load(fullAssemblyPath);
            _addtionalAssemblies.Add(assembly);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets routes from the specified type.
        /// </summary>
        /// <param name="type">Component type.</param>
        /// <returns>List of routes exposed by component.</returns>
        protected abstract IEnumerable<string> GetRoutes(Type type);

        #endregion
    }
}
