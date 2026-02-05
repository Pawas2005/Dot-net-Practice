using System;

namespace PasswordGeneration;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the username");
        string username = Console.ReadLine();

        //  Length must be 8
        if(username.Length < 8)
        {
            Console.WriteLine($"{username} ia an invalid useename");
            return;
        }

        //First 4 characters must be uppercase alphabets
        for(int i = 0; i < 4; i++)
        {
            if (!char.IsUpper(username[i]))
            {
                Console.WriteLine(username + " is an invalid username");
                return;
            }
        }

        //5th character must be '@'
        if(username[4] != '@')
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        // Last 3 characters must be digits
        string lastThree = username.Substring(5, 3);

        if(!int.TryParse(lastThree, out int courseId))
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        //Course id range 101 to 115
        if (courseId < 101 || courseId > 115)
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        // Take first 4 characters and convert to lowercase
        string firstFourLower = username.Substring(0, 4).ToLower();

        //Calculate ASCII sum
        int asciiSum = 0;
        foreach (char ch in firstFourLower)
        {
            asciiSum += ch;
        }

        // Get last 2 digits of ASCII sum
        int lastTwoDigits = courseId % 100;

        string password = "TECH_" + asciiSum + lastTwoDigits;
        Console.WriteLine("Password: " + password);
    }
}