using System;

class Program
{
    public static double? AverageNonNull(double?[] values)
    {
        double sum = 0;
        int count = 0;

        foreach (double? v in values)
        {
            if (v.HasValue)
            {
                sum += v.Value;
                count++;
            }
        }

        if (count == 0)
            return null;

        double avg = sum / count;
        return Math.Round(avg, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        double?[] values = new double?[n];

        Console.WriteLine("Enter values : ");

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "null")
                values[i] = null;
            else
                values[i] = double.Parse(input);
        }

        double? result = AverageNonNull(values);

        if (result.HasValue)
            Console.WriteLine("Average = " + result.Value.ToString("F2"));
        else
            Console.WriteLine("Average = null");
    }
}







//Extension Method
// using System;

// namespace NullValue
// {
//     public static class MyExtension
//     {
//         public static void Print(this string str)
//         {
//             Console.WriteLine(str.ToUpper());
//         }
//     }

//     public class Program
//     {
//         public static void Main()
//         {
//             string str = "Hello, World!";
//             str.Print();

//         }
//     }
// }