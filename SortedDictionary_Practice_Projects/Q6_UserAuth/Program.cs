using System;
namespace UserAuthentication;

public class Program
{
    public User ValidatePassword(string name, string password, string confirmationPassword)
    {
        if(!password.Equals(confirmationPassword, StringComparison.Ordinal))
            throw new PasswordMismatchException("Password entered does not match.");

        return new User
        {
            Name = name,
            Password = password,
            ConfirmationPassword = confirmationPassword
        };
    }

    public static void Main()
    {
        Program p = new Program();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter password: ");
        string pass = Console.ReadLine();

        Console.Write("Confirm password: ");
        string confirm = Console.ReadLine();

        try
        {
            User u = p.ValidatePassword(name, pass, confirm);
            Console.WriteLine("Registered Successfully");
        }
        catch(PasswordMismatchException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}