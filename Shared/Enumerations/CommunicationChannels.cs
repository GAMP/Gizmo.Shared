using System.ComponentModel.DataAnnotations;

namespace Gizmo.Shared
{
    /// <summary>
    /// Communication channels.
    /// </summary>
    /// <remarks>
    /// A set of predefined identifiers for communication channels.
    /// </remarks>
    public static class CommunicationChannels
    {
        [Name("Email")]
        public static readonly string Email = "d6626ef7-68f0-4ea0-a816-8b74a39ab156";
        
        [Name("SMS")]
        public static readonly string Sms = "4b9e2c1d-3a64-472d-9b9e-5f7e8a1d2c3f";
        
        [Name("WhatsApp")]
        public static readonly string WhatsApp = "3013f9ac-750b-4982-ad3f-c32de1c630cc";

        [Name("Viber")]
        public static readonly string Viber = "c83a28f3-d699-473b-8940-1dd0370cdaeb";

        [Name("Telegram")]
        public static readonly string Telegram = "1e56e848-66d6-45fc-b106-5128059686dd";

        [Name("Facebook messenger")]
        public static readonly string FacebookMessenger = "c2d3e4f5-a6b7-4e20-9c8d-7e6f5a4b3c2d";

        [Name("Instagram")]
        public static readonly string InstagramDirect = "d3e4f5a6-b7c8-4f20-9d8e-6f5a4b3c2d1e";       
       
        [Name("Twitter")]
        public static readonly string TwitterDm = "f5a6b7c8-d9e0-4b20-9f8a-4b3c2d1e0f9a";
        
        [Name("WeChat")]
        public static readonly string WeChat = "a6b7c8d9-e0f1-4c20-9a8b-3c2d1e0f9a8b";        
    }
}
