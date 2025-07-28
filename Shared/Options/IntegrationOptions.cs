#nullable enable

using System;
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
            get; set;
        } = null;

        /// <summary>
        /// Optional branch id.
        /// </summary>
        [MessagePack.Key(1)]
        [DefaultValue(null)]
        public int? BranchId { get; set; } = null;

        /// <summary>
        /// Optional branch guid.
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(null)]
        public Guid? BranchGuid { get; set; } = null;
    }
}
