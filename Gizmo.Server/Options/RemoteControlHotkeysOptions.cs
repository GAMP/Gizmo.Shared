using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("RemoteControl:Hotkeys")]
    [StoreOptionsGroup("REMOTE_CONTROL_HOTKEYS")]
    [MessagePack.MessagePackObject]
    public sealed class RemoteControlHotkeysOptions : IStoreOptions
    {
        [Name("Viewer hotkey definitions")]
        [ExtendedDescription("JSON object of hotkey-to-label pairs.")]
        [StoreOptionKey("DEFINITIONS")]
        [MessagePack.Key(0)]
        public string? Definitions { get; init; }
    }
}
