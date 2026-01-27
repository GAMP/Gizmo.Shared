#nullable enable

using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Regional options.
    /// </summary>
    [OptionsConfigurationSection("REGIONAL")]
    [StoreOptionsGroup("REGIONAL")]
    [MessagePack.MessagePackObject()]
    public sealed class RegionalOptions : IStoreOptions
    {
        /// <summary>
        /// Gets or sets country code.
        /// </summary>
        /// <remarks>
        /// We should use ISO 3166-1 alpha-2 country code.<br></br>
        /// <a href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2"></a>
        /// </remarks>
        [Name("Country code", "SERVER_OPTION_COUNTRY_CODE_NAME")]
        [ExtendedDescription("Specifies country code", "SERVER_OPTION_REGIONAL_COUNTRY_CODE_DESCRIPTION")]
        [StoreOptionKey("COUNTRY_CODE")]
        [StringLength(2)]
        [MessagePack.Key(0)]
        public string? CountryCode { get; init; }

        /// <summary>
        /// Gets or sets time zone.
        /// </summary>
        /// <remarks>
        /// We should use IANA time zone database.<br></br> 
        /// <a href="https://en.wikipedia.org/wiki/List_of_tz_database_time_zones"></a>
        /// </remarks>
        [Name("Time zone", "SERVER_OPTION_REGIONAL_TIME_ZONE_NAME")]
        [ExtendedDescription("Specifies time zone", "SERVER_OPTION_REGIONAL_TIME_ZONE_DESCRIPTION")]
        [StoreOptionKey("TIME_ZONE")]
        [MessagePack.Key(1)]
        public string? TimeZone { get; init; }
    }
}
