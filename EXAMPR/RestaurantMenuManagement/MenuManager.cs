using System;
using System.Runtime.CompilerServices;

namespace RestaurantMenuMgmt;

public class MenuManager
{
    private List<MenuItem> items = new List<MenuItem>();

    // Adds item with validation for price > 0
    public void AddMenuItem(string name, string category, double price, bool isVeg)
    {
        items.Add(new MenuItem
        {
            ItemName = name,
            Category = category,
            Price = price,
            IsVegetarian = isVeg
        });
    }

    // Groups items by category
    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        var grouped = items.GroupBy(i => i.Category)
                      .ToDictionary(g => g.Key, g => g.ToList());

        return new Dictionary<string, List<MenuItem>>(grouped);
    }

    // Returns all vegetarian items
    public List<MenuItem> GetVegetarianItems()
    {
        return items.Where(item => item.IsVegetarian).ToList();
    }

    // Returns average price of items in category
    public double CalculateAveragePriceByCategory(string Category)
    {
        return items.Where(e => e.Category.Equals(Category, StringComparison.OrdinalIgnoreCase))
                    .Average(e => e.Price);
    }
}