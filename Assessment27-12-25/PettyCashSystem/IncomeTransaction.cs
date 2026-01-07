//IncomeTransaction.cs: Adds a Source property (e.g., Main Cash, Bank Transfer).
using System;

namespace PettyCashSystem;

public class IncomeTransaction : Transaction
{
    public string Source { get; set; }

    public override string GetSummary() //non-abstract child class
    {
        return $"Income = ${Amount} from {Source} - {Description}";
    }
}