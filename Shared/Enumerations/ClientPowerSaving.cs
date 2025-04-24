using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    public enum ClientPowerSaving
    {
        [Name("Disabled", "CLIENT_POWER_SAVING_DISABLED")]
        Disabled = 0,

        [Name("Shut Down", "CLIENT_POWER_SAVING_SHUT_DOWN")]
        ShutDown = 1,

        [Name("Sleep", "CLIENT_POWER_SAVING_SLEEP")]
        Sleep = 2,
    }
}
