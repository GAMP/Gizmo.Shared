namespace Gizmo.Web.Api.Models
{
    /// <summary>
    /// Map provider.
    /// </summary>
    /// <remarks>
    /// New providers must be added at the end.
    /// </remarks>
    public enum MapProvider
    {
        /// <summary>
        /// No map provider.
        /// </summary>
        None = 0,

        /// <summary>
        /// Google Maps.
        /// </summary>
        Google = 1,

        /// <summary>
        /// Yandex Maps.
        /// </summary>
        Yandex = 2,
    }
}
