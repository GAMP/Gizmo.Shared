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
        /// Gets allowed value.
        /// </summary>
        [MessagePack.Key(0)]
        public string Value { get; init; }

        /// <summary>
        /// Gets value description.
        /// </summary>
        [MessagePack.Key(1)]
        public string ValueDescription { get; init; } 

        #endregion
    }
}
