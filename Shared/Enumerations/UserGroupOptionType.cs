using System;

namespace Gizmo
{
    /// <summary>
    /// User group options.
    /// </summary>
    [Flags]
    public enum UserGroupOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Enable personal storage.
        /// </summary>
        EnablePersonalStorage = 1,
        /// <summary>
        /// Hide logout button.
        /// </summary>
        HideLogoutButton = 2,
        /// <summary>
        /// Disallow manual login.
        /// </summary>
        DisallowManualLogin = 4,
        /// <summary>
        /// Allow guest use.
        /// </summary>
        GuestUse = 8,
        /// <summary>
        /// Allow only guest use.
        /// </summary>
        GuestUseOnly = 16,
        /// <summary>
        /// Enables or disables personal files.
        /// </summary>
        EnablePersonalFiles = 32,
        /// <summary>
        /// Disallow login from manager.
        /// </summary>
        DisallowLoginFromManager = 64,
    }
}
