using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
namespace ProdInvMgmt;

public class Program
{
    public static void Main()
    {
        Inventory inventory = new Inventory();
        int choice = 0;

        while(choice != 8)
        {
            Console.WriteLine("\n===== PRODUCT INVENTORY SYSTEM ======");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Total Inventory Value");
            Console.WriteLine("4. View Products by Category");
            Console.WriteLine("5. Category-wise Product Count");
            Console.WriteLine("6. Search Product by Name");
            Console.WriteLine("7. View All Products Grouped by Category");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    AddProduct(inventory);
                    break;

                case 2:
                    RemoveProduct(inventory);
                    break;

                case 3:
                    Console.WriteLine("Total Inventory Value = " +
                        inventory.CalculateTotalValue());
                    break;

                case 4:
                    ShowByCategory(inventory);
                    break;

                case 5:
                    CategoryCount(inventory);
                    break;

                case 6:
                    SearchProduct(inventory);
                    break;
                
                case 7:
                    ShowAllGrouped(inventory);
                    break;

                case 8:
                    Console.WriteLine("Thank you. Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

     // 1. Add product
    public static void AddProduct(Inventory inventory)
    {
        Product p = new Product();

        Console.Write("Enter name: ");
        p.Name = Console.ReadLine();

        Console.Write("Enter Category: ");
        p.Category = Console.ReadLine();

        Console.Write("Enter the Stock Quantity : ");
        p.Stock = int.Parse(Console.ReadLine());

        Console.Write("Enter the price : ");
        p.Price = int.Parse(Console.ReadLine());

        inventory.AddProduct(p);
        Console.WriteLine("Product Added Successfully.");
    }

    // 2. Remove product
    public static void RemoveProduct(Inventory inventory)
    {
        Console.Write("Enter the product-name to remove : ");
        string name = Console.ReadLine();

        IProduct found = null;

        foreach(var g in inventory.GetAllProductsByCategory()){
            foreach(IProduct p in g.Item2)
            {
                if(p.Name == name)
                {
                    found = p;
                    break;
                }
            }
            if(found != null) break;
        }
        if(found != null)
        {
            inventory.RemoveProduct(found);
            Console.WriteLine("Remove Product Successfully.");
        }
        else
        {
            Console.WriteLine("No Product found.");
        }
    }

    // 4. View products by category
    public static void ShowByCategory(Inventory inventory)
    {
        Console.Write("Enter the Category : ");
        string category = Console.ReadLine();

        var result = inventory.GetProductsByCategory(category);

        if(result.Count == 0)
        {
            Console.WriteLine("No Products found.");
        }
        else
        {
            DisplayProducts(result);
        }
    }

    // 5. Category wise count
    public static void CategoryCount(Inventory inventory)
    {
        var data = inventory.GetProductsByCategoryWithCount();

        Console.WriteLine("\n--- Category Wise Product Count ---");

        foreach(var item in data)
        {
             Console.WriteLine(item.Item1 + " : " + item.Item2);
        }
    }

    // 6. Search by name
    public static void SearchProduct(Inventory inventory)
    {
        Console.Write("Enter name to search : ");
        string name = Console.ReadLine();

        var res = inventory.SearchProductsByName(name);

        if(res.Count == 0)
        {
            Console.Write("No Product found.");
        }
        else
        {
            DisplayProducts(res);
        }
    }

    // 7. All products grouped
    public static void ShowAllGrouped(Inventory inventory)
    {
        var groups = inventory.GetAllProductsByCategory();
        foreach(var g in groups)
        {
            Console.WriteLine("\nCategory: " + g.Item1);
            DisplayProducts(g.Item2);
        }
    }

    //Display Products
    public static void DisplayProducts(List<IProduct> products)
    {
        foreach(IProduct p in products)
        {
            Console.WriteLine("Name: " + p.Name + ", Category: " + p.Category + ", Stock Quantity: " + p.Stock + ", Price: " + p.Price);
        }
    }
}