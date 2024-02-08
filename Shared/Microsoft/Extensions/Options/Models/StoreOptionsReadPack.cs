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
        /// <param name="groupName">Group name.</param>
        /// <param name="section">Section.</param>
        /// <param name="values">Options values.</param>
        [JsonConstructor()]
        public StoreOptionsReadPack(string optionsType, string groupName, string? section, IEnumerable<StoreOptionsPair> values)
        {
            OptionsType = optionsType;
            GroupName = groupName;
            Section = section;
            Values = values;
            ValueStore = values.ToDictionary(x => x.Metadata, x => x.Value);
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="optionsType">Options type.</param>
        /// <param name="groupName">Group name.</param>
        /// <param name="section">Section.</param>
        /// <param name="values">Options values.</param>
        public StoreOptionsReadPack(string optionsType, string groupName, string? section, Dictionary<StoreOptionMetadata, StoreOptionReadValue> values)
        {
            OptionsType = optionsType;
            GroupName = groupName;
            Section = section;
            Values = values.Select(x=> new  StoreOptionsPair(x.Key,x.Value));
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
            get; 
        }

        /// <summary>
        /// Gets options metadata and current values.
        /// </summary>
        [MessagePack.IgnoreMember()]
        public IEnumerable<StoreOptionsPair> Values
        {
            get;
        } = [];

        /// <summary>
        /// Gets options metadata and current values.
        /// </summary>
        [JsonIgnore()]
        [MessagePack.Key(3)]
        public Dictionary<StoreOptionMetadata, StoreOptionReadValue> ValueStore { get; } = [];

        #endregion
    }

    /// <summary>
    /// Store options pair.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public class StoreOptionsPair
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="value"></param>
        [JsonConstructor()]       
        public StoreOptionsPair(StoreOptionMetadata metadata, StoreOptionReadValue value)
        {
            Metadata = metadata;
            Value = value;
        }

        /// <summary>
        /// Option metadata.
        /// </summary>
        [MessagePack.Key(0)]
        public StoreOptionMetadata Metadata { get; }

        /// <summary>
        /// Option value.
        /// </summary>
        [MessagePack.Key(1)]
        public StoreOptionReadValue Value { get; }
    }
}
