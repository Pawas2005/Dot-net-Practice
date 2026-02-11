using System;
namespace JewelleryStore;

class JewelleryUtility
{
    private Jewellery jewellery;

    public JewelleryUtility(Jewellery jewellery)
    {
        this.jewellery = jewellery;
    }

    public void GetJewelleryDetails()
    {
        Console.WriteLine($"Details: {jewellery.Id} {jewellery.Type} {jewellery.Price}");
    }

    public void UpdateJewelleryPrice(int newPrice)
    {
        // int newPrice = int.Parse(Console.ReadLine());
        jewellery.Price = newPrice;
        Console.WriteLine($"Updated Price: {jewellery.Price}");
    }
}