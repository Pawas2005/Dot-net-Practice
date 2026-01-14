using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountsApp
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string owner)
        {
            Owner = owner;
            AccountNumber = Guid.NewGuid();
            Balance = 0;
        }

        public string Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                return "You can not deposit $" + amount;
            }
            if(amount > 20000)
            {
                return "AML Deposit Limit Reached.";
            }

            Balance += amount;
            return "Deposited completed successfully.";
        }

        public string Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return "You can not withdraw $" + amount;
            }
            if (amount > Balance)
            {
                return "You don't have enough money.";
            }

            Balance -= amount;
            return "Withdraw completed successfully.";
        }
    }
}
