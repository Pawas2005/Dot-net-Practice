using System;
using System.Text;

namespace MahirlalAlphabets
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter first word : ");
            string word1 = Console.ReadLine();

            Console.Write("Enter second word : ");
            string word2 = Console.ReadLine();

            HashSet<Char> secondWordChars = new HashSet<char>();

            // Store all characters of second word in lowercase
            foreach(char c in word2.ToLower())
            {
                secondWordChars.Add(c);
            }

            StringBuilder Task1Result = new StringBuilder();

            // TASK 1: Remove common consonants
            foreach(char c in word1)
            {
                char lower = char.ToLower(c);

                if (IsVowel(lower))
                {
                    // Always keep vowels
                    Task1Result.Append(lower);
                }
                else
                {
                    // Consonant → keep only if NOT present in second word
                    if(!secondWordChars.Contains(lower))
                    {
                        Task1Result.Append(c);
                    }
                }
            }

            //Task2: Remove consecutive duplicates
            StringBuilder Task2Result = new StringBuilder();

            for(int i = 0; i < Task1Result.Length; i++)
            {
                if(i == 0 || Task1Result[i] != Task1Result[i - 1])
                {
                    Task2Result.Append(Task1Result[i]);
                }
            }
            Console.WriteLine(Task2Result.ToString());
        }

        public static bool IsVowel(char c)
        {
            return "aeiou".IndexOf(c) != -1;
        }
    }
}