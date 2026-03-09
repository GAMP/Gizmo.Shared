using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Gizmo.Extensibility
{
    public sealed class ModuleLoadContext : AssemblyLoadContext
    {
        /// <summary>
        /// Assembly names that are always resolved from the host's Default ALC, regardless of
        /// what the caller provides. These are framework and contract assemblies where type
        /// identity must be shared between the host and all plugins — if a plugin loaded its own
        /// copy the types would be incompatible with the host's interfaces.
        /// </summary>
        public static readonly IReadOnlyList<string> DefaultShared = new[]
        {
            // Shared contracts assembly — IModuleInitialize, IServiceRegistrar, ModuleContext, etc.
            // Namespace Gizmo.Extensibility.Abstractions lives inside Gizmo.Shared.dll.
            "Gizmo.Shared",

            // DAL — entity types and DbContext provider; plugins that access the database directly
            // must use the same types as the host, otherwise EF entity identity checks fail.
            "Gizmo.DAL",
            "Gizmo.DAL.Entities",

            // Server-side shared contracts (SignalR hubs, server service interfaces, etc.)
            "Gizmo.Server.Shared",

            // Client contract shared between server and client (e.g. client session types)
            "Gizmo.Client.Shared",

            // Payment, SMS and POS provider contracts — plugins implement these interfaces
            "Gizmo.PaymentProviders",
            "Gizmo.SmsProviders",
            "Gizmo.PointOfService",

            // Web API models and client — request/response types and API client shared across the HTTP boundary
            "Gizmo.Web.Api.Models",
            "Gizmo.Web.Api.Client",

            // Manager shared library — shared types between the manager UI and plugins
            "Gizmo.Web.Manager.Shared",

            // EF Core — DbSet<T>, DbContext, IQueryable provider; plugins that query the DB
            // must use the same DbSet<T> type as the host, otherwise method signatures diverge
            // and the JIT throws MissingMethodException on DbContext property accessors.
            "Microsoft.EntityFrameworkCore",
            "Microsoft.EntityFrameworkCore.Abstractions",
            "Microsoft.EntityFrameworkCore.Relational",

            // DI — IServiceCollection used in RegisterServices; must be the same type as the host's
            "Microsoft.Extensions.DependencyInjection",
            "Microsoft.Extensions.DependencyInjection.Abstractions",

            // Configuration — IConfiguration stored in ModuleContext
            "Microsoft.Extensions.Configuration",
            "Microsoft.Extensions.Configuration.Abstractions",
            "Microsoft.Extensions.Configuration.Binder",

            // Hosting — IHostEnvironment, IHostedService
            "Microsoft.Extensions.Hosting",
            "Microsoft.Extensions.Hosting.Abstractions",

            // Logging — ILogger, ILoggerFactory injected into module services
            "Microsoft.Extensions.Logging",
            "Microsoft.Extensions.Logging.Abstractions",

            // Options — IOptions<T>, IOptionsMonitor<T>, Configure<T>
            "Microsoft.Extensions.Options",
            "Microsoft.Extensions.Options.ConfigurationExtensions",

            // Primitives — IChangeToken, StringValues; used internally by config and options
            "Microsoft.Extensions.Primitives",
        };

        private readonly AssemblyDependencyResolver _resolver;
        private readonly HashSet<string> _sharedAssemblyNames;

        /// <summary>
        /// Creates a load context for a plugin assembly.
        /// <see cref="DefaultShared"/> is always included; <paramref name="additionalSharedAssemblyNames"/>
        /// adds further assemblies to resolve from the host rather than from the plugin folder.
        /// </summary>
        public ModuleLoadContext(
            string moduleMainAssemblyPath,
            IEnumerable<string>? additionalSharedAssemblyNames = null)
            : base(name: $"module:{Path.GetFileNameWithoutExtension(moduleMainAssemblyPath)}",
                   isCollectible: false)
        {
            _resolver = new AssemblyDependencyResolver(moduleMainAssemblyPath);

            _sharedAssemblyNames = new HashSet<string>(DefaultShared, StringComparer.OrdinalIgnoreCase);
            if (additionalSharedAssemblyNames != null)
                foreach (var name in additionalSharedAssemblyNames)
                    _sharedAssemblyNames.Add(name);
        }

        protected override Assembly? Load(AssemblyName assemblyName)
        {
            // Share host/contract assemblies from Default ALC (critical for type identity)
            if (_sharedAssemblyNames.Contains(assemblyName.Name ?? string.Empty))
                return null;

            var path = _resolver.ResolveAssemblyToPath(assemblyName);
            return path != null ? LoadFromAssemblyPath(path) : null;
        }

        protected override nint LoadUnmanagedDll(string unmanagedDllName)
        {
            var path = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            return path != null ? LoadUnmanagedDllFromPath(path) : 0;
        }
    }
}
