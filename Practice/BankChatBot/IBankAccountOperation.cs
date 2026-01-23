using System;

namespace BankChatBot
{
    public interface IBankAccountOperation
    {
        void Deposit(decimal d);
        void Withdraw(decimal d);
        decimal ProcessOperation(string message);
    }
}