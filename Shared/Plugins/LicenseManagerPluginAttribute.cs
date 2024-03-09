#nullable enable

using System;

namespace Gizmo.Shared.Plugins
{
    public sealed class LicenseManagerPluginAttribute : Attribute
    {
        public LicenseManagerPluginAttribute(string type)
        {
            TypeName = type;
        }

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

        /// <summary>
        /// Plugin type iname.
        /// </summary>
        public string TypeName { get; set; }
    }
}
