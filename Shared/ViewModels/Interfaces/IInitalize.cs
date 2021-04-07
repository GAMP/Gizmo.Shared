using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Shared.ViewModels
{
    public interface IInitalize
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Called on object initialization.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        ValueTask InitializeAync(CancellationToken ct = default); 

        #endregion
    }
}
