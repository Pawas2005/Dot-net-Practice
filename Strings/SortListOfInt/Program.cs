using System;
using System.Linq;
namespace SortListOfIntegers;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the integers separated by space: ");
        List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        var sortedInt = numbers.OrderBy(x => x);
        
        Console.WriteLine("Sorted List Of Integers are : ");
        foreach(var item in sortedInt)
        {
            Console.Write(item + " ");
        }
    }
}