using System;

namespace KhataApp
{
    public class Khata
    {
        private Dictionary<string, int> record;

        //constructor
        public Khata(Dictionary<string, int> record)
        {
            this.record = record;
        }

        // 1. Calculate Total Amount
        public int getTotal()
        {
            int total = 0;
            foreach(var item in record)
            {
                total += item.Value;
            }

            return total;
        }

        //2. Count Repeated Amounts
        public int getRepeatAmount()
        {
            Dictionary<int, int> amountCnt = new Dictionary<int, int>();

            // Counting how many times each amount appears
            foreach(var item in record)
            {
                int amount = item.Value;

                if (amountCnt.ContainsKey(amount))
                {
                    amountCnt[amount]++;
                }
                else
                {
                    amountCnt.Add(amount, 1);
                }
            }

             // Count how many amounts appeared more than once
            int repeatedAmt = 0;
            foreach(var item in amountCnt)
            {
                if(item.Value > 1)
                {
                    repeatedAmt++;
                }
            }
            return repeatedAmt;
        }

        //3. AddItem
        public void AddItem(string itemName, int amount)
        {
            if (!record.ContainsKey(itemName))
            {
                record.Add(itemName, amount);
            }
            else
            {
                Console.WriteLine("Items already exists.");
            }
        }
    }
}