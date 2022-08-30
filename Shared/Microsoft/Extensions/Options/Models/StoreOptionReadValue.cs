#nullable enable

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Represent option value read from the store.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class StoreOptionReadValue
    {
        #region PROPERTIES

        /// <summary>
        /// Indicates that option key existed in the store.
        /// </summary>
        [MessagePack.Key(0)]
        public bool Existed
        {
            get; init;
        }

        /// <summary>
        /// Gets current option value in store.
        /// </summary>
        [MessagePack.Key(1)]
        public string? Value
        {
            get; init;
        }

        #endregion
    }
}
