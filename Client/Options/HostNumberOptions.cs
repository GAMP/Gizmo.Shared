using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Gizmo.Client.UI.View.Constants;
using Gizmo.Shared.Client.Enumerations;

namespace Gizmo.Shared.Client.Options
{
    /// <summary>
    /// The base class for host number settings
    /// </summary>
    public class HostNumberOptions
    {
        /// <summary>
        /// Indicates if host number prefix is disabled
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool PrefixDisabled { get; set; }
        
        /// <summary>
        /// Prefix
        /// </summary>
        /// <remarks>
        /// The host prefix displayed before host number
        /// </remarks>
        [MessagePack.Key(1)]
        [Range(1, 10)]
        public string Prefix { get; set; }
        
        /// <summary>
        /// Indicated if host number will be displayed on the wallpaper
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(false)]
        public bool ShowOnWallpaper { get; set; }
        
        /// <summary>
        /// Indicated if host number will be displayed on the rotator
        /// </summary>
        [MessagePack.Key(3)]
        [DefaultValue(false)]
        public bool ShowOnRotator { get; set; }
        
        /// <summary>
        /// Positioning on wallpaper
        /// </summary>
        [MessagePack.Key(4)]
        public HostNumberPositioning PositioningOnWallpaper { get; set; }
        
        /// <summary>
        /// Positioning on rotator
        /// </summary>
        [MessagePack.Key(5)]
        public HostNumberPositioning PositioningOnRotator { get; set; }
        
        /// <summary>
        /// Fixed position
        /// </summary>
        [MessagePack.Key(6)]
        public HostNumberFixedPosition FixedPosition { get; set; }
        
        /// <summary>
        /// Position timeout
        /// </summary>
        /// <remarks>
        /// The time that the host number will be delayed at one position.
        /// Used when the "ShowOn..." property is set to true
        /// </remarks>
        [MessagePack.Key(7)]
        public int TimeoutBetweenPosition { get; set; }
        
        /// <summary>
        /// Animation duration
        /// </summary>
        /// <remarks>
        /// The duration of changing the position of the host number
        /// </remarks>
        [MessagePack.Key(8)]
        public double AnimationDuration { get; set; }
        
    }
}
