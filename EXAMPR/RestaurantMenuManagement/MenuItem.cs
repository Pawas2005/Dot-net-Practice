using System;
namespace RestaurantMenuMgmt;

public class MenuItem
{
    public string ItemName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public bool IsVegetarian { get; set; }

    public override string ToString()
    {
        return $"ItemName: {ItemName}, Category(Appetizer/Main Course/Dessert): {Category}, Price: {Price}, IsVegetarian: {IsVegetarian}";
    }
}