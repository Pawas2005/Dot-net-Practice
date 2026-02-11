using System;
namespace JewelleryComplexVer;

class JewelleryUtility
{
    private List<Jewellery> JewelleryList = new List<Jewellery>();

    public void AddJewellery(Jewellery jewellery)
    {
        JewelleryList.Add(jewellery);
        Console.WriteLine("Jewellery added successfully.");
    }

    public void DisPlayAll()
    {
        foreach(var j in JewelleryList)
        {
            Console.WriteLine($"Details: {j.Id} {j.Type} {j.Material} {j.Price}");
        }
    }

    public void UpdatePrice(string id, double newPrice)
    {
        var item =  JewelleryList.FirstOrDefault(j => j.Id == id);

        if(item != null)
        {
            item.Price = newPrice;
            Console.WriteLine($"Updated Price: {item.Price}");
        }
        else
        {
            Console.WriteLine("Jewellery not found");
        }
    }

    public void SearchByTYpe(string type)
    {
        var result = JewelleryList.Where(j => j.Type == type);

        foreach(var j in result)
        {
            Console.WriteLine($"Found: {j.Id} {j.Type} {j.Price}");
        }
    }
}