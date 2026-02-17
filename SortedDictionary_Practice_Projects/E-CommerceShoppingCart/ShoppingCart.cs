using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceShoppingCart;

// Generic shopping cart
public class ShoppingCart<T> where T : Product
{
    private Dictionary<T, int> _cartItems = new Dictionary<T, int>();
    
    // Add product to cart
    public void AddToCart(T product, int quantity)
    {
        // TODO: Add or update quantity in dictionary
        _cartItems.Add(product, quantity);
    }
    
    // Calculate total with discount delegate
    public double CalculateTotal(Func<T, double, double> discountCalculator = null)
    {
        double total = 0;
        foreach (var item in _cartItems)
        {
            double price = item.Key.Price * item.Value;
            if (discountCalculator != null)
                price = discountCalculator(item.Key, price);
            total += price;
        }
        return total;
    }
    
    // Get top N expensive items using LINQ
    public List<T> GetTopExpensiveItems(int n)
    {
        // TODO: Use LINQ OrderByDescending and Take
        return _cartItems.OrderByDescending(p => p.Key.Price)
                            .Take(n).Select(p => p.Key).ToList();
    }
}
