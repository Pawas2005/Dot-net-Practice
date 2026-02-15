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
                Console.WriteLine($"===============Investment Risk Classification System===============");
                Console.WriteLine("1. Display Investments");
                Console.WriteLine("2. Update Risk");
                Console.WriteLine("3. Add Investment");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        service.DisplayInvestments();
                        break;

                    case 2:
                        // TODO: Update entity
                        string id = Console.ReadLine();
                        int riskR = int.Parse(Console.ReadLine());

                        service.UpdateRisk(id, riskR);
                        break;

                    case 3:
                        // TODO: Add entity
                        String[] inp = Console.ReadLine().Split(' ');

                        Investment investment = new Investment()
                        {
                            InvestmentId = inp[0],
                            AssetName = inp[1],
                            Riskrating = int.Parse(inp[2])
                        };

                        service.AddInvestment(investment);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice, Please Select between 1-4");
                        break;
                }
            }
        }
    }
}
