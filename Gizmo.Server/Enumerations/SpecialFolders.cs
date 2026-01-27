using System;

namespace Gizmo.Server
{
    /// <summary>
    /// Special folders.
    /// </summary>
    [Flags()]
    public enum SpecialFolders
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Desktop flag.
        /// </summary>
        Desktop = 1,

        /// <summary>
        /// Downloads flag.
        /// </summary>
        Downloads = 2,

        /// <summary>
        /// Favorites flag.
        /// </summary>
        Favorites = 4,

        /// <summary>
        /// My Music flag.
        /// </summary>
        Music = 8,

        /// <summary>
        /// My pictures flag.
        /// </summary>
        Pictures = 16,

        /// <summary>
        /// My videos flag.
        /// </summary>
        Videos = 32,

        /// <summary>
        /// Saved games flag.
        /// </summary>
        SavedGames = 64,

        /// <summary>
        /// Personal flag (Equals MyDocuments).
        /// </summary>
        Personal = 128,
    }
}
