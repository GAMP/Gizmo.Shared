using System;

namespace Gizmo
{
    /// <summary>
    /// Module types.
    /// </summary>
    [Flags()]
    public enum ModuleType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Manager.
        /// </summary>
        Manager = 1,
        /// <summary>
        /// Client.
        /// </summary>
        Client = 2,
        /// <summary>
        /// Service.
        /// </summary>
        Service = 4,
        /// <summary>
        /// Web manager.
        /// </summary>
        WebManager = 8
    }
}
