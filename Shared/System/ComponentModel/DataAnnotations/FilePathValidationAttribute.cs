namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Validation attribute ensuring that only valid file path characters contained in specified string value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class FilePathValidationAttribute : ValidationAttribute
    {
        #region OVERRIDES

        public override bool IsValid(object value)
        {
            string path = Convert.ToString(value);

            if (!string.IsNullOrEmpty(path) && path.IndexOfAny(IO.Path.GetInvalidPathChars()) >= 0)
                return false;

            return true;
        }

        #endregion
    }
}