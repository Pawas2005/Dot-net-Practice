using System;
namespace SmartBank;

public class Program
{
    public static void Main()
    {
        try
        {
            CreditRiskProcessor processor = new CreditRiskProcessor();

            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter employment type: ");
            string employmentType = Console.ReadLine();

            Console.Write("Enter monthly income: ");
            double income = double.Parse(Console.ReadLine());

            Console.Write("Enter existing credit dues: ");
            double dues = double.Parse(Console.ReadLine());

            Console.Write("Enter credit score: ");
            int score = int.Parse(Console.ReadLine());

            Console.Write("Enter number of loan defaults: ");
            int defaults = int.Parse(Console.ReadLine());

            //for validateCustomerDetails
            processor.validateCustomerDetails(age, employmentType, income, dues, score, defaults);

            //for calculateCreditLimit
            double creditLimit = processor.calculateCreditLimit(income, dues, score, defaults);

            Console.WriteLine("============ Output =========");

            Console.WriteLine("Customer Name: " + name);
            Console.WriteLine("Approved Credit Limit: " + creditLimit);
        }
        catch(InvalidCreditDataException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}