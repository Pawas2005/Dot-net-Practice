using System;
namespace FindItems;

public class Program
{
    public static SortedDictionary<String, long> itemDetails = new SortedDictionary<string, long>();

    public static SortedDictionary<String, long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string, long> result = new SortedDictionary<string, long>();

        foreach(var item in itemDetails)
        {
            if(item.Value == soldCount)
            {
                result.Add(item.Key, item.Value);
            }
        }
        return result;
    }

    public static List<String> FindMinAndMaxSoldItems()
    {
        List<String> list = new List<string>();

        if(itemDetails.Count == 0)
            return list;

        long min = itemDetails.Values.Min();
        long max = itemDetails.Values.Max();

        string minItem = "";
        string maxItem = "";

        foreach(var item in itemDetails)
        {
            if(item.Value == min)
                minItem = item.Key;

            if(item.Value == max)
                maxItem = item.Key;
        }
        list.Add(minItem);
        list.Add(maxItem);

        return list;
    }

    public static Dictionary<string, long> SortByCount()
    {
        var result = itemDetails.OrderBy(i => i.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

        return new Dictionary<string, long>(result);
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            string itemName = Console.ReadLine();
            long soldCount = long.Parse(Console.ReadLine());

            itemDetails.Add(itemName, soldCount);
        }

        //1.
        long searchCnt = long.Parse(Console.ReadLine());

        var FindItem = FindItemDetails(searchCnt);
        
        if (FindItem.Count == 0)
        {
            Console.WriteLine("Invalid sold Count");
        }
        else
        {
            foreach (var item in FindItem)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        //2.
        var minMaxList = FindMinAndMaxSoldItems();
        if(minMaxList.Count > 0)
        {
            Console.WriteLine("Minimum Sold Item: " + minMaxList[0]);
            Console.WriteLine("Maximum Sold Item: " + minMaxList[1]);
        }

        //3.
        var Sorted = SortByCount();
        Console.WriteLine("Items sorted by sold count");
        foreach(var item in Sorted)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
    }
}