using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Manager features options.
    /// </summary>
    [OptionsConfigurationSection("MANAGER:FEATURES")]
    [StoreOptionsGroup("MANAGER_FEATURES")]
    [MessagePack.MessagePackObject()]
    public sealed class ManagerFeaturesOptions : IStoreOptions
    {
        [Name("Sales module", "SERVER_OPTION_MANAGER_FEATURES_SALES_MODULE_NAME")]
        [ExtendedDescription("Enable sales module", "SERVER_OPTION_MANAGER_FEATURES_SALES_MODULE_DESCRIPTION")]
        [DefaultValue(true)]
        [StoreOptionKey("SALES_MODULE")]
        [MessagePack.Key(0)]
        public bool SalesModule { get; init; }

        [Name("Reservations module", "SERVER_OPTION_MANAGER_FEATURES_RESERVATIONS_MODULE_NAME")]
        [ExtendedDescription("Enable reservations module", "SERVER_OPTION_MANAGER_FEATURES_RESERVATIONS_MODULE_DESCRIPTION")]
        [DefaultValue(true)]
        [StoreOptionKey("RESERVATIONS_MODULE")]
        [MessagePack.Key(1)]
        public bool ReservationsModule { get; init; }
    }
}
