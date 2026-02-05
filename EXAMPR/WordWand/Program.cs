using System;

namespace WordWand;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the sentence");
        string sentence = Console.ReadLine();

        //valid sentence (only letters and space)
        foreach(char ch in sentence)
        {
            if(!(char.IsLetter(ch) || ch == ' '))
            {
                Console.WriteLine("Invalid Sentence");
                return;
            }
        }
    
        //Split Sentence
        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int wordCount = words.Length;
        Console.WriteLine("Word Count: " + wordCount);

        // If word count is even → reverse word order
        if(wordCount %2 == 0)
        {
            Array.Reverse(words);
            Console.WriteLine(string.Join(" ", words));
        }
        // If word count is odd → reverse letters of each word
        else
        {
            for(int i = 0; i < words.Length; i++)
            {
                char[] letters = words[i].ToCharArray();
                Array.Reverse(letters);
                words[i] = new string(letters);
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }
}