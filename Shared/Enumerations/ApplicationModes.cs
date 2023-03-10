using System;

namespace Gizmo
{
    /// <summary>
    /// Game application modes.
    /// </summary>
    [Flags()]
    public enum ApplicationModes
    {
        /// <summary>
        /// None.
        /// </summary>
        DefaultMode = 0,
        /// <summary>
        /// Single player.
        /// </summary>
        [Localized("EXECUTABLE_MODE_SINGLE_PLAYER")]
        SinglePlayer = 1,
        /// <summary>
        /// Online multiplayer.
        /// </summary>
        [Localized("EXECUTABLE_MODE_ONLINE")]
        Online = 2,
        /// <summary>
        /// Lan Multiplayer.
        /// </summary>
        [Localized("EXECUTABLE_MODE_MULTIPLAYER")]
        Multiplayer = 4,
        /// <summary>
        /// Settings.
        /// </summary>
        [Localized("EXECUTABLE_MODE_SETTINGS")]
        Settings = 8,
        /// <summary>
        /// Utility.
        /// </summary>
        [Localized("EXECUTABLE_MODE_UTILITY")]
        Utility = 16,
        /// <summary>
        /// Game.
        /// </summary>
        [Localized("EXECUTABLE_MODE_GAME")]
        Game = 32,
        /// <summary>
        /// Application.
        /// </summary>
        [Localized("EXECUTABLE_MODE_APPLICATION")]
        Application = 64,
        /// <summary>
        /// Free to play.
        /// </summary>
        [Localized("EXECUTABLE_MODE_FREE_TO_PLAY")]
        FreeToPlay = 128,
        /// <summary>
        /// Requires subscription.
        /// </summary>
        [Localized("EXECUTABLE_MODE_REQUIRES_SUBSCRIPTION")]
        RequiresSubscription = 256,
        /// <summary>
        /// Free trial.
        /// </summary>
        [Localized("EXECUTABLE_MODE_FREE_TRIAL")]
        FreeTrial = 512,
        /// <summary>
        /// Split screen.
        /// </summary>
        [Localized("EXECUTABLE_MODE_SPLIT_SCREEN_MULTIPLAYER")]
        SplitScreenMultiPlayer = 1024,
        /// <summary>
        /// Lan co-op.
        /// </summary>
        [Localized("EXECUTABLE_MODE_CO_OP")]
        CoOpLan = 2048,
        /// <summary>
        /// Online co-op.
        /// </summary>
        [Localized("EXECUTABLE_MODE_CO_OP_ONLINE")]
        CoOpOnline = 4096,
        /// <summary>
        /// One time purchase.
        /// </summary>
        [Localized("EXECUTABLE_MODE_ONE_TIME_PURCHASE")]
        OneTimePurchase = 8192,
    }
}
