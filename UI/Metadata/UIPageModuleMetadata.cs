using System;
using System.Collections.Generic;
using System.Linq;

namespace Gizmo.UI
{
    /// <summary>
    /// Page module metadata.
    /// </summary>
    public sealed class UIPageModuleMetadata : UIModuleMetadata
    {
        #region FIELDS
        private readonly string _defaultRoute; 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets default route.
        /// </summary>
        public string DefaultRoute 
        {
            get 
            {
                //if no default route is set return the first route from the route list
                if (string.IsNullOrWhiteSpace(_defaultRoute))
                    return Routes.FirstOrDefault();

                //return default route
                return _defaultRoute; 
            } 
            init { _defaultRoute = value; } 
        }

        /// <summary>
        /// Gets default route match.
        /// </summary>
        /// <remarks>
        /// This option specified how to match the route with navlink component.
        /// </remarks>
        public NavlinkMatch DefaultRouteMatch
        {
            get; init;
        } = NavlinkMatch.All;

        /// <summary>
        /// Gets all associated routes.
        /// </summary>
        public IEnumerable<string> Routes { get; init; } = Array.Empty<string>();

        #endregion
    }
}
