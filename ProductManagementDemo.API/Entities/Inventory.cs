namespace ProductManagementDemo.API.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ReorderPoint { get; set; }
        public string? WarehouseLocation { get; set; }
        public DateTime LastRestockedAt { get; set; }

        public int AvailableQuantity => Quantity;

        public virtual Product Product { get; set; } = null!;
    }
}
