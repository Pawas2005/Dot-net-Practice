using System;
using System.Data.Common;

namespace JewelleryStore;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] data = input.Split(' ');

        Jewellery jewellery = new Jewellery()
        {
            Id = data[0],
            Type = data[1],
            Price = int.Parse(data[2])
        };

        JewelleryUtility jewelleryUtility = new JewelleryUtility(jewellery);

        while (true)
        {
            string menuInput = Console.ReadLine();
            string[] parts = menuInput.Split(' ');

            int choice = int.Parse(parts[0]);

            if(choice == 1)
            {
                jewelleryUtility.GetJewelleryDetails();
            }

            else if(choice == 2)
            {
                int Price = int.Parse(parts[1]);
                jewelleryUtility.UpdateJewelleryPrice(Price);
            }

            else if(choice == 3)
            {
                Console.WriteLine("Thank You");
                break;
            }
        }
    }
}