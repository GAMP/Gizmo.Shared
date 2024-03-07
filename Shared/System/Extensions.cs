using System.Linq;

namespace System
{
    public static class Extensions
    {
        /// <summary> 
        /// Gets an attribute on an enum field value 
        /// </summary> 
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam> 
        /// <param name="value">The enum value</param> 
        /// <returns>The attribute of type T that exists on the enum value</returns> 
        public static T GetAttributeOfType<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            if (memInfo.Count() == 0)
                return default;

            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }
            else
            {
                return default;
            }
        }
    }
}
