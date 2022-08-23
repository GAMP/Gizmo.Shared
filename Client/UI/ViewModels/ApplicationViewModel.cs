using System;

namespace Gizmo.Shared.Client.UI.ViewModels
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }

        public int ApplicationCategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
