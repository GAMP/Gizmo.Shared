using System.ComponentModel;
using System.Text.Json.Serialization;
using Gizmo.Client.UI;
using Gizmo.UI;

namespace Gizmo.Client
{
    /// <summary>
    /// Client options pack.
    /// </summary>
    /// <remarks>
    /// Defines client options structure to be serialized as an options pack.
    /// </remarks>
    [MessagePack.MessagePackObject()]
    public sealed class ClientOptions
    {
        [MessagePack.Key(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("ClientInterface")]
        public ClientInterfaceOptions ClientInterface { get; init; } = new ClientInterfaceOptions();

        [MessagePack.Key(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("Logo")]
        public LogoOptions Logo { get; init; } = new LogoOptions();

        [MessagePack.Key(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("Currency")]
        public CurrencyOptions Currency { get; init; } = new CurrencyOptions();

        [MessagePack.Key(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("ClientReservation")]
        public ClientReservationOptions Reservations { get; init; } = new ClientReservationOptions();

        [MessagePack.Key(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("Feeds")]
        public FeedsOptions Feeds { get; init; } = new FeedsOptions();

        [MessagePack.Key(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("HostQRCode")]
        public HostQRCodeOptions HostQRCode { get; init; } = new HostQRCodeOptions();

        [MessagePack.Key(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("LoginRotator")]
        public LoginRotatorOptions LoginRotator { get; init; } = new LoginRotatorOptions();

        [MessagePack.Key(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("PopularItems")]
        public PopularItemsOptions PopularItems { get; init; } = new PopularItemsOptions();

        [MessagePack.Key(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("UserLogin")]
        public UserLoginOptions UserLogin { get; init; } = new UserLoginOptions();

        [MessagePack.Key(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("UserOnlineDeposit")]
        public UserOnlineDepositOptions UserOnlineDeposit { get; init; } = new UserOnlineDepositOptions();

        [MessagePack.Key(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("Shop")]
        public ClientShopOptions Shop { get; init; } = new ClientShopOptions();

        [MessagePack.Key(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("Validation")]
        public ValidationOptions Validation { get; init; } = new ValidationOptions();

        [MessagePack.Key(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("Integration")]
        public IntegrationOptions Integration { get; init; } = new IntegrationOptions();

        [MessagePack.Key(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("Apps")]
        public ClientAppsOptions Apps { get; init; } = new ClientAppsOptions();

        [MessagePack.Key(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("Home")]
        public ClientHomeOptions Home { get; init; } = new ClientHomeOptions();

        [MessagePack.Key(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("AssistanceRequest")]
        public AssistanceRequestOptions AssistanceRequest { get; init; } = new AssistanceRequestOptions();

        /// <summary>
        /// Resets invalid properties to their default values.
        /// </summary>
        public void ResetInvalidToDefault()
        {
            OptionsHelper.SetInvalidPropertiesToDefault(ClientInterface);
            OptionsHelper.SetInvalidPropertiesToDefault(Logo);  
            OptionsHelper.SetInvalidPropertiesToDefault(Currency);
            OptionsHelper.SetInvalidPropertiesToDefault(Reservations);
            OptionsHelper.SetInvalidPropertiesToDefault(Feeds);
            OptionsHelper.SetInvalidPropertiesToDefault(HostQRCode);
            OptionsHelper.SetInvalidPropertiesToDefault(LoginRotator);
            OptionsHelper.SetInvalidPropertiesToDefault(PopularItems);
            OptionsHelper.SetInvalidPropertiesToDefault(UserLogin);
            OptionsHelper.SetInvalidPropertiesToDefault(UserOnlineDeposit);
            OptionsHelper.SetInvalidPropertiesToDefault(Shop);
            OptionsHelper.SetInvalidPropertiesToDefault(Validation);
            OptionsHelper.SetInvalidPropertiesToDefault(Validation.Password);
            OptionsHelper.SetInvalidPropertiesToDefault(Integration);
            OptionsHelper.SetInvalidPropertiesToDefault(Apps);
            OptionsHelper.SetInvalidPropertiesToDefault(Home);
            OptionsHelper.SetInvalidPropertiesToDefault(AssistanceRequest);
        }
    }
}
