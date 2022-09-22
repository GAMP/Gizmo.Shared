namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Validating attribute ensuring that the value type is enum and its value is defined.
    /// </summary>
    public sealed class EnumValueValidationAttribute : ValidationAttribute
    {
        #region OVERRDIES
        
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

        #endregion
    }
}