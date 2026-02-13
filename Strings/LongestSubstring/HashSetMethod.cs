using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter the String: ");
        string str = Console.ReadLine();

        Console.WriteLine("Longest Substring length " + LongestSubstringHashSet(str));
    }

    public static int LongestSubstringHashSet(string s)
    {
        HashSet<char> set = new HashSet<char>();

        int start = 0;
        int maxLen = 0;
        
        for(int i = 0; i < s.Length; i++)
        {
            // If duplicate found → shrink window
            while (set.Contains(s[i]))
            {
                set.Remove(s[start]);
                start++;
            }
            // Add current character
            set.Add(s[i]);

            int length = i - start + 1;
            if(length > maxLen)
                maxLen = length;
        }

        return maxLen;
    }
}