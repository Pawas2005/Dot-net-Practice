using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountUtility accountUtility = new AccountUtility();

            // Sample initial accounts
            accountUtility.AddAccount(new Account { AccountNumber = "A101", HolderName = "Amit", Balance = 5000 });
            accountUtility.AddAccount(new Account { AccountNumber = "A102", HolderName = "Rahul", Balance = 3000 });
            accountUtility.AddAccount(new Account { AccountNumber = "A103", HolderName = "Neha", Balance = 8000 });

            while (true)
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        accountUtility.DisplayAccounts();
                        break;

                    case 2:
                        // TODO: Deposit
                        string accN = Console.ReadLine();
                        decimal amount = decimal.Parse(Console.ReadLine());

                        accountUtility.Deposit(accN, amount);
                        break;

                    case 3:
                        // TODO: Withdraw
                        string accNo = Console.ReadLine();
                        decimal amounts = decimal.Parse(Console.ReadLine());

                        accountUtility.WithDraw(accNo, amounts);
                        break;
                        
                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice, Please choose between 1-4");
                        break;
                }
            }
        }
    }
}
