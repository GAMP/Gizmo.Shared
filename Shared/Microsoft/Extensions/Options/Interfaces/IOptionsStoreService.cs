#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Options store service implementation interface.
    /// </summary>
    /// <remarks>
    /// Provides functionality of storing/reading options in store (database,api etc).
    /// </remarks>
    public interface IOptionsStoreService
    {
        #region EVENTS

        /// <summary>
        /// Occurs once one of the options values changes.
        /// </summary>
        event EventHandler<EventArgs>? Changed;

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Writes specified options into store.
        /// </summary>
        /// <typeparam name="TOptions">Options type.</typeparam>
        /// <param name="options">Options instance.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task WriteAsync<TOptions>(TOptions options, CancellationToken cancellationToken = default) where TOptions : class, IStoreOptions;

        /// <summary>
        /// Writes specified options into store.
        /// </summary>
        /// <param name="optionsPack">Options pack.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task WriteAsync(StoreOptionsWritePack optionsPack, CancellationToken cancellationToken);

        /// <summary>
        /// Reads specified options from store.
        /// </summary>
        /// <typeparam name="TOptions">Options type.</typeparam>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Options instance.</returns>
        Task<TOptions> ReadAsync<TOptions>(CancellationToken cancellationToken) where TOptions :
            class, IStoreOptions, new();

        /// <summary>
        /// Reads specified options from store.
        /// </summary>
        /// <param name="type">Options type string.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Options read pack instance.</returns>
        Task<StoreOptionsReadPack> ReadAsync(string type, CancellationToken cancellationToken);

        /// <summary>
        /// Reads specified options from store.
        /// </summary>
        /// <param name="type">Options type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Options read pack instance.</returns>
        Task<StoreOptionsReadPack> ReadAsync(Type type, CancellationToken cancellationToken);

        /// <summary>
        /// Reads all app domain wide options from the store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>All read options pack.</returns>
        Task<IEnumerable<StoreOptionsReadPack>> ReadAllAsync(CancellationToken cancellationToken);

        #endregion
    }
}
