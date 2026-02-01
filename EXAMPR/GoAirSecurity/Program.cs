using System;
using System.Text.Encodings.Web;
using System.Xml;

namespace GoAirSecurity;

public class Program
{
    public static void Main()
    {
        EntryUtility utility = new EntryUtility();

        Console.WriteLine("Enter the number of entries");
        int n = int.Parse(Console.ReadLine());

        for(int i = 1; i <= n; i++)
        {
            Console.WriteLine("Enter entry " + i + " details");
            string input = Console.ReadLine();

            try
            {
                string[] parts = input.Split(':'); // Split using colon
                string employeeID = parts[0];   // GOAIR/8924
                int duration = int.Parse(parts[2]);  // 4

                utility.validateEmployeeId(employeeID);
                utility.validateDuration(duration);

                Console.WriteLine("Valid entry details.");
            }
            catch (InvalidEntryException)
            {
                Console.WriteLine("Invalid entry details");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Entry details");
            }
        }
    }
}