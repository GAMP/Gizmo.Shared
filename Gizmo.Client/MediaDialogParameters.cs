using System.Collections.Generic;

namespace Gizmo.Client.UI
{
    public sealed class MediaDialogParameters
    {
        /// <summary>
        /// Title.
        /// </summary>
        public required string Title { get; init; }

        /// <summary>
        /// Media type url.
        /// </summary>
        public AdvertisementMediaUrlType MediaUrlType { get; init; }
        
        /// <summary>
        /// Media url.
        /// </summary>
        public required string MediaUrl { get; init; }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>() {
                { "Title", Title },
                { "MediaUrlType", MediaUrlType },
                { "MediaUrl", MediaUrl }
            };
        }
    }
}
