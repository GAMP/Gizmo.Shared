using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    public enum ClientLogoutAction
    {
        /// <summary>
        /// No action.
        /// </summary>
        [Name("No Action", "CLIENT_LOGOUT_ACTION_NO_ACTION")]
        NoAction = -1,

        /// <summary>
        /// Reboot.
        /// </summary>
        [Name("Reboot", "CLIENT_LOGOUT_ACTION_REBOOT")]
        Reboot = 0,

        /// <summary>
        /// Close programs.
        /// </summary>
        [Name("Close Programs", "CLIENT_LOGOUT_ACTION_CLOSE_PROGRAMS")]
        ClosePrograms = 1,

        /// <summary>
        /// Turn off.
        /// </summary>
        [Name("Turn Off", "CLIENT_LOGOUT_ACTION_TURN_OFF")]
        TurnOff = 2,

        /// <summary>
        /// Log off.
        /// </summary>
        [Name("Log Off", "CLIENT_LOGOUT_ACTION_LOG_OFF")]
        LogOff = 3,

        /// <summary>
        /// Stand by.
        /// </summary>
        [Name("Stand By", "CLIENT_LOGOUT_ACTION_STAND_BY")]
        StandBy = 4,

        /// <summary>
        /// Maintenance.
        /// </summary>
        [Name("Admin Mode", "CLIENT_LOGOUT_ACTION_ADMIN_MODE")]
        AdminMode = 5,
    }
}
