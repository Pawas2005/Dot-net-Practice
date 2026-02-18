using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace MultipleStringOperationsJava;

public class Program
{
    public static void Main()
    {
        int T = int.Parse(Console.ReadLine());

        while(T-- > 0)
        {
            Console.WriteLine("Enter the String: ");
            string str = Console.ReadLine();

            int k = int.Parse(Console.ReadLine());

            string res = ProcessString(str, k);
            Console.WriteLine("Result : " + ProcessString(str, k));
        }
    }

    public static string ProcessString(string str, int k)
    {
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);

        StringBuilder vowelReplaced = new StringBuilder();

        foreach(char ch in reversed)
        {
            vowelReplaced.Append(GetNextVowel(ch));
        }

        HashSet<char> seen = new HashSet<char>();
        StringBuilder noDupl = new StringBuilder();

        foreach(char ch in vowelReplaced.ToString())
        {
            if (!seen.Contains(ch))
            {
                seen.Add(ch);
                noDupl.Append(ch);
            }
        }

        string uniqStr = noDupl.ToString();

        k = k % uniqStr.Length;

        return uniqStr.Substring(uniqStr.Length - k) + uniqStr.Substring(0, uniqStr.Length - k);
    }

    public static char GetNextVowel(char ch)
    {
        bool isUpper = char.IsUpper(ch);
        char lower = char.ToLower(ch);
        char newChar = ch;

        switch (lower)
        {
            case 'a':
                newChar = 'e';
                break;

            case 'e':
                newChar = 'i';
                break;

            case 'i':
                newChar = 'o';
                break;

            case 'o':
                newChar = 'u';
                break;

            case 'u':
                newChar = 'a';
                break;

            default:
                return ch;
        }

        return isUpper ? char.ToUpper(ch) : newChar;
    }
}