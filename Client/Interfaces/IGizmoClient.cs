using Gizmo.Shared.Client.UI.ViewModels;
using System.Collections.Generic;

namespace Gizmo.Client
{
    /// <summary>
    /// Gizmo client interface.
    /// </summary>
    public interface IGizmoClient
    {
        public IEnumerable<ProductGroupViewModel> GetProductGroups();

        public IEnumerable<ProductViewModel> GetProducts();

        public IEnumerable<ApplicationViewModel> GetApplications();

        public IEnumerable<ExecutableViewModel> GetExecutables();
    }
}
