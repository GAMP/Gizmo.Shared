namespace Gizmo
{
    /// <summary>
    /// Product sort options.
    /// </summary>
    public enum ProductSortOptionType
    {
        /// <summary>
        /// Default.
        /// </summary>
        [Localized("MANUAL")]
        Default = 0,

        /// <summary>
        /// Name.
        /// </summary>
        [Localized("NAME")]
        Name = 1,

        /// <summary>
        /// Created.
        /// </summary>
        [Localized("CREATION_TIME")]
        Created = 2
    }
}
