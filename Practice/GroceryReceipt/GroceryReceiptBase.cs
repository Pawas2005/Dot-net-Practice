using System;
using System.Collections.Generic;

namespace GroceryReceipts
{
    public abstract class GroceryReceiptBase
    {
        public Dictionary<string, decimal> Prices { get; set; }
        public Dictionary<string, decimal> Discounts { get; set; }

        protected GroceryReceiptBase(Dictionary<string, decimal> prices, Dictionary<string, decimal> discounts)
        {
            Prices = prices;
            Discounts = discounts;
        } 

        public abstract List<(string Name, decimal Prices, decimal Total)> CalculateInvoice(List<string> ShoppingList);
    }
}