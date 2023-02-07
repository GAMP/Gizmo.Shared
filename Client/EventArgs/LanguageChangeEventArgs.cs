using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client language change event args.
    /// </summary>
    public sealed class LanguageChangeEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="settingsLanguage">Settings language.</param>
        /// <param name="preferedUILanguage">Prefered UI language.</param>
        public LanguageChangeEventArgs(string settingsLanguage, string preferedUILanguage)
        {
            SettingsLanguage = settingsLanguage;
            PreferedUILanguage = preferedUILanguage;
        }

        /// <summary>
        /// Current settings language.
        /// </summary>
        public string SettingsLanguage
        {
            get;
            init;
        }

        /// <summary>
        /// Current user prefered language.
        /// </summary>
        public string PreferedUILanguage
        {
            get;
            init;
        }
    }
}
