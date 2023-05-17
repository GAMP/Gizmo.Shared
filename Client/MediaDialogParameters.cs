using System.Collections.Generic;

namespace Gizmo.Client.UI
{
    public sealed class MediaDialogParameters
    {
        public string Title { get; init; }
        public AdvertisementMediaUrlType MediaUrlType { get; init; }
        public string MediaUrl { get; init; }

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
