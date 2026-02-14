using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class MedicineUtility
    {
        // SortedDictionary sorted by ExpiryYear (ascending)
        private SortedDictionary<int, List<Medicine>> medicines = new SortedDictionary<int, List<Medicine>>();

        public void AddMedicine(Medicine medicine)
        {
            if (medicine.Price <= 0)
            {
                throw new Exceptions.InvalidPriceException("Invalid Price");
            }

            if (medicine.ExpiryYear < DateTime.Now.Year)
            {
                throw new Exceptions.InvalidExpiryYearException("Invalid Expiry Year.");
            }

            //check duplicates
            if (medicines.Values.Any(list => list.Any(m => m.Id == medicine.Id)))
            {
                throw new Exceptions.DuplicateMedicineException("Medicine ID already exists.");
            }

            if (!medicines.ContainsKey(medicine.ExpiryYear))
            {
                medicines[medicine.ExpiryYear] = new List<Medicine>();
            }

            medicines[medicine.ExpiryYear].Add(medicine);
            Console.WriteLine("Medicine Added Successfully.");
        }

        public SortedDictionary<int, List<Medicine>> GetAllMedicines()
        {
            return medicines;
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            if (newPrice <= 0)
                throw new InvalidPriceException("Invalid Price");

            foreach (var list in medicines.Values)
            {
                var med = list.FirstOrDefault(m => m.Id == id);
                if (med != null)
                {
                    med.Price = newPrice;
                    Console.WriteLine("Medicine Price Updated Successfully.");
                    return; 
                }
            }
            throw new MedicineNotFoundException("Medicine Not Found");
        }

        public void DisplayAll()
        {   
            if(medicines.Count() == 0)
            {
                Console.WriteLine("No medicines available.");
                return;
            }
            else
            {
                foreach(var year in medicines.Keys)
                {
                    foreach(var med in medicines[year])
                    {
                        Console.WriteLine($"Details: {med.Id} {med.Name} {med.Price} {med.ExpiryYear}");
                    }
                }
            }
        }
    }
}
