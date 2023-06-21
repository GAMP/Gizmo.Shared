using System.Text.Json.Serialization;
using Gizmo.Client.UI;
using Gizmo.UI;

namespace Gizmo.Client
{
    /// <summary>
    /// Client options pack.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ClientOptions
    {
        [MessagePack.Key(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("ClientInterface")]
        public ClientInterfaceOptions ClientInterface { get; init; } = new ClientInterfaceOptions();

        [MessagePack.Key(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("Currency")]
        public CurrencyOptions Currency { get; init; } = new CurrencyOptions();

        [MessagePack.Key(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("ClientReservation")]
        public ClientReservationOptions Reservations { get; init; } = new ClientReservationOptions();

        [MessagePack.Key(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("Feeds")]
        public FeedsOptions Feeds { get; init; } = new FeedsOptions();

        [MessagePack.Key(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("HostQRCode")]
        public HostQRCodeOptions HostQRCode { get; init; } = new HostQRCodeOptions();

        [MessagePack.Key(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("LoginRotator")]
        public LoginRotatorOptions LoginRotator { get; init; } = new LoginRotatorOptions();

        [MessagePack.Key(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("PopularItems")]
        public PopularItemsOptions PopularItems { get; init; } = new PopularItemsOptions();

        [MessagePack.Key(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("UserLogin")]
        public UserLoginOptions UserLogin { get; init; } = new UserLoginOptions();

        [MessagePack.Key(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("UserOnlineDeposit")]
        public UserOnlineDepositOptions UserOnlineDeposit { get; init; } = new UserOnlineDepositOptions();

    }
}
