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
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Update Order");
                Console.WriteLine("3. Add Order");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        service.DisplayOrders();
                        break;

                    case 2:
                        // TODO: Update entity
                        string id = Console.ReadLine();
                        int amt = int.Parse(Console.ReadLine());

                        service.UpdateOrder(id, amt);
                        break;

                    case 3:
                        // TODO: Add entity
                        String[] inp = Console.ReadLine().Split(' ');
                        Order order = new Order()
                        {
                            OrderId = inp[0],
                            CustomerName = inp[1],
                            OrderAmount = int.Parse(inp[2])
                        };

                        service.AddOrder(order);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice, Please select between 1-4");
                        break;
                }
            }
        }
    }
}
