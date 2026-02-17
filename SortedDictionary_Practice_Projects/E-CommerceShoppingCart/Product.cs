using System;
namespace ECommerceShoppingCart;

// Base product class
public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    // public class Electronics : Product { }

    // public class Clothing : Product { }
}
