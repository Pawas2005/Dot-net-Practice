using System;
namespace InventoryMgmtSystem;

public class ProductUtility
{
    private List<Product> ProductList = new List<Product>();

    public double CalculateTotalValue(int Quantity, double PricePerUnit)
    {
        double total = Quantity * PricePerUnit;

        return total;
    }

    public void LastUpdatedDate(DateTime LastUpdated)
    {
        DateTime CurrDate = DateTime.Now;
        
        LastUpdated = CurrDate;
    }


    public void AddProduct(Product product)
    {
        ProductList.Add(product);
        Console.WriteLine("Product Added Successfully.");
        Console.WriteLine($"TOtal Stock Value: {CalculateTotalValue}");
    }

    public void DisplayProducts()
    {
        foreach(var p in ProductList)
        {
            Console.WriteLine($"Details: {p.ProductId} {p.ProductName} {p.Quantity} {p.TotalValue} {p.LastUpdated}");
        }
    }   

    public void UpdateQuantity(string id, int qty)
    {
        var result = ProductList.FirstOrDefault(p => p.ProductId == id);

        if(result != null)
        {
            result.Quantity = qty;
            double recalTotal = CalculateTotalValue(qty, result.PricePerUnit);
        }
    }
}