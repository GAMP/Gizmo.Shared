using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Map options.
    /// </summary>
    [OptionsConfigurationSection("MAPS")]
    [StoreOptionsGroup("MAPS")]
    [MessagePack.MessagePackObject()]
    public sealed class MapOptions : IStoreOptions
    {
        /// <summary>
        /// Gets active map provider.
        /// </summary>
        [Name("Map provider")]
        [ExtendedDescription("Specifies active map provider")]
        [StoreOptionKey("PROVIDER")]
        [DefaultValue(Gizmo.Web.Api.Models.MapProvider.None)]
        [MessagePack.Key(0)]
        public Gizmo.Web.Api.Models.MapProvider Provider
        {
            get; init;
        }

        /// <summary>
        /// Gets Google maps API key.
        /// </summary>
        [Name("Google API key")]
        [ExtendedDescription("Specifies Google maps API key")]
        [StoreOptionKey("GOOGLE_API_KEY")]
        [DefaultValue(null)]
        [MessagePack.Key(1)]
        public string? GoogleApiKey
        {
            get; init;
        }

        /// <summary>
        /// Gets Yandex maps API key.
        /// </summary>
        [Name("Yandex API key")]
        [ExtendedDescription("Specifies Yandex maps API key")]
        [StoreOptionKey("YANDEX_API_KEY")]
        [DefaultValue(null)]
        [MessagePack.Key(2)]
        public string? YandexApiKey
        {
            get; init;
        }
    }
}
