#nullable enable
using System.Collections.Generic;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Represents options to be written to the store.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class StoreOptionsWritePack
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="optionsType">Options type.</param>
        /// <param name="values">Options values.</param>
        public StoreOptionsWritePack(string optionsType, Dictionary<string, string?> values)
        {
            OptionsType = optionsType;
            Values = values;
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
        /// Gets option values.
        /// </summary>
        [MessagePack.Key(1)]
        public Dictionary<string, string?> Values
        {
            get;
        }

        #endregion
    }
}
