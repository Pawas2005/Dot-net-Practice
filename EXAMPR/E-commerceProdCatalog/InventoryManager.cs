using System;

namespace ECommerceProdCatalog;

public class InventoryManager
{
    private List<Product> products = new List<Product>();
    private int counter = 1;

    public void AddProduct(string name, string category, double price, int stock)
    {
        // Auto-generate ProductCode (P001, P002...)
        string generateID = $"P{counter++:D3}";

        products.Add(new Product
        {
            ProductCode = generateID,
            ProductName = name,
            Category = category,
            Price = price,
            StockQuantity = stock
        });
    }

    // Groups products by category
    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        var grouped = products.GroupBy(i => i.Category)
                      .ToDictionary(g => g.Key, g => g.ToList());

        return new SortedDictionary<string, List<Product>>(grouped);
    }

    // Updates stock, returns false if insufficient stock
    public bool UpdateStock(string productCode, int quantity)
    {
        var product = products.FirstOrDefault(p => p.ProductCode.Equals(productCode, StringComparison.OrdinalIgnoreCase));

        if(product == null) return false;
        if(product.StockQuantity < quantity) return false;

        // Reducing stock after sale
        product.StockQuantity -= quantity;
        
        return true;
    }

    // Returns products below specified price
    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return products.Where(p => p.Price <= maxPrice).ToList();
    }

    // Returns total stock quantity per category
    public Dictionary<string, int> GetCategoryStockSummary()
    {
        return products
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, 
                g => g.Sum(p => p.StockQuantity));
    }
}