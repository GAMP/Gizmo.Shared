using System.ComponentModel.DataAnnotations;

namespace Gizmo.Shared
{
    public enum CommunicationChannelTypes
    {
        [CommunicationChannelGuid(CommunicationChannels.Email)]
        [Name("Email", "COMMUNICATION_CHANNEL_TYPES_EMAIL")]
        Email,

        [CommunicationChannelGuid(CommunicationChannels.Sms)]
        [Name("SMS", "COMMUNICATION_CHANNEL_TYPES_SMS")]
        Sms,

        [CommunicationChannelGuid(CommunicationChannels.WhatsApp)]
        [Name("WhatsApp", "COMMUNICATION_CHANNEL_TYPES_WHATS_APP")]
        WhatsApp,

        [CommunicationChannelGuid(CommunicationChannels.Viber)]
        [Name("Viber", "COMMUNICATION_CHANNEL_TYPES_VIBER")]
        Viber,

        [CommunicationChannelGuid(CommunicationChannels.Telegram)]
        [Name("Telegram", "COMMUNICATION_CHANNEL_TYPES_TELEGRAM")]
        Telegram,

        [CommunicationChannelGuid(CommunicationChannels.FacebookMessenger)]
        [Name("Facebook messenger", "COMMUNICATION_CHANNEL_TYPES_FACEBOOK_MESSENGER")]
        FacebookMessenger,

        [CommunicationChannelGuid(CommunicationChannels.InstagramDirect)]
        [Name("Instagram", "COMMUNICATION_CHANNEL_TYPES_INSTAGRAM")]
        InstagramDirect,

        [CommunicationChannelGuid(CommunicationChannels.TwitterDm)]
        [Name("Twitter", "COMMUNICATION_CHANNEL_TYPES_TWITTER_DM")]
        TwitterDm,

        [CommunicationChannelGuid(CommunicationChannels.WeChat)]
        [Name("WeChat", "COMMUNICATION_CHANNEL_TYPES_WE_CHAT")]
        WeChat
    }
}
