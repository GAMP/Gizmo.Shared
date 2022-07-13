using System;

namespace Gizmo.UI
{
    /// <summary>
    /// This attribute is used to identify default route for modules that expose multiple routes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DefaultRouteAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="template">The route template.</param>
        public DefaultRouteAttribute(string template)
        {
            if (string.IsNullOrWhiteSpace(template))
                throw new ArgumentNullException(nameof(template));

            Template = template;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the route template.
        /// </summary>
        public string Template
        {
            get; init;
        }

        /// <summary>
        /// Gets default route matching option.
        /// </summary>
        public NavlinkMatch DefaultRouteMatch
        {
            get; init;
        }

        #endregion
    }
}
