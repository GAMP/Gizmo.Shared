#nullable enable

using System;

// TODO : Change namespace

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
        /// <remarks>
        /// This value is optional since some license managers may not require configuration.
        /// </remarks>
        public Type? ConfigurationType
        {
            get; set;
        }

        /// <summary>
        /// Plugin license key type.
        /// </summary>
        public required Type KeyType
        {
            get; set;
        }
    }
}
