using System;
namespace ShopValidator;

public class Program
{
    public static void Main()
    {
        GadgetValidatorUtil util = new GadgetValidatorUtil();

        Console.WriteLine("Enter the number of gadget entries");
        int n = int.Parse(Console.ReadLine());

        for(int i = 1; i <= n; i++)
        {
            Console.WriteLine("Enter gadget " + i + " details");
            string input = Console.ReadLine();

            try
            {
                string[] parts = input.Split(':');

                string gadgetID = parts[0];
                int period = int.Parse(parts[2]);

                util.validateGadgetID(gadgetID);
                util.validateWarrantyPeriod(period);

                Console.WriteLine("Warranty accepted, stock updated");
            }
            catch (InvalidGadgetException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}