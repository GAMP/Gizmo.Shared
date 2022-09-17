#nullable enable
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Metadata describing a single option entry.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class StoreOptionMetadata
    {
        #region PROPERTIES

        /// <summary>
        /// Gets option key.
        /// </summary>
        [MessagePack.Key(0)]
        public string Key { get; init; } = string.Empty;

        /// <summary>
        /// Gets option name.
        /// </summary>
        [MessagePack.Key(1)]
        public string Name { get;init; } = string.Empty;

        /// <summary>
        /// Gets optional default value.
        /// </summary>
        [MessagePack.Key(2)]
        public string? DefaultValue { get;init;}

        /// <summary>
        /// Gets option value type full name.
        /// </summary>
        [MessagePack.Key(3)]
        public string ValueTypeName { get; init; } =string.Empty;

        /// <summary>
        /// Gets value property name.
        /// </summary>
        [MessagePack.Key(4)] 
        public string ValuePropertyName { get; init; } = string.Empty;

        /// <summary>
        /// Gets option description.
        /// </summary>
        [MessagePack.Key(5)]
        public string? Description
        {
            get;
            init;
        }

        /// <summary>
        /// Gets allowed values.
        /// </summary>
        [MessagePack.Key(6)]
        public IEnumerable<StoreOptionAllowedValueMetadata> AllowedValues { get; init; } = Enumerable.Empty<StoreOptionAllowedValueMetadata>();

        #endregion
    }
}
