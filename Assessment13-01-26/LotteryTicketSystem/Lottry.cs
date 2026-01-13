using System;
using System.IO.Pipes;

namespace LotteryTicketSystem
{
    public class Lottery
    {
        //guid uses for uniqueness
        private List<Guid> tickets = new List<Guid>();
        private Random random = new Random();

        public event EventHandler<CustomEventArgs> TicketGenerated;

        public Lottery()
        {
            TicketGenerated += GenerateTickets;
        }

        public void GenerateTickets(object sender, CustomEventArgs eventArgs)
        {
            if(eventArgs.Quantity < 10)
            {
                throw new InvalidOperationException("Minimum 10 tickets are required.");
            }

            tickets.Clear();

            while(tickets.Count < eventArgs.Quantity)
            {
                Guid ticket = Guid.NewGuid();

                if (!tickets.Contains(ticket))
                {
                    tickets.Add(ticket);
                }
            }
            Console.WriteLine($"\n{tickets.Count} tickets generated Successfully.");
        }

        public void StartLottery(int quantity)
        {
            TicketGenerated?.Invoke(this, new CustomEventArgs { Quantity = quantity });
        }

        public IList<Guid> LotteryWinners()
        {
            if(tickets.Count == 0)
            {
                throw new InvalidOperationException("No tickets generated yet.");
            }
            List<Guid> winners = new List<Guid>();

            while(winners.Count < 3)
            {
                int index = random.Next(tickets.Count);
                Guid selected = tickets[index];

                if (!winners.Contains(selected))
                {
                    winners.Add(selected);
                }
            }
            return winners;
        }
    }
}