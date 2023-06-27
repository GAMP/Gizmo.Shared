using System.ComponentModel;

namespace Gizmo.Client.UI
{
    [MessagePack.MessagePackObject()]
    public sealed class PasswordValidationOptions
    {
        [MessagePack.Key(0)]
        [DefaultValue(1)]
        public int MinimumLength
        {
            get; set;
        }

        [MessagePack.Key(1)]
        [DefaultValue(24)]
        public int MaximumLength
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
