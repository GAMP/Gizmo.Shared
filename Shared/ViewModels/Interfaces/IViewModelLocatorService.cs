using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gizmo.Shared.ViewModels
{
    public interface IViewModelLocatorService<TKey,TModelType> : IInitalize
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets exposed view models.
        /// </summary>
        public IEnumerable<TModelType> ViewModels
        {
            get;
        }

        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Gets view model by key.
        /// </summary>
        /// <param name="key">View model key.</param>
        /// <returns>View model, null in case view model not found.</returns>
        public Task<TModelType> GetAsync(TKey key); 

        #endregion
    }
}
