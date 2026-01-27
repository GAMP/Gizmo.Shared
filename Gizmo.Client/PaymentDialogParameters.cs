using System.Collections.Generic;

namespace Gizmo.Client.UI
{
    public sealed class PaymentDialogParameters
    {
        public string Url { get; init; }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>() {
                { "Url", Url }
            };
        }
    }
}
