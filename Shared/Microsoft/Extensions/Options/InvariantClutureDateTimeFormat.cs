using System;
using System.Globalization;

namespace Microsoft.Extensions.Options
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class InvariantClutureDateTimeFormat : OptionValueCustomStringFormatAttribute
    {
        public override string Format(object value)
        {
            if (value == null)
                return null;

            var dateTime = (DateTime)value;

            return dateTime.ToString(CultureInfo.InvariantCulture);
        }
    }
}
