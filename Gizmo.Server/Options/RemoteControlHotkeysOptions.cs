using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("RemoteControl")]
    [StoreOptionsGroup("REMOTE_CONTROL")]
    [MessagePack.MessagePackObject]
    public sealed class RemoteControlHotkeysOptions : IStoreOptions
    {
        [Name("Viewer hotkey definitions")]
        [ExtendedDescription("JSON object of hotkey-to-label pairs.")]
        [StoreOptionKey("HOTKEYS")]
        [MessagePack.Key(0)]
        public string? Hotkeys { get; init; }
    }
}
