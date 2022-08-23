namespace Gizmo.Shared.Client.UI.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int ProductGroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int? Points { get; set; }

        public int? PointsPrice { get; set; }
    }
}
