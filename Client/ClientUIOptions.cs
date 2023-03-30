﻿#nullable enable

using System;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Client user interface options.
    /// </summary>
    public sealed class ClientUIOptions
    {
        /// <summary>
        /// Gets background.
        /// </summary>
        public string? Background
        {
            get; set;
        }

        /// <summary>
        /// Gets skin.
        /// </summary>
        public string? Skin
        {
            get; set;
        }

        public ClientCurrencyOptions CurrencyOptions { get; set; } = new();
    }
}
