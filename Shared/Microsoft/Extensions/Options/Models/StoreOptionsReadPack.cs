#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Represents options read from the store.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class StoreOptionsReadPack
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="optionsType">Options type.</param>
        /// <param name="values">Options values.</param>
        public StoreOptionsReadPack(string optionsType, string groupName, string? section, Dictionary<StoreOptionMetadata, StoreOptionReadValue> values)
        {
            OptionsType = optionsType;
            GroupName = groupName;
            Section = section;
            ValueStore = values;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets options class type.
        /// </summary>
        /// <remarks>
        /// This will be set to the fully qualifed type name.
        /// </remarks>
        [MessagePack.Key(0)]
        public string OptionsType { get; }

        /// <summary>
        /// Gets options group name.
        /// </summary>
        [MessagePack.Key(1)]
        public string GroupName
        {
            get;
        }

        /// <summary>
        /// Gets options section.
        /// </summary>
        [MessagePack.Key(2)]
        public string? Section
        {
            get; init;
        }

        /// <summary>
        /// Gets options metadata and current values.
        /// </summary>
        [MessagePack.IgnoreMember()]
        public IEnumerable<StoreOptionMetadataValue> Values
        {
            get { return ValueStore.Select(kv => new StoreOptionMetadataValue(kv.Key, kv.Value)); }
        }

        /// <summary>
        /// Gets options metadata and current values.
        /// </summary>
        [JsonIgnore()]
        [MessagePack.Key(3)]
        public Dictionary<StoreOptionMetadata, StoreOptionReadValue> ValueStore { get; }

        #endregion
    }
}
