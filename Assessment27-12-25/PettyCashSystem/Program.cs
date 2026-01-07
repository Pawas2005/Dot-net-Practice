using System;
using System.Collections.Generic;

namespace PettyCashSystem;

public class Program
{
    public static void Main()
    {
        Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();
        Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

        //adding income
        incomeLedger.AddEntry(new IncomeTransaction
        {
           Id = 1,
           Date = DateTime.Now,
           Amount = 500,
           Description = "Petty Cash System 1st Month Income",
           Source = "Main Cash"
        });

        //adding expenses
        expenseLedger.AddEntry(new ExpenseTransaction
        {
           Id = 1,
           Date = DateTime.Now,
           Amount = 20,
           Description = "Boughts Stationery items",
           Category = "Stationery"
        });

        expenseLedger.AddEntry(new ExpenseTransaction
        {
           Id = 2,
           Date = DateTime.Now,
           Amount = 15,
           Description = "Boughts Snacks for Team",
           Category = "Food"
        });

        decimal TotalIncome = incomeLedger.CalculateTotal();
        Console.WriteLine("Total Income : $" + TotalIncome);

        decimal TotalExpense = expenseLedger.CalculateTotal();
        Console.WriteLine("Total Expense : $" + TotalExpense);

        decimal NetBalance = TotalIncome - TotalExpense;
        Console.WriteLine("Total Net balance : $" + NetBalance);

        //make a list that store both income & expense transaction
        List<Transaction> allTransactions = new List<Transaction>();

        allTransactions.AddRange(incomeLedger.GetAll());
        allTransactions.AddRange(expenseLedger.GetAll());

        foreach(Transaction t in allTransactions)
        {
            Console.WriteLine(t.GetSummary());
        }
    }
}