using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Mobile app options.
    /// </summary>
    [OptionsConfigurationSection("MOBILE")]
    [StoreOptionsGroup("MOBILE")]
    [MessagePack.MessagePackObject()]
    public sealed class MobileOptions : IStoreOptions
    {
        /// <summary>
        /// Gets mobile app logo image id.
        /// </summary>
        [Name("Logo image")]
        [ExtendedDescription("Specifies mobile app logo image")]
        [StoreOptionKey("LOGO_IMAGE_ID")]
        [DefaultValue(null)]
        [MessagePack.Key(0)]
        public int? LogoImageId
        {
            get; init;
        }
    }
}
