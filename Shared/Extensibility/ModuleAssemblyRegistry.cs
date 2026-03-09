using System.Collections.Generic;
using System.Reflection;

namespace Gizmo.Extensibility
{
    /// <summary>
    /// Collects assemblies loaded by <see cref="ModuleLoader"/> so that downstream consumers
    /// (e.g. ASP.NET Core MVC application-part registration, static-file providers) can enumerate
    /// all plugin assemblies without reloading them.
    /// </summary>
    public sealed class ModuleAssemblyRegistry
    {
        private readonly List<ModuleAssemblyEntry> _entries = new();

        /// <summary>
        /// All registered module assemblies.
        /// </summary>
        public IReadOnlyList<ModuleAssemblyEntry> Entries => _entries;

        /// <summary>
        /// Adds a loaded module assembly to the registry.
        /// </summary>
        internal void Add(Assembly assembly, string baseDirectory, string moduleName)
        {
            _entries.Add(new ModuleAssemblyEntry(assembly, baseDirectory, moduleName));
        }
    }

    /// <summary>
    /// Describes a single module assembly loaded by the plugin system.
    /// </summary>
    /// <param name="Assembly">The loaded module assembly.</param>
    /// <param name="BaseDirectory">The directory containing the module DLL.</param>
    /// <param name="ModuleName">The module name (DLL file name without extension).</param>
    public sealed record ModuleAssemblyEntry(
        Assembly Assembly,
        string BaseDirectory,
        string ModuleName);
}
