namespace System.ComponentModel
{
    /// <summary>
    /// This attribute should be used on properties that not to be considered as modified during property change.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PropertyChangeIgnoreAttribute : Attribute
    {
    }
}
