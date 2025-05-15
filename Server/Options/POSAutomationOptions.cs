using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("POSAUTOMATION")]
    [StoreOptionsGroup("POS_AUTOMATION")]
    [MessagePack.MessagePackObject()]
    public sealed class POSAutomationOptions : IStoreOptions
    {
        [Name("Auto delivery", "SERVER_OPTION_POS_AUTOMATION_AUTO_DELIVERY_NAME")]
        [StoreOptionKey("AUTO_DELIVERY")]
        [DefaultValue(true)]
        [MessagePack.Key(0)]
        public bool AutoDelivery { get; init; }

        [Name("Auto prepare", "SERVER_OPTION_POS_AUTOMATION_AUTO_PREPARE_NAME")]
        [StoreOptionKey("AUTO_PREPARE")]
        [DefaultValue(true)]
        [MessagePack.Key(1)]
        public bool AutoPrepare { get; init; }

        [Name("Auto guest login", "SERVER_OPTION_POS_AUTO_GUEST_LOGIN_NAME")]
        [StoreOptionKey("AUTO_GUEST_LOGIN")]
        [DefaultValue(false)]
        [MessagePack.Key(2)]
        public bool AutoGuestLogin { get; set; }
    }
}
