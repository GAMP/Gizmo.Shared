#nullable enable
using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Attribute used to specify Options class type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class StoreOptionsTypeAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="optionsType">Options type.</param>
        public StoreOptionsTypeAttribute(Type optionsType)
        {
            if(!ISTORE_OPTIONS_TYPE.IsAssignableFrom(optionsType))
                throw new ArgumentOutOfRangeException("Options must implement IStoreOptions interface.",nameof(optionsType));

            OptionsType = optionsType;
        }
        #endregion

        #region FIELDS
        private static readonly Type ISTORE_OPTIONS_TYPE = typeof(IStoreOptions);
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets options type.
        /// </summary>
        public Type OptionsType
        {
            get; init;
        } 
        #endregion
    }
}
