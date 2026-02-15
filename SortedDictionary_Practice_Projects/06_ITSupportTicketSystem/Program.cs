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
                Console.WriteLine("===============IT Support Ticket Priority System===================");
                Console.WriteLine("1. Display Tickets by Priority");
                Console.WriteLine("2. Escalate Ticket");
                Console.WriteLine("3. Add Ticket");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        service.DisplayTickets();
                        break;

                    case 2:
                        string id = Console.ReadLine();

                        service.EscalateTicket(id);
                        break;

                    case 3:
                        // TODO: Add entity
                        String[] inp = Console.ReadLine().Split(' ');
                        SupportTicket supportTicket = new SupportTicket()
                        {
                            TicketId = inp[0],
                            IssueDescription = inp[1],
                            SeverityLevel = int.Parse(inp[2])
                        };

                        service.AddTicket(supportTicket);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice. Please Select between 1-4");
                        break;
                }
            }
        }
    }
}
