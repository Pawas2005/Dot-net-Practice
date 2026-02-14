using System;
using System.Linq;
// namespace  NonRepeatedCharacters;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter the String: ");
        string str = Console.ReadLine();

        var result = str.GroupBy(c => c)
                        .Where(g => g.Count() == 1)
                        .Select(g => g.Key)
                        .FirstOrDefault();

        if(result != '\0')
        {
            Console.WriteLine("First non-repeated Character: " + result);
        }
        else
        {
            Console.WriteLine("No non-repeated Character found.");
        }
    }
}