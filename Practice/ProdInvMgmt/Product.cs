using System;
namespace ProdInvMgmt;

public class Product : IProduct
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
}