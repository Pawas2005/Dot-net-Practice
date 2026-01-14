using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountsApp
{
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; set; }

        //constructor of child class(SavingsAccount) : base class(BankAccount) 
        public SavingsAccount(string owner, decimal interestRate) : base(owner + " ("+interestRate+"%)")  
        {
            InterestRate = interestRate;
        }

        public override string Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return "You can not deposit $" + amount;
            }
            if (amount > 20000)
            {
                return "AML Deposit Limit Reached.";
            }

            decimal interestAmount = (InterestRate / 100) * amount;
            Balance += amount + interestAmount;
            return "Deposited completed successfully.";
        }
    }
}
