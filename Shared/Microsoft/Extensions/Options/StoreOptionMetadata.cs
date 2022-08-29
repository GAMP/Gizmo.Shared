#nullable enable

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Metadata describing a single option entry.
    /// </summary>
    public sealed class StoreOptionMetadata
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets option key.
        /// </summary>
        public string Key { get; init; } = string.Empty;

        /// <summary>
        /// Gets option name.
        /// </summary>
        public string Name { get;init; } = string.Empty;

        /// <summary>
        /// Gets optional default value.
        /// </summary>
        public string? DefaultValue { get;init;}

        /// <summary>
        /// Gets option value type full name.
        /// </summary>
        public string ValueTypeName { get; init; } =string.Empty;

        /// <summary>
        /// Gets value property name.
        /// </summary>
        public string ValuePropertyName { get; init; } = string.Empty;

        /// <summary>
        /// Gets option description.
        /// </summary>
        public string? Description
        {
            get;
            init;
        } 

        #endregion
    }
}
