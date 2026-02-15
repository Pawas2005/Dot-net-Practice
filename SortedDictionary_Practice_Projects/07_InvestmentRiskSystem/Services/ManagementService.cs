using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, List<Investment>> data = new SortedDictionary<int, List<Investment>>();

        public void AddInvestment(Investment investment)
        {
            if(investment.Riskrating < 1 || investment.Riskrating > 5)
            {
                throw new InvalidRiskRatingException("Invalid Risk Rating");
            }

            if(data.Values.Any(List => List.Any(l => l.InvestmentId == investment.InvestmentId)))
            {
                throw new DuplicateInvestmentException("Duplicate ID Found");
            }

            if (!data.ContainsKey(investment.Riskrating))
            {
                data[investment.Riskrating] = new List<Investment>();
            }

            data[investment.Riskrating].Add(investment);
            Console.WriteLine("Investment added Successfully.");
        }

        public void DisplayInvestments()
        {
            if(data.Count() == 0)
            {
                Console.WriteLine("No data found");
                return;
            }

            foreach(var riskKey in data.Keys)
            {
                foreach(var r in data[riskKey])
                {
                    Console.WriteLine($"Details: {r.InvestmentId} {r.AssetName} {r.Riskrating}");
                }
            }
        }

        public void UpdateRisk(string id, int riskR)
        {
            if(riskR < 1 || riskR > 5)
            {
                throw new InvalidRiskRatingException("Invalid Risk Rating");
            }

            foreach(var riskKey in data.Values)
            {
                var risk = riskKey.FirstOrDefault(r => r.InvestmentId == id);

                if(risk != null)
                {
                    risk.Riskrating = riskR;
                    Console.WriteLine("Risk Rating Updated Successfully.");
                    return;
                }
            }
        }
    }
}
