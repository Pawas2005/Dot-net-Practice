using System;
using System.Collections.Generic;
using Domain;
using Services;
using Exceptions;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MedicineUtility medicineUtility = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("\n===== Pharmacy Medicine Inventory System =====");
                Console.WriteLine("1. Display all medicines (sorted by expiry year)");
                Console.WriteLine("2. Update medicine price");
                Console.WriteLine("3. Add medicine");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            medicineUtility.DisplayAll();
                            break;

                        case 2:
                            Console.Write("Enter the id for updation : ");
                            string id = Console.ReadLine();

                            Console.Write("Enter the newPrice : ");
                            int newPrice = int.Parse(Console.ReadLine());
                            
                            medicineUtility.UpdateMedicinePrice(id, newPrice);
                            break;

                        case 3:
                            string[] input = Console.ReadLine().Split(' ');

                            Medicine med = new Medicine()
                            {
                                Id = input[0],
                                Name = input[1],
                                Price = int.Parse(input[2]),
                                ExpiryYear = int.Parse(input[3])
                            };

                            medicineUtility.AddMedicine(med);
                            break;

                        case 4:
                            Console.WriteLine("Thank You!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Please select 1-4");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }
    }
}
