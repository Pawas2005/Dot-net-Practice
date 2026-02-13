using System;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace TechNovaInventorySystem;

public class Electronics : Product
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int WarrantyPeriod { get; set; }
    public int PowerUsage { get; set; }
    public DateTime ManufacturingDate { get; set; }
    public int RAM { get; set; }
    public int Storage { get; set; }

    public Electronics(int id, string name, double price, string brand, string model, int warranty, int power, DateTime mfgDate, int ram, int storage) : base(id, name , price)
    {
        Brand = brand;
        Model = model;
        WarrantyPeriod = warranty;
        PowerUsage = power;
        ManufacturingDate = mfgDate;
        RAM = ram;
        Storage = storage;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Brand: {Brand}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Warranty: {WarrantyPeriod} months");
        Console.WriteLine($"Power Usage: {PowerUsage}W");
        Console.WriteLine($"Mfg Date: {ManufacturingDate.ToShortDateString()}");
        Console.WriteLine($"RAM: {RAM} GB");
        Console.WriteLine($"Storage: {Storage} GB");
    }
}