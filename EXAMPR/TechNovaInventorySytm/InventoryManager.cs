using System;
using System.Collections.Generic;

namespace TechNovaInventorySystem;

public class InventoryManager
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine("Product added successfully!\n");
    }

    public void DisplayAllProducts()
    {
        Console.WriteLine("\n===== INVENTORY LIST =====\n");;
        foreach(var product in products)
        {
            product.DisplayDetails();
            Console.WriteLine("=====================");
        }
    }
}