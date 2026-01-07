//ExpenseTransaction.cs : Adds a Category property (e.g., Office, Travel, Food).
using System;

namespace PettyCashSystem;

public class ExpenseTransaction : Transaction
{
    public string Category { get; set; }

    public override string GetSummary() //every non-abstract child class must provide its implementation.
    {
        return $"Expense = ${Amount} for {Category} - {Description}";
    }
}