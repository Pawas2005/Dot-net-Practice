using System;

namespace RestaurantMenuMgmt;

public class Program
{
    public static void Main()
    {
        MenuManager manager = new MenuManager();

        // Add Items
        manager.AddMenuItem("Spring Rolls", "Appetizer", 150, true);
        manager.AddMenuItem("Chicken Wings", "Appetizer", 220, false);
        manager.AddMenuItem("Paneer Butter Masala", "Main Course", 280, true);
        manager.AddMenuItem("Chicken Biryani", "Main Course", 320, false);
        manager.AddMenuItem("Ice Cream", "Dessert", 120, true);

        // Group By Category
        Console.WriteLine("Menu Grouped By Category:\n");
        var category = manager.GroupItemsByCategory();

        foreach(var group in category)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach(var item in group.Value)
            {
                Console.WriteLine($" {item}");
            }
            Console.WriteLine();
        }

        // Vegetarian Menu
        Console.WriteLine("Vegetarian Menu:\n");
        var vegItems = manager.GetVegetarianItems();

        foreach(var items in vegItems)
        {
            Console.WriteLine(items);
        }

        //Average Price
        Console.WriteLine("\nEnter Category to Calculate Average Price:");
        string cat = Console.ReadLine();

        double avg = manager.CalculateAveragePriceByCategory(cat);

        Console.WriteLine($"Average Price in {cat} = ₹{avg}");
    }
}