
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("CLIENTGENERAL")]
    [StoreOptionsGroup("CLIENT_GENERAL")]
    [MessagePack.MessagePackObject()]
    public sealed class ClientGeneralOptions : IStoreOptions
    {
        [Name("Default culture")]
        [ExtendedDescription("Specifies default client UI culture")]
        [StoreOptionKey("DEFAULT_CULTURE")]
        [DefaultValue("en-US")]
        [MessagePack.Key(0)]
        public string? DefaultCulture
        {
            get; init;
        } = "en-US";

        [Name("Logout action")]
        [ExtendedDescription("Specifies client logout action")]
        [StoreOptionKey("LOGOUT_ACTION")]
        [DefaultValue(ClientLogoutAction.Reboot)]
        [MessagePack.Key(1)]
        public ClientLogoutAction LogoutAction
        {
            get; init;
        }

        [Name("Power saving")]
        [ExtendedDescription("Specifies client power saving")]
        [StoreOptionKey("IDLE_POWER_SAVING")]
        [DefaultValue(ClientPowerSaving.Disabled)]
        [MessagePack.Key(2)]
        public ClientPowerSaving IdlePowerSaving { get; init; }

        [Name("Power saving delay time")]
        [ExtendedDescription("Specifies client idle power saving delay time")]
        [StoreOptionKey("IDLE_POWER_SAVING_DELAY")]
        [DefaultValue(0)]
        [MessagePack.Key(3)]
        public int IdlePowerSavingDelay { get; init; }

        [Name("Client data path")]
        [ExtendedDescription("Specifies client client data path")]
        [StoreOptionKey("DATA_PATH")]
        [DefaultValue(@"%PROGRAMDATA%\NETProjects\Gizmo Client\")]
        [MessagePack.Key(4)]
        public string? DataPath { get; init; }

        [Name("Manager password")]
        [ExtendedDescription("Specifies manager password")]
        [StoreOptionKey("MANAGER_PASSWORD")]
        [DefaultValue(null)]
        [Protect()]
        [MessagePack.Key(5)]
        public string? ManagerPassword { get; init; }

        [Name("Enable concurrent execution limit")]
        [ExtendedDescription("Specifies concurrent execution limit is enabled")]
        [StoreOptionKey("CONCURRENT_EXECUTION_LIMIT_ENABLE")]
        [DefaultValue(false)]
        [MessagePack.Key(6)]
        public bool IsConcurrentExecutionLimitEnabled { get; init; }
    }
}
