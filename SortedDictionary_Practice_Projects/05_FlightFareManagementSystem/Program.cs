using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketUtility ticketUtility = new TicketUtility();

            while (true)
            {
                Console.WriteLine("1. Display Tickets");
                Console.WriteLine("2. Update fare");
                Console.WriteLine("3. Add Ticket");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        ticketUtility.DisplayTickets();
                        break;

                    case 2:
                        string id = Console.ReadLine();
                        int amount = int.Parse(Console.ReadLine());

                        ticketUtility.UpdateFare(id, amount);
                        break;

                    case 3:
                        string[] inp = Console.ReadLine().Split(' ');

                        Ticket ticket = new Ticket()
                        {
                            TicketId = inp[0],
                            PassengerName = inp[1],
                            Fare = int.Parse(inp[2])
                        };

                        ticketUtility.AddTicket(ticket);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice. Please select between 1-4");
                        break;
                }
            }
        }
    }
}
