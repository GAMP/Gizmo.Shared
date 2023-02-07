using System;

namespace Gizmo
{
    /// <summary>
    /// Sex enumeration.
    /// </summary>
    [Flags()]
    public enum Sex
    {
        /// <summary>
        /// Unspecified.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// Male.
        /// </summary>
        Male = 1,

        /// <summary>
        /// Female.
        /// </summary>
        Female = 2,
    }
}
