namespace Gizmo
{
    public enum ClientLogoutAction
    {
        /// <summary>
        /// No action.
        /// </summary>
        NoAction = -1,

        /// <summary>
        /// Reboot.
        /// </summary>
        Reboot = 0,

        /// <summary>
        /// Close programs.
        /// </summary>
        ClosePrograms = 1,

        /// <summary>
        /// Turn off.
        /// </summary>
        TurnOff = 2,

        /// <summary>
        /// Log off.
        /// </summary>
        LogOff = 3,

        /// <summary>
        /// Stand by.
        /// </summary>
        StandBy = 4,

        /// <summary>
        /// Maintenance.
        /// </summary>
        AdminMode = 5,
    }
}
