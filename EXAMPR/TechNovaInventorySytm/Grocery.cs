using System;
namespace TechNovaInventorySystem;

public class Grocery : Product
{
    public DateTime ExpiryDate { get; set; }
    public double Weight { get; set; }
    public bool IsOrganic { get; set; }
    public double StorageTemperature { get; set; }

    public Grocery(int id, string name, double price, DateTime expiry, double weight, bool organic, double temp) : base(id, name, price)
    {
        ExpiryDate = expiry;
        Weight = weight;
        IsOrganic = organic;
        StorageTemperature = temp;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Expiry Date: {ExpiryDate.ToShortDateString()}");
        Console.WriteLine($"Weight: {Weight} kg");
        Console.WriteLine($"Organic: {IsOrganic}");
        Console.WriteLine($"Storage Temp: {StorageTemperature}°C");
    }
}