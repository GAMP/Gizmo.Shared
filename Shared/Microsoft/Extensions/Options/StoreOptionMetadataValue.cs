#nullable enable

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Represents option metadata with value.
    /// </summary>
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
        public StoreOptionMetadata Metadata
        {
            get;
        }

        /// <summary>
        /// Gets store read value.
        /// </summary>
        public StoreOptionReadValue Value
        {
            get;
        } 

        #endregion
    }
}
