
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.Options
{
    /// <summary>
    /// Integration options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class IntegrationOptions
    {
        /// <summary>
        /// Gets or sets integration id.
        /// </summary>
        [DefaultValue(null)]
        [MaxLength(36)] // max length of guid that is will be used mostly
        [MessagePack.Key(0)]
        public string? IntegrationId
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

        /// <summary>
        /// Host id.
        /// </summary>
        [MessagePack.Key(3)]
        public int HostId { get; set; }

        /// <summary>
        /// Host guid.
        /// </summary>
        [MessagePack.Key(4)]
        public Guid HostGuid { get; set; }

        /// <summary>
        /// Host number.
        /// </summary>
        [MessagePack.Key(5)]
        public int HostNumber { get; set; }

        /// <summary>
        /// Host group id.
        /// </summary>
        [MessagePack.Key(6)]
        public int? HostGroupId { get; set; }
    }
}
