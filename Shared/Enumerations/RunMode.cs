namespace Gizmo
{
    /// <summary>
    /// Run mode enumeration.
    /// </summary>
    public enum RunMode
    {
        /// <summary>
        /// Full screen.
        /// </summary>
        [Localized("RUN_MODE_FULL_SCREEN")]
        FullScreen = 0,

        /// <summary>
        /// Minimized.
        /// </summary>
        [Localized("RUN_MODE_MINIMIZED")]
        Minimized = 1,

        /// <summary>
        /// Maximized.
        /// </summary>
        [Localized("RUN_MODE_MAXIMIZED")]
        Maximized = 2,

        /// <summary>
        /// Hidden.
        /// </summary>
        [Localized("RUN_MODE_HIDDEN")]
        Hidden = 3,

        /// <summary>
        /// Normal.
        /// </summary>
        [Localized("RUN_MODE_NORMAL")]
        Normal = 4
    }
}