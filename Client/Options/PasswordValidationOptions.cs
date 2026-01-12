using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.Options
{
    /// <summary>
    /// Password validation options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class PasswordValidationOptions
    {
        /// <summary>
        /// Minimum length.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(8)]
        [Range(1, int.MaxValue)]
        public int? MinimumLength
        {
            get; set;
        }

        /// <summary>
        /// Maximum length.
        /// </summary>
        [MessagePack.Key(1)]
        [DefaultValue(24)]
        [Range(1, int.MaxValue)]
        public int? MaximumLength
        {
            get; set;
        }

        /// <summary>
        /// Require lower case characters.
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(false)]
        public bool LowerCaseCharactersRequired
        {
            get; set;
        }

        /// <summary>
        /// Require upper case characters.
        /// </summary>
        [MessagePack.Key(3)]
        [DefaultValue(false)]
        public bool UpperCaseCharactersRequired
        {
            get; set;
        }

        /// <summary>
        /// Require numbers.
        /// </summary>
        [MessagePack.Key(4)]
        [DefaultValue(false)]
        public bool NumbersRequired
        {
            get; set;
        }
    }
}
