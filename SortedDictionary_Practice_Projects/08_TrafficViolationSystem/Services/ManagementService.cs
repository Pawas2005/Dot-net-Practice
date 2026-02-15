using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, List<Violation>> data = new SortedDictionary<int, List<Violation>>(
                                                                Comparer<int>.Create((a, b) => b.CompareTo(a)));

        public void AddViolation(Violation violation)
        {
            if(violation.FineAmount < 0)
            {
                throw new InvalidFineAmountException("Invalid Fine Amount");
            }

            if(data.Values.Any(List => List.Any(v => v.VehicleNumber == violation.VehicleNumber)))
            {
                throw new DuplicateViolationException("Duplicate Found");
            }

            if (!data.ContainsKey(violation.FineAmount))
            {
                data[violation.FineAmount] = new List<Violation>();
            }

            data[violation.FineAmount].Add(violation);
            Console.WriteLine("Violation Added Successfully");
        }

        public void DisplayViolations()
        {
            if(data.Count() == 0)
            {
                Console.WriteLine("No data found");
                return;
            }

            foreach(var finekey in data.Keys)
            {
                foreach(var f in data[finekey])
                {
                    Console.WriteLine($"Details: {f.VehicleNumber} {f.OwnerName} {f.FineAmount}");
                }
            }
        }

        public void PayFine(string vehicleId, int amount)
        {
            if(amount <= 0)
            {
                throw new InvalidFineAmountException("Invalid Amount");
            }

            foreach(var fineKey in data.Keys.ToList())
            {
                var fine = data[fineKey].FirstOrDefault(f => f.VehicleNumber == vehicleId);

                if(fine != null)
                {
                    if(amount > fine.FineAmount)
                    {
                        throw new InvalidFineAmountException("Payment exceeds fine");
                    }

                    data[fineKey].Remove(fine);

                    if(data[fineKey].Count == 0)
                    {
                        data.Remove(fineKey);
                    }
                    fine.FineAmount -= amount;

                    if (!data.ContainsKey(fine.FineAmount))
                    {
                        data[fine.FineAmount] = new List<Violation>();
                    }
                    data[fine.FineAmount].Add(fine);

                    Console.WriteLine("Fine Paid Successfully.");
                    return;
                }
            }
        }
    }
}
