using System;

namespace ECommerceProdCatalog;

public class Program
{
    public static void Main()
    {
        InventoryManager manager = new InventoryManager();

        // Add Products
        manager.AddProduct("Laptop", "Electronics", 75000, 10);
        manager.AddProduct("Smartphone", "Electronics", 30000, 20);
        manager.AddProduct("T-Shirt", "Clothing", 800, 50);
        manager.AddProduct("Jeans", "Clothing", 2000, 30);
        manager.AddProduct("C# Programming", "Books", 1200, 15);

        // Group By Category
        Console.WriteLine("Products Grouped By Category:\n");
        var category = manager.GroupProductsByCategory();

        foreach(var prod in category)
        {
            Console.WriteLine($"Category: {prod.Key}");
            foreach(var item in prod.Value)
            {
                Console.WriteLine($" {item}");
            }
            Console.WriteLine();
        }

        // Update Stock
        Console.WriteLine("Enter Product Code to Purchase:");
        string code = Console.ReadLine();

        Console.WriteLine("Enter Quantity:");
        int qty = int.Parse(Console.ReadLine());

        bool updated = manager.UpdateStock(code, qty);
        Console.WriteLine(updated
                ? "Stock updated successfully."
                : "Insufficient stock / Invalid code.");

        // Price Filter
        Console.WriteLine("Enter Max Price: ");
        double maxPrice = double.Parse(Console.ReadLine());

        var prodPrice = manager.GetProductsBelowPrice(maxPrice);
        Console.WriteLine("\nProducts below specified price:\n");
        foreach(var p in prodPrice)
        {
            Console.WriteLine(p);
        }

        // Stock Summary
        Console.WriteLine("\nCategory Stock Summary:\n");
        
        var catStock = manager.GetCategoryStockSummary();
        foreach (var item in catStock)
        {
            Console.WriteLine($"{item.Key} → {item.Value} items");
        }
    }
}