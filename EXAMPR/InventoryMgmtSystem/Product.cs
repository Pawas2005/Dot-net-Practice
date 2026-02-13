using System;
namespace InventoryMgmtSystem;

public class Product
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double PricePerUnit { get; set; }
    public double TotalValue { get; set; }
    public DateTime LastUpdated { get; set; } 
}