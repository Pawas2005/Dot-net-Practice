using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementService service = new ManagementService();

            while (true)
            {
                Console.WriteLine("1. Display Violatons");
                Console.WriteLine("2. Pay Fine");
                Console.WriteLine("3. Add Violation");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        service.DisplayViolations();
                        break;

                    case 2:
                        // TODO: Pay Fine entity
                        string id = Console.ReadLine();
                        int amount = int.Parse(Console.ReadLine());

                        service.PayFine(id, amount);
                        break;

                    case 3:
                        // TODO: Add entity
                        String[] inp = Console.ReadLine().Split(' ');

                        Violation violation = new Violation()
                        {
                            VehicleNumber = inp[0],
                            OwnerName = inp[1],
                            FineAmount = int.Parse(inp[2])
                        };

                        service.AddViolation(violation);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice, Select between 1-4");
                        break;
                }
            }
        }
    }
}
