using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryReceipts
{
    public class GroceryReceipt : GroceryReceiptBase
    {
        public GroceryReceipt(Dictionary<string, decimal> prices, Dictionary<string, decimal> discounts) : base(prices, discounts) {} 

        public override List<(string Name, decimal Prices, decimal Total)> CalculateInvoice(List<string> ShoppingList){
            return ShoppingList.GroupBy(item => item).Select(group =>
            {
                
            })
        }
    }
}
