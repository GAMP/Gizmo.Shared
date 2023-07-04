#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// Integration options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class IntegrationOptions
    {
        /// <summary>
        /// Gets or sets location id.
        /// </summary>
        [DefaultValue(null)]
        [MaxLength(36)] // max length of guid that is will be used mostly
        [MessagePack.Key(0)]
        public string? LocationId
        {
            get;set;
        }
    }
}
