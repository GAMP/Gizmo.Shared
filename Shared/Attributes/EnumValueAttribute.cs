using System;
using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// Enum value validation attribute.
    /// </summary>
    public sealed class EnumValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                Type type = value.GetType();

                if (!Enum.IsDefined(type, value))
                {
                    return new ValidationResult($"The value '{value}' is invalid.");
                }
            }

            return ValidationResult.Success;
        }
    }
}