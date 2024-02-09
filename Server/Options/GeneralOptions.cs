#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Currency options.
    /// </summary>
    [OptionsConfigurationSection("GENERAL")]
    [StoreOptionsGroup("GENERAL")]
    public sealed class GeneralOptions : IStoreOptions
    {
        [Name("Default language", "SERVER_OPTION_DEFAULT_LANGUAGE_NAME")]
        [ExtendedDescription("Specifies default language", "SERVER_OPTION_DEFAULT_LANGUAGE_DESCRIPTION")]
        [StoreOptionKey("DEFAULT_LANGUAGE")]
        [DefaultValue("en-US")]
        public string? DefaultLanguage
        {
            get;init;
        }
    }
}
