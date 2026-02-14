using System;
namespace FirstRepeatedChar;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter the String: ");
        string str = Console.ReadLine();

        var result = str.GroupBy(c => c)
                        .Where(c => c.Count() > 1)
                        .Select(c => c.Key)
                        .FirstOrDefault();

        if(result != '\0')
        {
            Console.WriteLine("First Repeated Character : " + result);
        }
        else
        {
            Console.WriteLine("No First Repeated Character Found.");
        }
    }
}