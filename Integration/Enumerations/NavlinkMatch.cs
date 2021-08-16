namespace Gizmo.Client.UI
{
    /// <summary>
    /// Navlink match proxy enum.
    /// </summary>
    /// <remarks>
    /// We are using proxy enum in order to avoid dependency on Microsoft.AspNetCore.Components.Routing library.
    /// </remarks>
    public enum NavlinkMatch
    {
        /// <summary>
        ///  Specifies that the Microsoft.AspNetCore.Components.Routing.NavLink should be active when it matches any prefix of the current URL.
        /// </summary>
        Prefix = 0,
        /// <summary>
        /// Specifies that the Microsoft.AspNetCore.Components.Routing.NavLink should be active when it matches the entire current URL.
        /// </summary>
        All = 1
    }
}
