using System.ComponentModel;
using System.Text.Json.Serialization;
using Gizmo.Client.UI;
using Gizmo.Shared.Client.Options;
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
        /// <summary>
        /// Interface.
        /// </summary>
        [MessagePack.Key(0)]
        [JsonPropertyOrder(0)]
        [JsonPropertyName("ClientInterface")]
        public ClientInterfaceOptions ClientInterface { get; init; } = new ClientInterfaceOptions();

        /// <summary>
        /// Logo.
        /// </summary>
        [MessagePack.Key(1)]
        [JsonPropertyOrder(1)]
        [JsonPropertyName("Logo")]
        public LogoOptions Logo { get; init; } = new LogoOptions();

        /// <summary>
        /// Currency.
        /// </summary>
        [MessagePack.Key(2)]
        [JsonPropertyOrder(2)]
        [JsonPropertyName("Currency")]
        public CurrencyOptions Currency { get; init; } = new CurrencyOptions();

        /// <summary>
        /// Reservations.
        /// </summary>
        [MessagePack.Key(3)]
        [JsonPropertyOrder(3)]
        [JsonPropertyName("ClientReservation")]
        public ClientReservationOptions Reservations { get; init; } = new ClientReservationOptions();

        /// <summary>
        /// Feeds.
        /// </summary>
        [MessagePack.Key(4)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("Feeds")]
        public FeedsOptions Feeds { get; init; } = new FeedsOptions();

        /// <summary>
        /// Host QR code.
        /// </summary>
        [MessagePack.Key(5)]
        [JsonPropertyOrder(5)]
        [JsonPropertyName("HostQRCode")]
        public HostQRCodeOptions HostQRCode { get; init; } = new HostQRCodeOptions();

        /// <summary>
        /// Login page media rotator.
        /// </summary>
        [MessagePack.Key(6)]
        [JsonPropertyOrder(6)]
        [JsonPropertyName("LoginRotator")]
        public LoginRotatorOptions LoginRotator { get; init; } = new LoginRotatorOptions();

        /// <summary>
        /// Popular items.
        /// </summary>
        [MessagePack.Key(7)]
        [JsonPropertyOrder(7)]
        [JsonPropertyName("PopularItems")]
        public PopularItemsOptions PopularItems { get; init; } = new PopularItemsOptions();

        /// <summary>
        /// User login.
        /// </summary>
        [MessagePack.Key(8)]
        [JsonPropertyOrder(8)]
        [JsonPropertyName("UserLogin")]
        public UserLoginOptions UserLogin { get; init; } = new UserLoginOptions();

        /// <summary>
        /// User deposit.
        /// </summary>
        [MessagePack.Key(9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("UserOnlineDeposit")]
        public UserOnlineDepositOptions UserOnlineDeposit { get; init; } = new UserOnlineDepositOptions();

        /// <summary>
        /// Client shop.
        /// </summary>
        [MessagePack.Key(10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("Shop")]
        public ClientShopOptions Shop { get; init; } = new ClientShopOptions();

        /// <summary>
        /// Validation.
        /// </summary>
        [MessagePack.Key(11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("Validation")]
        public ValidationOptions Validation { get; init; } = new ValidationOptions();

        /// <summary>
        /// Integration.
        /// </summary>
        [MessagePack.Key(12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("Integration")]
        public IntegrationOptions Integration { get; init; } = new IntegrationOptions();

        /// <summary>
        /// Applications.
        /// </summary>
        [MessagePack.Key(13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("Apps")]
        public ClientAppsOptions Apps { get; init; } = new ClientAppsOptions();

        /// <summary>
        /// Home.
        /// </summary>
        [MessagePack.Key(14)]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("Home")]
        public ClientHomeOptions Home { get; init; } = new ClientHomeOptions();

        /// <summary>
        /// Assistance request.
        /// </summary>
        [MessagePack.Key(15)]
        [JsonPropertyOrder(15)]
        [JsonPropertyName("AssistanceRequest")]
        public AssistanceRequestOptions AssistanceRequest { get; init; } = new AssistanceRequestOptions();
        
        [MessagePack.Key(16)]
        [JsonPropertyOrder(16)]
        [JsonPropertyName("HostNumber")]
        public HostNumberOptions HostNumber { get; init; } = new HostNumberOptions();

        /// <summary>
        /// Regional options.
        /// </summary>
        [MessagePack.Key(17)]
        [JsonPropertyOrder(17)]
        [JsonPropertyName("Regional")]
        public ClientRegionalOptions Regional { get; init; } = new ClientRegionalOptions();

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
            OptionsHelper.SetInvalidPropertiesToDefault(Regional);
            OptionsHelper.SetInvalidPropertiesToDefault(HostNumber);
        }
    }
}
