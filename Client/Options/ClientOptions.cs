using System.Text.Json.Serialization;
using Gizmo.Client.UI;
using Gizmo.UI;
using MessagePack;

namespace Gizmo.Client
{
    /// <summary>
    /// Client options pack.
    /// </summary>
    [MessagePackObject()]
    public sealed class ClientOptions
    {
        [Key(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("ClientInterface")]
        public ClientInterfaceOptions ClientInterface { get; init; } = new ClientInterfaceOptions();

        [Key(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("Currency")]
        public CurrencyOptions Currency { get; init; } = new CurrencyOptions();

        [Key(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("ClientReservation")]
        public ClientReservationOptions Reservations { get; init; } = new ClientReservationOptions();

        [Key(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("Feeds")]
        public FeedsOptions Feeds { get; init; } = new FeedsOptions();

        [Key(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("HostQRCode")]
        public HostQRCodeOptions HostQRCode { get; init; } = new HostQRCodeOptions();

        [Key(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("LoginRotator")]
        public LoginRotatorOptions LoginRotator { get; init; } = new LoginRotatorOptions();

        [Key(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("PopularItems")]
        public PopularItemsOptions PopularItems { get; init; } = new PopularItemsOptions();

        [Key(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("UserLogin")]
        public UserLoginOptions UserLogin { get; init; } = new UserLoginOptions();

        [Key(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("UserOnlineDeposit")]
        public UserOnlineDepositOptions UserOnlineDeposit { get; init; } = new UserOnlineDepositOptions();

    }
}
