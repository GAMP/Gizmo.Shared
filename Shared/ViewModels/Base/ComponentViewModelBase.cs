using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Shared.ViewModels
{
    /// <summary>
    /// Base class for component view models.
    /// </summary>
    /// <remarks>
    /// The purpose of class is to have base functionality for components that are bound to a view model.
    /// </remarks>
    public abstract class ComponentViewModelBase : ViewModelBase, IComponentViewModel
    {
        #region FIELDS

        bool isInitializing;
        CancellationTokenSource currentCts;

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets if currently model is initializing.
        /// </summary>
        public bool IsInitializing
        {
            get { return isInitializing; }
            protected set { SetProperty(ref isInitializing, value); }
        }
        #endregion

        #region VIRTUAL METHODS
        
        /// <summary>
        /// Called upon view initialization.
        /// </summary>
        /// <returns>Associated task.</returns>
        /// <remarks>
        /// Use this override if you want to initialize view model upon component initialization.
        /// By default completed task is returned.
        /// </remarks>
        protected virtual Task OnInitializeAync(CancellationToken ct=default)
        {
            return Task.CompletedTask;
        }

        #endregion

        #region METHODS

        public async ValueTask InitializeAync(CancellationToken ct)
        {
            try
            {
                //cancel any current operation
                currentCts?.Cancel();

                //create new token source
                currentCts = CancellationTokenSource.CreateLinkedTokenSource(ct);

                IsInitializing = true;

                try
                {
                    await OnInitializeAync(currentCts.Token);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                IsInitializing = false;
            }
        }

        #endregion
    }
}
