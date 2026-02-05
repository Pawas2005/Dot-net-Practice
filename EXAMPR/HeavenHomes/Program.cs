using System;

namespace HeavenHomes;

public class Program
{
    public static void Main()
    {
        Apartment apartment = new Apartment();

        Console.WriteLine("Enter number of details to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the details(Apartment number:Rent)");
        for(int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(':');
            double rent = double.Parse(input[1]);
            apartment.addApartmentDetails(input[0], rent);
        }

        Console.WriteLine("Enter the range to filter the details");
        double minRange = double.Parse(Console.ReadLine());
        double maxRange = double.Parse(Console.ReadLine());

        double result = apartment.findTotalRentOfApartmentsInTheGivenRange(minRange, maxRange);

        if(result == 0)
        {
            Console.WriteLine("No apartments found in this range");
        }
        else
        {
            Console.WriteLine($"Total Rent in the range {minRange:F1} to {maxRange:F1} USD:{result:F1}");
        }
    }
}