using System;
namespace TechNovaInventorySystem;

public class Clothing : Product
{
    public string Size { get; set; }
    public string FabricType { get; set; }
    public string Gender { get; set; }
    public string Color { get; set; }

    public Clothing(int id, string name, double price, string size, string type, string gender, string color) : base(id, name, price)
    {
        Size = size;
        FabricType = type;
        Gender = gender;
        Color = color;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Size: {Size}");
        Console.WriteLine($"Fabric: {FabricType}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"Color: {Color}");
    }
}