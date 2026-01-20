using System;

namespace BankTransactionProgram
{
    public class Program
    {
        public static int finalBalance(int initialBalance, int[] transactions)
        {
            foreach(int t in transactions)
            {
                if(t >= 0)
                { 
                    initialBalance += t;  //deposit
                }
                else
                {
                    //withdraw only if enough balance (withdraw means -ve value, so adding means subtracting)
                    if(initialBalance + t >= 0)
                    {
                        initialBalance += t;  // (500 + (-300) = 200)
                    }
                }
            }
            return initialBalance;
        }

        public static void Main()
        {
            Console.Write("Enter the initial Balance : ");
            int initialBalance  = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            int[] transactions = new int[n];
            for(int i = 0; i < n; i++)
            {
                transactions[i] = int.Parse(Console.ReadLine());
            }

            int res = finalBalance(initialBalance, transactions);
            Console.WriteLine(res);
        }
    }
}