using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, List<Order>> data = new SortedDictionary<int, List<Order>>(
                                                            Comparer<int>.Create((a, b) => b.CompareTo(a)));

        public void AddOrder(Order order)
        {
            if(order.OrderAmount <= 0)
            {
                throw new InvalidOrderAmountException("invalid order amount");
            }

            if (!data.ContainsKey(order.OrderAmount))
            {
                data[order.OrderAmount] = new List<Order>();
            }

            data[order.OrderAmount].Add(order);
            Console.WriteLine("Order Added Successfully");
        }

        public void UpdateOrder(string id, int amount)
        {
            if(amount <= 0)
            {
                throw new InvalidOrderAmountException("Invalid Order Amount");
            }

            foreach(var amtKey in data.Values)
            {
                var amt = amtKey.FirstOrDefault(a => a.OrderId == id);

                if(amt != null)
                {
                    amt.OrderAmount = amount;
                    Console.WriteLine("Amount Updated Sucessfully");
                    return;
                }
            }
            throw new OrderNotFoundException("Order Not Found");
        }

        public void DisplayOrders()
        {
            if(data.Count() == 0)
            {
                Console.WriteLine("No order data found.");
                return;
            }

            foreach(var amtKey in data.Keys)
            {
                foreach(var a in data[amtKey])
                {
                    Console.WriteLine($"Details: {a.OrderId} {a.CustomerName} {a.OrderAmount}");
                }
            }
        }
    }
}
