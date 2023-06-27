using System.Text.Json.Serialization;

namespace Gizmo.Client.UI
{
    [MessagePack.MessagePackObject()]
    public sealed class ValidationOptions
    {
        [MessagePack.Key(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("Password")]
        public PasswordValidationOptions Password
        {
            get; set;
        }
    }
}
