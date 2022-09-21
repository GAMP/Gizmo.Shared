using System;
using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// Assembly resource localization service.
    /// </summary>
    /// <remarks>
    /// This service is used to localize resources in internal or external assemblies.
    /// </remarks>
    public interface IAssemblyResourcesLocalizationService
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets localized string value.
        /// </summary>
        /// <param name="type">Object type.</param>
        /// <param name="descriptionAttribute">Description attribute.</param>
        /// <returns>Found localized string value.</returns>
        /// <remarks>
        /// This function will return value set on <see cref="ExtendedDescriptionAttribute.Description"/> by default if localized resource is not found.<br></br>
        /// This function will always return empty string if either resource not found or <see cref="ExtendedDescriptionAttribute.Description"/> not set or <paramref name="descriptionAttribute"/> is equal to null.
        /// </remarks>
        /// <exception cref="ArgumentException">thrown in case assembly name cant be extracted from <paramref name="type"/>specified.</exception>
        string GetLocalizedStringValue(Type type, ExtendedDescriptionAttribute descriptionAttribute);

        /// <summary>
        /// Gets localized string value.
        /// </summary>
        /// <param name="type">Object type.</param>
        /// <param name="nameAttribute">Name attribute.</param>
        /// <returns>Found localized string value.</returns>
        /// <remarks>
        /// This function will return value set on <see cref="NameAttribute.Name"/> by default if localized resource is not found.<br></br>
        /// This function will always return empty string if either resource not found or <see cref="NameAttribute.Name"/> not set or <paramref name="nameAttribute"/> is equal to null.
        /// </remarks>
        /// <exception cref="ArgumentException">thrown in case assembly name cant be extracted from <paramref name="type"/>specified.</exception>
        string GetLocalizedStringValue(Type type, NameAttribute nameAttribute); 

        #endregion
    }
}