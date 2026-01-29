
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.Options
{
    /// <summary>
    /// Client regional options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ClientRegionalOptions
    {
        /// <summary>
        /// Gets or sets country code.
        /// </summary>
        /// <remarks>
        /// We should use ISO 3166-1 alpha-2 country code.<br></br>
        /// <a href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2"></a>
        /// </remarks>
        [StringLength(2)]
        [MessagePack.Key(0)]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Gets or sets time zone.
        /// </summary>
        /// <remarks>
        /// We should use IANA time zone database.<br></br> 
        /// <a href="https://en.wikipedia.org/wiki/List_of_tz_database_time_zones"></a>
        /// </remarks>
        [MessagePack.Key(1)]
        public string? TimeZone { get; set; }
    }
}
