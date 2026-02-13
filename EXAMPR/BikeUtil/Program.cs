using System;
using System.Collections.Generic;
namespace BikeUtil;

class Program
{
    public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

    public static void Main()
    {
        BikeUtility u = new BikeUtility();
        int choice;

        do
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter the model");
                string model = Console.ReadLine();

                Console.WriteLine("Enter the brand");
                string brand = Console.ReadLine();

                Console.WriteLine("Enter the price per day");
                int price = int.Parse(Console.ReadLine());

                u.AddBikeDetails(model, brand, price);
                Console.WriteLine("Bike details added successfully\n");
            }
            else if (choice == 2)
            {
                var data = u.GroupBikesByBrand();

                foreach (var item in data)
                {
                    Console.WriteLine(item.Key);
                    foreach (Bike b in item.Value)
                        Console.WriteLine(b.Model);
                    Console.WriteLine();
                }
            }

        } while (choice != 3);
    }
}