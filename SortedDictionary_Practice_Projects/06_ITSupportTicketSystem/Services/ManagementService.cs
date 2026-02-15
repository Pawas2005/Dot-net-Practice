using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, Queue<SupportTicket>> tickets = new SortedDictionary<int, Queue<SupportTicket>>();

        public void AddTicket(SupportTicket ticket)
        {
            if(ticket.SeverityLevel < 1 || ticket.SeverityLevel > 5)
            {
                throw new InvalidSecurityException("Severity must between 1-5");
            }

            if (!tickets.ContainsKey(ticket.SeverityLevel))
            {
                tickets[ticket.SeverityLevel] = new Queue<SupportTicket>();
            }

            tickets[ticket.SeverityLevel].Enqueue(ticket);
            Console.WriteLine("Ticket Added Successfully.");
        }

        public void DisplayTickets()
        {
            if(tickets.Count == 0)
            {
                Console.WriteLine("Ticket Not Found");
                return;
            }

            foreach(var severity in tickets.Keys)
            {
                foreach(var s in tickets[severity])
                {
                    Console.WriteLine($"Details: {s.TicketId} {s.IssueDescription} Severity:{s.SeverityLevel}");
                }
            }
        }

        // Escalate Ticket (Increase Priority → Reduce severity number)
        public void EscalateTicket(string id)
        {
            foreach(var sevKey in tickets.Keys.ToList())
            {
                var queue = tickets[sevKey];
                var list = queue.ToList();
                var ticket = list.FirstOrDefault(t => t.TicketId == id);

                if(ticket != null)
                {
                    if(ticket.SeverityLevel == 1)
                    {
                        throw new InvalidSecurityException("Already Highest Priority");
                    }

                    // Remove from old severity
                    list.Remove(ticket);

                    if (list.Count == 0)
                        tickets.Remove(sevKey);
                    else
                        tickets[sevKey] = new Queue<SupportTicket>(list);

                    // Escalate severity
                    ticket.SeverityLevel--;

                    if (!tickets.ContainsKey(ticket.SeverityLevel))
                    {
                        tickets[ticket.SeverityLevel] = new Queue<SupportTicket>();
                    }
                    tickets[ticket.SeverityLevel].Enqueue(ticket);

                    Console.WriteLine("Ticket Escalated Successfully.");
                    return;
                }
            }
            throw new TicketNotFoundException("Ticket Not Found");
        }
    }
}
