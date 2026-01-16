#nullable enable

using System;

namespace Gizmo.Shared.Plugins
{
    /// <summary>
    /// License manager plugin attribute.
    /// </summary>
    /// <remarks>Used to annotate and describe an license management plugin.</remarks>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class LicenseManagerPluginAttribute : Attribute
    {
        /// <summary>
        /// Plugin configuration type.
        /// </summary>
        public Type? ConfigurationType
        {
            get; set;
        }

        /// <summary>
        /// Plugin license key type.
        /// </summary>
        public Type? KeyType
        {
            get; set;
        }
    }
}
