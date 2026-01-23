using System;

namespace BankChatBot
{
    public class Program
    {
        public static void Main()
        {
            IBankAccountOperation bank = new BankOperations();

            Console.Write("Enter the number of requests : ");
            int n = int.Parse(Console.ReadLine());

            List<decimal> results = new List<decimal>();

            for(int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                decimal result = bank.ProcessOperation(message);
                results.Add(result);
            }

            foreach(var r in results)
            {
                Console.WriteLine(r);
            }
        }
    }
}