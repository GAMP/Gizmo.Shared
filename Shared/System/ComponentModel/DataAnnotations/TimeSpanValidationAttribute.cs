namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// TimeSpan validation attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TimeSpanValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public TimeSpanValidationAttribute()
        {
            AllowNull = false;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="allowNull">Allow null values.</param>
        /// <param name="min">Minimum in minutes.</param>
        /// <param name="max">Maximum in minutes.</param>
        public TimeSpanValidationAttribute(bool allowNull, int min, int max)
        {
            if (min > max)
                throw new ArgumentException("Min value cannot be greater than max value.");

            AllowNull = allowNull;
            Min = TimeSpan.FromMinutes(min);
            Max = TimeSpan.FromMinutes(max);
        }

        /// <summary>
        /// Allow null values.
        /// </summary>
        private bool AllowNull { get; set; }

        /// <summary>
        /// Maximum value.
        /// </summary>
        private TimeSpan? Min { get; set; }

        /// <summary>
        /// Minimum value.
        /// </summary>
        private TimeSpan? Max { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //allow null values
            if (value == null && AllowNull)
                return ValidationResult.Success;

            if (value is not string stringValue)
                return new ValidationResult("Value is not a string.");

            try
            {
                //split with expected separator
                string[] input = stringValue.Split(':');

                //at least one split is required
                if (input.Length < 1)
                    return new ValidationResult("Invalid format.");

                int hours = int.Parse(input[0]);
                int minutes = input.Length >= 2 ? int.Parse(input[1]) : 0;
                int seconds = input.Length >= 3 ? int.Parse(input[2]) : 0;
                int mills = input.Length >= 4 ? int.Parse(input[3]) : 0;

                TimeSpan timeSpan = new TimeSpan(0, hours, minutes, seconds, mills);

                if (Max.HasValue && timeSpan > Max.Value)
                    return new ValidationResult($"Value is greater than {(int)Max.Value.TotalHours:D2}:{Max.Value.Minutes:D2}:{Max.Value.Seconds:D2}.");

                if (Min.HasValue && timeSpan < Min.Value)
                    return new ValidationResult($"Value is less than {(int)Min.Value.TotalHours:D2}:{Min.Value.Minutes:D2}:{Min.Value.Seconds:D2}.");

                return ValidationResult.Success;
            }
            catch
            {
                //parsing exception (probably)

                return new ValidationResult("Invalid format.");
            }
        }
    }
}
