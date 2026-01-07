//IncomeTransaction.cs: Adds a Source property (e.g., Main Cash, Bank Transfer).
using System;

namespace PettyCashSystem;

public class IncomeTransaction : Transaction
{
    public string Source { get; set; }

    public override string GetSummary() //every non-abstract child class must provide its implementation.
    {
        return $"Income = ${Amount} from {Source} - {Description}";
    }
}