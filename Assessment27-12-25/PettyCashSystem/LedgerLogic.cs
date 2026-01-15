using System;
using System.Collections.Generic;

namespace PettyCashSystem;

//Generic Class
public class Ledger<T> where T : Transaction
{
    //Storage: Internal List<T> to hold the transaction history.
    private List<T> transactions = new List<T>();

    //AddEntry
    public void AddEntry(T entry)
    {
        transactions.Add(entry);
    }

    //GetTransactionsByDate
    public List<T> GetTransactionsByDate(DateTime date)
    {
        List<T> result = new List<T>();

        foreach(T t in transactions)
        {
            //only comparing the date not the time
            if(t.Date.Date == date.Date)
            {
                result.Add(t);
            }
        }
        return result;
    } 

    //CalculateTotal
    public decimal CalculateTotal()
    {
        decimal total = 0;

        foreach(T t in transactions)
        {
            total += t.Amount;
        }

        return total;
    }

    public List<T> GetAll()
    {
        return transactions;
    }
}