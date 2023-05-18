#nullable enable

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Popular items options.
    /// </summary>
    public sealed class PopularItemsOptions
    {
        public int MaxPopularProducts { get; set; }
        public int MaxPopularApplications { get; set; }

        public int MaxQuickLaunchExecutables { get; set; }

        public int HomePageMaxItemsPerRow { get; set; }
        public int AppsPageMaxItemsPerRow { get; set; }
        public int ProductsPageMaxItemsPerRow { get; set; }
    }
}
