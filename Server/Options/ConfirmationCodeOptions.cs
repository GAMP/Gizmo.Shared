using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("CONFIRMATIONCODE")]
    [StoreOptionsGroup("CONFIRMATION_CODE")]
    [MessagePack.MessagePackObject()]
    public sealed class ConfirmationCodeOptions : IStoreOptions
    {
        [Name("Code length")]
        [ExtendedDescription("Specifies code length")]
        [StoreOptionKey("CODE_LENGTH")]
        [MessagePack.Key(0)]
        [Range(4,6)]
        [DefaultValue(6)]
        public int Length { get; init; }

        [Name("Code type")]
        [ExtendedDescription("Specifies code type")]
        [StoreOptionKey("CODE_TYPE")]
        [MessagePack.Key(1)]
        [DefaultValue(KeyGenerationCharacters.UpperCaseCharacters)]
        public KeyGenerationCharacters Type { get; init; }
    }
}
