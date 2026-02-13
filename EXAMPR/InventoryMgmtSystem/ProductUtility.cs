using System;
namespace InventoryMgmtSystem;

public class ProductUtility
{
    private List<Product> ProductList = new List<Product>();

    public double CalculateTotalValue(int Quantity, double Price)
    {
        return Quantity * Price;
    }

    public void AddProduct(Product product)
    {
        product.TotalValue = CalculateTotalValue(product.Quantity, product.PricePerUnit);
        product.LastUpdated = DateTime.Now;
        ProductList.Add(product);
        Console.WriteLine("Product Added Successfully.");
        Console.WriteLine($"TOtal Stock Value: {product.TotalValue}");
    }

    public void DisplayProducts()
    {
        if(ProductList.Count == 0)
        {
            Console.WriteLine("No Products Available");
            return;
        }

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
            result.TotalValue = CalculateTotalValue(qty, result.PricePerUnit);
            result.LastUpdated = DateTime.Now;

            Console.WriteLine("Updated Successfully");
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }
    }

    public void DeleteProduct(string id)
    {
        var product = ProductList.FirstOrDefault(p => p.ProductId == id);

        if(product != null)
        {
            ProductList.Remove(product);
            Console.WriteLine("Product deleted successfully");
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }
    }

    public void SearchProduct(string id)
    {
        var product = ProductList.FirstOrDefault(p => p.ProductId == id);

        if (product != null)
        {
            Console.WriteLine($"Found: {product.ProductId} {product.ProductName} {product.TotalValue}");
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }
    }

    public void SortByStockValue()
    {
        var sorted = ProductList.OrderBy(p => p.ProductId);

        foreach(var p in sorted)
        {
            Console.WriteLine($"{p.ProductId} {p.ProductName} {p.TotalValue}");
        }
    }
}