using System;
using System.Text.RegularExpressions;
namespace WordFrequencyCounter;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the Word: ");
        string inp = Console.ReadLine();

        inp = inp.ToLower();

        inp = Regex.Replace(inp, @"[^\w\s]", "");   //FOR REPLACING PUNCTUATION
        
        string[] words = inp.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordcnt = new Dictionary<string, int>();

        foreach(string word in words)
        {
            if (wordcnt.ContainsKey(word))
            {
                wordcnt[word]++;
            }
            else
            {
                wordcnt[word] = 1;
            }
        }

        Console.WriteLine("\nWords Frequencies: ");
        foreach(var pair in wordcnt)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}