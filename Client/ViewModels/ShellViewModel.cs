using Gizmo.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmo.Client.ViewModels
{
    /// <summary>
    /// Shell view model.
    /// </summary>
    public class ShellViewModel : ViewModelBase
    {
        public bool IsActiveAppsExpanded
        {
            get;protected set;
        }
    }
}
