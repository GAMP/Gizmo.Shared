#nullable enable

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Store option allowed value metadata.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class StoreOptionAllowedValueMetadata
    {
        #region PROPERTIES

        /// <summary>
        /// Gets value name.
        /// </summary>
        [MessagePack.Key(0)]
        public string? Name
        {
            get; init;
        }

        /// <summary>
        /// Gets value description.
        /// </summary>
        [MessagePack.Key(1)]
        public string? Description { get; init; }

        /// <summary>
        /// Gets allowed value.
        /// </summary>
        [MessagePack.Key(2)]
        public string Value { get; init; } = string.Empty;

        #endregion
    }
}
