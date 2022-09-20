namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Custom description attribute.
    /// </summary>
    public sealed class ExtendedDescriptionAttribute : Attribute
    {
        #region PROPERTIES
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Description.</param>
        public ExtendedDescriptionAttribute(string description)
        {
            Description = description;
        }
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets description.
        /// </summary>
        public string Description { get; init; } 

        #endregion
    }
}
