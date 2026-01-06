    using System;

    namespace QuickMart;

    public class SaleTransaction
    {
        #region Properties
        public string InvoiceNo{ get; set; }
        public string CustomerName{ get; set; }
        public string ItemName{ get; set; }
        public int Quantity{ get; set; }
        public double PurchaseAmount{ get; set; }
        public double SellingAmount{ get; set; }
        public string ProfitOrLossStatus{ get; set; }
        public double ProfitOrLossAmount{ get; set; }
        public double ProfitMarginPercent{ get; set; }
        #endregion

        public void CreateMethod()
        {
            Console.Write("Enter Invoice No: ");
            InvoiceNo = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(InvoiceNo))
            {
                Console.WriteLine("InvoiceNo cannot be empty.");
                return;
            }

            Console.Write("Enter Customer No: ");
            CustomerName = Console.ReadLine();

            Console.Write("Enter Item Name: ");
            ItemName = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            Quantity = int.Parse(Console.ReadLine());
            if(Quantity <= 0)
            {
                Console.WriteLine("Quantity cannot be 0");
                return;
            }

            Console.Write("Enter Purchase Amount (total): ");
            PurchaseAmount = double.Parse(Console.ReadLine());
            if(PurchaseAmount < 0)
            {
                Console.WriteLine("Purchase Amount must be greater than 0.");
                return;
            }

            Console.Write("Enter Selling Amount (total): ");
            SellingAmount = double.Parse(Console.ReadLine());
            if(SellingAmount < 0)
            {
                Console.WriteLine("Selling Amount must be greater than 0.");
                return;
            }
            Console.WriteLine();

            Console.WriteLine("Transaction saved successfully.");
            CalculationMethod();
        }

        public void CalculationMethod()
        {
            if(SellingAmount > PurchaseAmount)
            {
                ProfitOrLossStatus = "PROFIT";
                ProfitOrLossAmount = SellingAmount - PurchaseAmount;
            }
            else if(PurchaseAmount > SellingAmount)
            {
                ProfitOrLossStatus = "LOSS";
                ProfitOrLossAmount = PurchaseAmount - SellingAmount;
            }
            else
            {
                ProfitOrLossStatus = "BREAK-EVEN";
                ProfitOrLossAmount = 0;
            }
            ProfitMarginPercent = Math.Round((ProfitOrLossAmount / PurchaseAmount) * 100, 2);

            Console.WriteLine("Status: " + ProfitOrLossStatus);
            Console.WriteLine("Profit/Loss Amount: " + ProfitOrLossAmount.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + ProfitMarginPercent.ToString("F2"));
        }

        public void ViewMethod()
        {
            Console.WriteLine("-------------- Last Transaction --------------");
            Console.WriteLine("InvoiceNo: " + InvoiceNo);
            Console.WriteLine("Customer: " + CustomerName);
            Console.WriteLine("Item: " + ItemName);
            Console.WriteLine("Quantity: " + Quantity);
            Console.WriteLine("Purchase Amount: " + PurchaseAmount.ToString("F2"));
            Console.WriteLine("Selling Alount: " + SellingAmount.ToString("F2"));
            Console.WriteLine("Status: " + ProfitOrLossStatus);
            Console.WriteLine("Profit/Loss Amount: " + ProfitOrLossAmount.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + ProfitMarginPercent.ToString("F2"));
            Console.WriteLine("------------------------------------------------------");
        }
    }