#nullable enable
namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Represents option metadata with value.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class StoreOptionMetadataValue
    {
        #region CONSTRUCTOR
        
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="metadata">Metadata.</param>
        /// <param name="value">Read value.</param>
        public StoreOptionMetadataValue(StoreOptionMetadata metadata, StoreOptionReadValue value)
        {
            Metadata = metadata;
            Value = value;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets metadata.
        /// </summary>
        [MessagePack.Key(1)]
        public StoreOptionMetadata Metadata
        {
            get;
        }

        /// <summary>
        /// Gets store read value.
        /// </summary>
        [MessagePack.Key(2)]
        public StoreOptionReadValue Value
        {
            get;
        } 

        #endregion
    }
}
