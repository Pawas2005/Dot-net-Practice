using System;

namespace ECommerceProdCatalog;

public class Product
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public override string ToString()
    {
        return $"Product Code: {ProductCode}, Product Name: {ProductName}, Category: {Category}, Price: {Price}, Stock Quantity: {StockQuantity}";
    }
}