using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.UI
{
    [MessagePack.MessagePackObject()]
    public sealed class PasswordValidationOptions
    {
        [MessagePack.Key(0)]
        [DefaultValue(8)]
        [Range(1, int.MaxValue)]
        public int? MinimumLength
        {
            get; set;
        }

        [MessagePack.Key(1)]
        [DefaultValue(24)]
        [Range(1, int.MaxValue)]
        public int? MaximumLength
        {
            get; set;
        }

        [MessagePack.Key(2)]
        [DefaultValue(false)]
        public bool LowerCaseCharactersRequired
        {
            get; set;
        }

        [MessagePack.Key(3)]
        [DefaultValue(false)]
        public bool UpperCaseCharactersRequired
        {
            get; set;
        }

        [MessagePack.Key(4)]
        [DefaultValue(false)]
        public bool NumbersRequired
        {
            get; set;
        }
    }
}
