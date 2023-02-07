using System;

namespace Gizmo.Client
{
    public sealed class LanguageChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
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
        #endregion

        #region PROPERTIES

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

        #endregion
    }
}
