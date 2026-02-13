using System;
using System.Runtime.InteropServices.Marshalling;
namespace TechNovaInventorySystem;

public abstract class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, double price)
    {
        ProductId = id;
        ProductName = name;
        Price = price;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"ID: {ProductId}");
        Console.WriteLine($"Name: {ProductName}");
        Console.WriteLine($"Price: {Price}");
    }
}