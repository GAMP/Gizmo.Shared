using System;

namespace Gizmo.Server
{
    [Flags()]
    public enum UserRoles
    {
        /// <summary>
        /// No role.
        /// </summary>
        None = 0,

        /// <summary>
        /// Simple user.
        /// </summary>
        User = 1,

        /// <summary>
        /// Guest user role.
        /// </summary>
        Guest = 2,

        /// <summary>
        /// Operator.
        /// </summary>
        Operator = 4
    }
}
