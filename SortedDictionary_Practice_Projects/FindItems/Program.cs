using System;
using System.Collections.Generic;
namespace FindItems;

public class Program
{
    public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>()
    {
        { "Pen", 120 },
        { "Pencil", 80 },
        { "Notebook", 250 },
        { "Eraser", 60 }
    };

    public SortedDictionary<string, long> FindItemDetails(long soldCount)
    {
        var result = new SortedDictionary<string, long>();

        foreach(var item in itemDetails)
        {
            if(item.Value == soldCount)
            {
                result.Add(item.Key, item.Value);
            }
        }
        return result;
    }

    public List<string> FindMinandMaxSoldItems()
    {
        var result = new List<string>();

        if(itemDetails.Count == 0) return result;

        var min = itemDetails.OrderBy(m => m.Value).First();
        var max = itemDetails.OrderByDescending(m => m.Value).First();

        result.Add(min.Key);
        result.Add(max.Key);

        return result;
    }

    public Dictionary<string, long> SortByCount()
    {
        return itemDetails.OrderBy(x => x.Value).ToDictionary(x => x.Key, X => X.Value);
    }

    public static void Main()
    {
        Program p = new Program();

        Console.WriteLine("Enter the sold cnt to search: ");
        long soldCount = long.Parse(Console.ReadLine());

        var found = p.FindItemDetails(soldCount);

        if(found.Count == 0)
        {
            Console.WriteLine("Invalid sold count.");
        }
        else
        {
            foreach(var kv in found)
            {
                Console.WriteLine($"{kv.Key} : {kv.Value}");
            }
        }

        var minMax = p.FindMinandMaxSoldItems();
        if(minMax.Count > 2)
        {
            Console.WriteLine($"Min Sold Item: {minMax[0]}, Max Sold Item: {minMax[1]}");
        }

        Console.WriteLine("Sorted by sold count: ");
        var sortd = p.SortByCount();
        foreach(var s in sortd)
        {
            Console.WriteLine($"{s.Key} : {s.Value}");
        }
    }
}