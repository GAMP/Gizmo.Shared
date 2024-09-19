using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace System.ComponentModel
{
    public static class OptionsHelper
    {
        /// <summary>
        /// Sets all properties to default values.
        /// </summary>
        public static void SetDefaults(object instance)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(instance))
                property.ResetValue(instance);
        }

        /// <summary>
        /// Sets default value for specified property.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        public static void SetDefault(object instance, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            var property = TypeDescriptor.GetProperties(instance)[propertyName];
            if (property.CanResetValue(instance))
                property.ResetValue(instance);
        }

        /// <summary>
        /// Gets validation results.
        /// </summary>
        /// <returns>Grouped validation results.</returns>
        public static IEnumerable<IGrouping<string, ValidationResult>> GetValidationResults(object instance)
        {
            //create new validation context
            var validationContext = new ValidationContext(instance, null, null);

            //create store for validation results
            var validationResults = new List<ValidationResult>();

            //validate using data annotation validator
            Validator.TryValidateObject(instance, validationContext, validationResults, true);

            //Group validation results by property names
            var resultsByPropertyNames = from res in validationResults
                                         from mname in res.MemberNames
                                         group res by mname into g
                                         select g;

            return resultsByPropertyNames;
        }

        /// <summary>
        /// Gets names of the properties with invalid values.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetInvalidPropertyNames(object instance)
        {
            return GetValidationResults(instance)
                .Select(x => x.Key);
        }

        /// <summary>
        /// Resets invalid properties to its default values.
        /// <remarks>
        /// The reset will only occur if property have an DefaultValue attribute set.
        /// </remarks>
        /// </summary>
        public static void SetInvalidPropertiesToDefault(object instance)
        {
            GetInvalidPropertyNames(instance)
                .ToList()
                .ForEach(x => SetDefault(instance, x));
        }
    }
}
