using System;
namespace TechNovaInventorySystem;

public class Program
{
    public static void Main()
    {
        InventoryManager manager = new InventoryManager();

        Electronics laptop = new Electronics(
            101,
            "Dell Laptop",
            75000,
            "Dell",
            "Inspiron 15",
            24,
            65,
            new DateTime(2025, 5, 10),
            16,
            512
        );

        Grocery rice = new Grocery(
            201,
            "Basmati Rice",
            1200,
            new DateTime(2026, 3, 1),
            5,
            true,
            18
        );

        Clothing shirt = new Clothing(
            301,
            "Formal Shirt",
            1500,
            "L",
            "Cotton",
            "Men",
            "White"
        );

        manager.AddProduct(laptop);
        manager.AddProduct(rice);
        manager.AddProduct(shirt);

        manager.DisplayAllProducts();
    }
}