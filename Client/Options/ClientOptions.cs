using System.Text.Json.Serialization;
using Gizmo.Client.UI;
using Gizmo.UI;
using MessagePack;

namespace Gizmo.Client
{
    [MessagePackObject(false)]
    public sealed class ClientOptions
    {
        [Key(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("Interface")]
        public ClientUIOptions UserInterface { get; init; } = new ClientUIOptions();


        [Key(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("CurrencyOptions")]
        public CurrencyOptions Currency { get; init; } = new CurrencyOptions();


        [Key(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("ClientReservationOptions")]
        public ClientReservationOptions Reservations { get; init; } = new ClientReservationOptions();


        [Key(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("FeedsOptions")]
        public FeedsOptions Feeds { get; init; } = new FeedsOptions();


        [Key(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("HostQRCodeOptions")]
        public HostQRCodeOptions HostQRCode { get; init; } = new HostQRCodeOptions();


        [Key(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("LoginRotatorOptions")]
        public LoginRotatorOptions LoginRotator { get; init; } = new LoginRotatorOptions();


        [Key(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("PopularItemsOptions")]
        public PopularItemsOptions PopularItems { get; init; } = new PopularItemsOptions();


        [Key(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("UserLoginOptions")]
        public UserLoginOptions UserLogin { get; init; } = new UserLoginOptions();


        [Key(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("UserOnlineDepositOptions")]
        public UserOnlineDepositOptions UserOnlineDeposit { get; init; } = new UserOnlineDepositOptions();

    }
}
