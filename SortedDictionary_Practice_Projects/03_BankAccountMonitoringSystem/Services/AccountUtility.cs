using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using Domain;
namespace Services;

public class AccountUtility
{
    private SortedDictionary<decimal, List<Account>> accounts = new SortedDictionary<decimal, List<Account>>();

    public void AddAccount(Account acc)
    {
        if(acc.Balance <= 0)
        {
            throw new Exceptions.NegativeBalanceException("Invalid Amount");
        }

        if (!accounts.ContainsKey(acc.Balance))
        {
            accounts[acc.Balance] = new List<Account>();
        }
        accounts[acc.Balance].Add(acc);
        Console.WriteLine("Account added Successfully.");
    }

    public void DisplayAccounts()
    {
        if(accounts.Count == 0)
        {
            Console.WriteLine("No accounts available.");
            return;
        }

        foreach(var bal in accounts.Keys)
        {
            foreach(var acc in accounts[bal])
            {
                Console.WriteLine($"Details: {acc.AccountNumber} {acc.HolderName} {acc.Balance}");
            }
        }
    }

    public void Deposit(string accNo, decimal amount)
    {
        if(amount <= 0)
        {
            throw new Exceptions.NegativeBalanceException("Invalid Deposit Amount");
        }

        foreach(var balKey in accounts.Keys.ToList())
        {
            var acc = accounts[balKey].FirstOrDefault(a => a.AccountNumber == accNo);

            if(acc != null)
            {
                accounts[balKey].Remove(acc);

                if(accounts[balKey].Count == 0)
                {
                    accounts.Remove(balKey);
                }
                
                acc.Balance += amount;

                if (!accounts.ContainsKey(acc.Balance))
                {
                    accounts[acc.Balance] = new List<Account>();
                }

                accounts[acc.Balance].Add(acc);
                Console.WriteLine("Deposit Successful.");
                return;
            }
        }
        throw new Exceptions.AccountNotFoundException("Account Not Found.");
    }

    public void WithDraw(string accNo, decimal amount)
    {
        if(amount <= 0)
        {
            throw new Exceptions.NegativeBalanceException("Invalid Deposit Amount");
        }

        foreach(var balKey in accounts.Keys.ToList())
        {
            var acc = accounts[balKey].FirstOrDefault(a => a.AccountNumber == accNo);

            if(acc != null)
            {
                if(amount > acc.Balance)
                {
                    throw new Exceptions.InsufficientFundsException("Insufficient Funds");
                }

                accounts[balKey].Remove(acc);

                if(accounts[balKey].Count == 0)
                {
                    accounts.Remove(balKey);
                }

                acc.Balance -= amount;

                if (!accounts.ContainsKey(acc.Balance))
                {
                    accounts[acc.Balance] = new List<Account>();
                }

                accounts[acc.Balance].Add(acc);
                Console.WriteLine("Withdraw Successful.");
                return;
            }
        }
        throw new AccountNotFoundException("Account Not Found");
    }
}