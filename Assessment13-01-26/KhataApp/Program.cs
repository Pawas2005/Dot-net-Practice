using System;

namespace KhataApp
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, int> record = new Dictionary<string, int>();

            Console.Write("Enter the no. of items: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.Write("\nEnter item name: ");
                string name = Console.ReadLine();

                Console.Write("Enter amount: ");
                int amount = int.Parse(Console.ReadLine());

                if (!record.ContainsKey(name))
                {
                    record.Add(name, amount);
                }
                else
                {
                    Console.WriteLine("Duplicate item not allowed. Try again.");
                    i--;
                }
            }

            Khata khata = new Khata(record);
            Console.WriteLine("\nTotal Amount: " + khata.getTotal());
            Console.WriteLine("Repeated Amount Count: " + khata.getRepeatAmount());

            Console.ReadLine();
        }
    }
}