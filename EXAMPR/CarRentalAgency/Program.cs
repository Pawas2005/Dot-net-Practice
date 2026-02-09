using System;
namespace CarRentalAgency;

public class Program
{
    public static void Main()
    {
        RentalManager rentalManager = new RentalManager();

        while (true)
        {
            Console.WriteLine("==== Car Rental Menu ====");
            Console.WriteLine("1. Add Car");
            Console.WriteLine("2. Rent Car");
            Console.WriteLine("3. View Cars");
            Console.WriteLine("4. Group Cars By Type");
            Console.WriteLine("5. Active Rentals");
            Console.WriteLine("6. Total Revenue");
            Console.WriteLine("7. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("License Plate: ");
                    string license = Console.ReadLine();

                    Console.Write("Make: ");
                    string make = Console.ReadLine();

                    Console.Write("Model: ");
                    string model = Console.ReadLine();

                    Console.Write("Car Type: ");
                    string type = Console.ReadLine();

                    Console.Write("Daily Rate: ");
                    double rate = double.Parse(Console.ReadLine());

                    rentalManager.AddCar(license, make, model, type, rate);
                    break;

                case 2:
                    Console.Write("License Plate: ");
                    string l = Console.ReadLine();

                    Console.Write("Customer Name: ");
                    string cust = Console.ReadLine();

                    Console.Write("Start Date (yyyy-MM-dd): ");
                    DateTime start = DateTime.Parse(Console.ReadLine());

                    Console.Write("Days: ");
                    int days = int.Parse(Console.ReadLine());

                    rentalManager.RentCar(l, cust, start, days);
                    break;

                case 3:
                    rentalManager.DisplayCars();
                    break;

                case 4:
                    var grouped = rentalManager.GroupCarsByType();

                    foreach(var g in grouped)
                    {
                        Console.WriteLine($"Type: {g.Key}");
                        foreach(var car in g.Value)
                        {
                            Console.WriteLine($"{car.LicensePlate} {car.Make}");
                        }
                    }
                    Console.WriteLine();
                    break;

                case 5:
                    var active = rentalManager.GetActiveRentals();

                    foreach (var r in active)
                    {
                        Console.WriteLine(
                            $"ID:{r.RentalId} | {r.LicensePlate} | {r.CustomerName} | Till:{r.EndDate:d}");
                    }
                    Console.WriteLine();
                    break;

                case 6:
                    double revenue = rentalManager.CalculateTotalRentalRevenue();

                    Console.WriteLine($"Total Revenue: {revenue}\n");
                    break;

                case 7:
                    return;
            }
        }
    }
}