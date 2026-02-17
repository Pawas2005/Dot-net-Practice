using System;
namespace EcommerceApplication;

public class Program
{
    public EcommerceShop MakePayment(string name, double balance, double amount)
    {
        if(balance < amount)
            throw new InsufficientWalletBalanceException("Insufficient balance in your digital wallet.");

        return new EcommerceShop
        {
            UserName = name,
            WalletBalance = balance - amount,
            TotalPurchaseAmount = amount
        };
    }

    public static void Main()
    {
        Program p = new Program();

        Console.Write("Enter user name: ");
        string name = Console.ReadLine();

        Console.Write("Enter wallet balance: ");
        double balance = double.Parse(Console.ReadLine());

        Console.Write("Enter purchase amount: ");
        double amount = double.Parse(Console.ReadLine());

        try
        {
            EcommerceShop shop = p.MakePayment(name, balance, amount);
            Console.WriteLine("Payment successful");
        }
        catch (InsufficientWalletBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}