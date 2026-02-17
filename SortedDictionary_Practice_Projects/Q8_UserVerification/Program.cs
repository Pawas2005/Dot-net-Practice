using System;
namespace UserVerification;

public class Program
{
    public User ValidatePhoneNumber(string name, string phoneNumber)
    {
        if(phoneNumber != null && phoneNumber.Length == 10)
        {
            return new User
            {
                Name = name,
                PhoneNumber = phoneNumber
            };
        }
        throw new InvalidPhoneNumberException("Invalid Phone Number.");
    }

    public static void Main()
    {
        Program p = new Program();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter phone number: ");
        string phone = Console.ReadLine();

        try
        {
            User u = p.ValidatePhoneNumber(name, phone);
            Console.WriteLine("User Verified");
        }
        catch (InvalidPhoneNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}