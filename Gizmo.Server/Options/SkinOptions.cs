#nullable enable

using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Skin options.
    /// </summary>
    [OptionsConfigurationSection("SKIN")]
    [StoreOptionsGroup("SKIN")]
    [MessagePack.MessagePackObject()]
    public sealed class SkinOptions : IStoreOptions
    {
        /// <summary>
        /// Gets default skin.
        /// </summary>
        [Name("Default skin", "SERVER_OPTION_DEFAULT_SKIN")]
        [ExtendedDescription("Specifies default skin", "SERVER_OPTION_DEFAULT_SKIN")]
        [StoreOptionKey("DEFAULT_SKIN")]
        [DefaultValue(null)]
        [MessagePack.Key(0)]
        public string? DefaultSkin
        {
            get; set;
        }
    }
}
