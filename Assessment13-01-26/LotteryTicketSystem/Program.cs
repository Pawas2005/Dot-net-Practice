using System;

namespace LotteryTicketSystem
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Lottery lottery = new Lottery();

                Console.Write("Enter the no. of lottery tickets : ");
                int quantity = int.Parse(Console.ReadLine());

                lottery.StartLottery(quantity);
                IList<Guid> winners = lottery.LotteryWinners();

                Console.WriteLine("=====Lottery Winners=========");
                for(int i = 0; i < winners.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + winners[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}