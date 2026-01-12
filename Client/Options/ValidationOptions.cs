using System.Text.Json.Serialization;

namespace Gizmo.Client.Options
{
    /// <summary>
    /// Validation options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ValidationOptions
    {
        /// <summary>
        /// Password.
        /// </summary>
        [MessagePack.Key(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("Password")]
        public PasswordValidationOptions Password
        {
            get; set;
        } = new PasswordValidationOptions();
    }
}
