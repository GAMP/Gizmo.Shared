using System.Collections.Generic;

namespace Gizmo.Client.UI
{
    public sealed class UserAgreementDialogParameters
    {
        public string Name { get; init; }
        public string Agreement { get; init; }
        public bool IsRejectable { get; init; }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>() {
                { "Name", Name },
                { "Agreement", Agreement },
                { "IsRejectable", IsRejectable }
            };
        }
    }
}
