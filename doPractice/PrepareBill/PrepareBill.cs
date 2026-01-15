using System;

namespace PrepareBillApp
{
    class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates; //readonly

        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }

        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            if (!_taxRates.ContainsKey(category))
            {
                _taxRates.Add(category, taxRate);
            }
        }

        public double CalculateBillAmount(IList<Commodity> items)
        {
            double total = 0;

            foreach(var item in items)
            {
                if (!_taxRates.ContainsKey(item.Category))
                {
                    throw new ArgumentException("Tax rate not defined for this category " + item.Category);
                }

                double baseAmount = item.CommodityPrice * item.CommodityQuantity;
                double tax = baseAmount * _taxRates[item.Category] / 100;
                
                total += baseAmount + tax;
            }

            return total;
        }
    }
}