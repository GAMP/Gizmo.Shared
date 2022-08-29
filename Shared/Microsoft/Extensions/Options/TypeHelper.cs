using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Type helper.
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// Gets type short name.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns>Type short name.</returns>
        /// <remarks>
        /// This will create an short name for the type excluding assembly version etc.
        /// </remarks>
        public static string GetShortTypeName(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return $"{type.FullName}, {type.Assembly.GetName().Name}";
        }
    }
}
