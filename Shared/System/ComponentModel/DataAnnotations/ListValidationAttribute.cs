#nullable enable

using System.Linq;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Validation attribute ensuring that only items contained are valid.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class ListValidationAttribute : ValidationAttribute
    {
        public ListValidationAttribute(string[] allowedValues, bool allowNullValues = false)
        {
            AllowedValues = allowedValues;
            AllowNullValues = allowNullValues;
        }

        public string[] AllowedValues { get; }

        public bool AllowNullValues { get; } = false;

        public override bool IsValid(object value)
        {
            if(!AllowNullValues && value == null)
                return false;

            if(value == null) return true;

            return AllowedValues.Any(allowedValue => string.Compare(allowedValue, value.ToString(), StringComparison.OrdinalIgnoreCase) == 0);
        }
    }
}
