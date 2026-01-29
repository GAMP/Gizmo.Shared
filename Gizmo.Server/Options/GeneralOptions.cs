
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Currency options.
    /// </summary>
    [OptionsConfigurationSection("GENERAL")]
    [StoreOptionsGroup("GENERAL")]
    [MessagePack.MessagePackObject()]
    public sealed class GeneralOptions : IStoreOptions
    {
        [Name("Default culture", "SERVER_OPTION_DEFAULT_CULTURE_NAME")]
        [ExtendedDescription("Specifies default culture", "SERVER_OPTION_DEFAULT_CULTURE_DESCRIPTION")]
        [StoreOptionKey("DEFAULT_CULTURE")]
        [DefaultValue("en-US")]
        [MessagePack.Key(0)]
        public string? DefaultCulture
        {
            get; init;
        } = "en-US";
    }
}
