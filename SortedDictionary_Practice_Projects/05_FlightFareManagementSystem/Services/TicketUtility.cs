using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class TicketUtility
    {
        private SortedDictionary<int, List<Ticket>> tickets = new SortedDictionary<int, List<Ticket>>();

        public void AddTicket(Ticket ticket)
        {
            if(ticket.Fare < 0)
            {
                throw new InvalidFareException("Invalid fare");
            }

            if(tickets.Values.Any(List => List.Any(t => t.TicketId == ticket.TicketId)))
            {
                throw new DuplicateTicketException("Duplicate Ticket Found.");
            }

            if (!tickets.ContainsKey(ticket.Fare))
            {
                tickets[ticket.Fare] = new List<Ticket>();
            }

            tickets[ticket.Fare].Add(ticket);
            Console.WriteLine("Ticket added Successfully.");
        }

        public void DisplayTickets()
        {
            if(tickets.Count() == 0)
            {
                throw new TicketNotFoundException("Ticket Not Found.");
            }

            foreach(var tick in tickets.Keys)
            {
                foreach(var t in tickets[tick])
                {
                    Console.WriteLine($"Details: {t.TicketId} {t.PassengerName} {t.Fare}");
                }
            }
        }

        public void UpdateFare(string id, int amount)
        {
            if(amount <= 0)
            {
                throw new InvalidFareException("Invalid Fare");
            }

            foreach(var fareKey in tickets.Values)
            {
                var  fare = fareKey.FirstOrDefault(t => t.TicketId == id);
                
                if(fare != null)
                {
                    fare.Fare = amount;
                    Console.WriteLine("Ticket Price Updated Successfully.");
                    return;
                }
            }
            throw new TicketNotFoundException("Ticket Not Found.");
        }
    }
}