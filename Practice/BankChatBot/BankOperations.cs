using System;
using System.Globalization;

namespace BankChatBot
{
    public class BankOperations : IBankAccountOperation
    {
        private decimal _balance = 0;

        public void Deposit(decimal d)
        {
            _balance += d;
        }

        public void Withdraw(decimal d)
        {
            if(_balance >= d)
            {
                _balance -= d;
            }
        }

        public decimal ProcessOperation(string message)
        {
            message = message.ToLower();

            decimal amount = ExtractAmount(message);

            if(message.Contains("see") || message.Contains("show"))
            {
                return _balance;
            }

            if(message.Contains("deposit") || message.Contains("put") || message.Contains("invest") || message.Contains("transfer"))
            {
                Deposit(amount);
            }
            else if(message.Contains("withdraw") || message.Contains("pull"))
            {
                Withdraw(amount);
            }

            return _balance;
        }

        private decimal ExtractAmount(string message)
        {
            string[] parts = message.Split(' ');
            foreach(string p in parts)
            {
                if(decimal.TryParse(p, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num))
                {
                    return num;
                }
            }
            return 0;
        }
    }
}