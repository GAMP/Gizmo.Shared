using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Gizmo.Extensibility
{
    public sealed class ModuleLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver _resolver;
        private readonly HashSet<string> _sharedAssemblyNames;

        public ModuleLoadContext(
            string moduleMainAssemblyPath,
            IEnumerable<string>? sharedAssemblyNames = null)
            : base(name: $"module:{Path.GetFileNameWithoutExtension(moduleMainAssemblyPath)}",
                   isCollectible: false)
        {
            _resolver = new AssemblyDependencyResolver(moduleMainAssemblyPath);

            _sharedAssemblyNames = new HashSet<string>(
                sharedAssemblyNames ?? Array.Empty<string>(),
                StringComparer.OrdinalIgnoreCase);
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
