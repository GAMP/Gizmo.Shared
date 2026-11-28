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
        public const int WelcomeLabelMaxLength = 40;
        public const int WelcomeSloganLineMaxLength = 60;
        public const int WelcomeDescriptionMaxLength = 240;

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

        /// <summary>
        /// Gets the label above the welcome title.
        /// </summary>
        [Name("Welcome label")]
        [ExtendedDescription("Specifies the label above the mobile app welcome title")]
        [StoreOptionKey("WELCOME_LABEL")]
        [DefaultValue(null)]
        [StringLength(WelcomeLabelMaxLength)]
        [RegularExpression(@"\A[^\r\n]*\z", ErrorMessage = "The {0} field must be a single line.")]
        [MessagePack.Key(1)]
        public string? WelcomeLabel { get; init; }

        /// <summary>
        /// Gets the first line of the welcome slogan.
        /// </summary>
        [Name("Welcome slogan line 1")]
        [ExtendedDescription("Specifies the first line of the mobile app welcome slogan")]
        [StoreOptionKey("WELCOME_SLOGAN_LINE_1")]
        [DefaultValue(null)]
        [StringLength(WelcomeSloganLineMaxLength)]
        [RegularExpression(@"\A[^\r\n]*\z", ErrorMessage = "The {0} field must be a single line.")]
        [MessagePack.Key(2)]
        public string? WelcomeSloganLine1 { get; init; }

        /// <summary>
        /// Gets the second line of the welcome slogan.
        /// </summary>
        [Name("Welcome slogan line 2")]
        [ExtendedDescription("Specifies the second line of the mobile app welcome slogan")]
        [StoreOptionKey("WELCOME_SLOGAN_LINE_2")]
        [DefaultValue(null)]
        [StringLength(WelcomeSloganLineMaxLength)]
        [RegularExpression(@"\A[^\r\n]*\z", ErrorMessage = "The {0} field must be a single line.")]
        [MessagePack.Key(3)]
        public string? WelcomeSloganLine2 { get; init; }

        /// <summary>
        /// Gets the description below the welcome slogan.
        /// </summary>
        [Name("Welcome description")]
        [ExtendedDescription("Specifies the description below the mobile app welcome slogan")]
        [StoreOptionKey("WELCOME_DESCRIPTION")]
        [DefaultValue(null)]
        [StringLength(WelcomeDescriptionMaxLength)]
        [MessagePack.Key(4)]
        public string? WelcomeDescription { get; init; }
    }
}
