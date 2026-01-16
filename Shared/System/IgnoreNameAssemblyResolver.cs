using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace System
{
    /// <summary>
    /// Helper class to resolve assemblies ignoring version mismatches for specified assembly name prefixes.
    /// </summary>
    public static class IgnoreNameAssemblyResolver
    {
        /// <summary>
        /// Tries to resolve an assembly by name, ignoring version mismatches for specified prefixes.
        /// </summary>
        /// <param name="args">Args.</param>
        /// <param name="logger">Logger.</param>
        /// <param name="allowedPrefixes">Allowed assembly name prefixes.</param>
        /// <returns>Resolved assembly, <see langword="null"/> if no assembly resolved.</returns>
        public static Assembly? TryResolve(ResolveEventArgs args, ILogger logger, string[] allowedPrefixes)
        {
            try
            {
                var requested = new AssemblyName(args.Name);
                var name = requested.Name;

                if (string.IsNullOrWhiteSpace(name))
                    return null;

                // Only relax version for your own assemblies
                if (allowedPrefixes.Length > 0 && !allowedPrefixes.Any(p => name.StartsWith(p, StringComparison.Ordinal)))
                    return null;

                logger.LogTrace("Assembly resolve requested: {Requested} (requesting: {ReqAsm})",
                    args.Name, args.RequestingAssembly?.FullName ?? "Unknown");

                var match = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => string.Equals(a.GetName().Name, name, StringComparison.Ordinal));

                if (match != null)
                {
                    logger.LogTrace("Resolved to loaded assembly: {FullName}", match.FullName);
                    return match;
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Assembly resolve handler error.");
                return null;
            }
        }
    }
}
