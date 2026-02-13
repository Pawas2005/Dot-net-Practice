// using System;

// namespace PasswordGeneration;

// public class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Enter the username");
//         string username = Console.ReadLine();

//         //  Length must be 8
//         if(username.Length < 8)
//         {
//             Console.WriteLine($"{username} ia an invalid useename");
//             return;
//         }

//         //First 4 characters must be uppercase alphabets
//         for(int i = 0; i < 4; i++)
//         {
//             if (!char.IsUpper(username[i]))
//             {
//                 Console.WriteLine(username + " is an invalid username");
//                 return;
//             }
//         }

//         //5th character must be '@'
//         if(username[4] != '@')
//         {
//             Console.WriteLine(username + " is an invalid username");
//             return;
//         }

//         // Last 3 characters must be digits
//         string lastThree = username.Substring(5, 3);

//         if(!int.TryParse(lastThree, out int courseId))
//         {
//             Console.WriteLine(username + " is an invalid username");
//             return;
//         }

//         //Course id range 101 to 115
//         if (courseId < 101 || courseId > 115)
//         {
//             Console.WriteLine(username + " is an invalid username");
//             return;
//         }

//         // Take first 4 characters and convert to lowercase
//         string firstFourLower = username.Substring(0, 4).ToLower();

//         //Calculate ASCII sum
//         int asciiSum = 0;
//         foreach (char ch in firstFourLower)
//         {
//             asciiSum += ch;
//         }

//         // Get last 2 digits of ASCII sum
//         int lastTwoDigits = courseId % 100;

//         string password = "TECH_" + asciiSum + lastTwoDigits;
//         Console.WriteLine("Password: " + password);
//     }
// }








using System;
using System.Collections; 

// class NonGenericExample
// {
//     static void Main()
//     {
//         ArrayList list = new ArrayList();

//         list.Add(10);
//         list.Add("Hello");
//         list.Add(3.14);

//         foreach (var item in list)
//         {
//             Console.WriteLine(item);
//         }
//     }
// }



// using System.Collections.Generic;

// class GenericExample
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int>();

//         numbers.Add(10);
//         numbers.Add(20);
//         numbers.Add(30);

//         foreach (int num in numbers)
//         {
//             Console.WriteLine(num);
//         }
//     }
// }





// class Reverse
// {
//     static void Main()
//     {
//         string input = "Hello";
//         string reversed = "";

//         for (int i = input.Length - 1; i >= 0; i--)
//         {
//             reversed += input[i];
//         }

//         Console.WriteLine("Original String: " + input);
//         Console.WriteLine("Reversed String: " + reversed);
//     }
// }








using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter word1: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter word2: ");
        string word2 = Console.ReadLine();

        int deletions = 0;

        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char ch in word2)
        {
            if (freq.ContainsKey(ch))
                freq[ch]++;
            else
                freq[ch] = 1;
        }

        //Compare with word1
        foreach (char ch in word1)
        {
            if (freq.ContainsKey(ch) && freq[ch] > 0)
            {
                freq[ch]--;  
            }
            else
            {
                deletions++;  // delete from word1
            }
        }

        Console.WriteLine(deletions);
    }
}
