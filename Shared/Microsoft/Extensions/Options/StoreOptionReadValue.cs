#nullable enable

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Represent option value read from the store.
    /// </summary>
    public sealed class StoreOptionReadValue
    {
        #region PROPERTIES
        
        /// <summary>
        /// Indicates that option key existed in the store.
        /// </summary>
        public bool Existed
        {
            get; init;
        }

        /// <summary>
        /// Gets current option value in store.
        /// </summary>
        public string? Value
        {
            get; init;
        } 

        #endregion
    }
}
