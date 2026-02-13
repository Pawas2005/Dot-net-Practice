using System;
using System.Runtime.CompilerServices;
namespace LongestSubstring;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter the string: ");
        string str = Console.ReadLine();

        // Dictionary array of size 256 (ASCII)
        int[] dict = new int[256];

        // Initialize all values to -1
        for(int i = 0; i < 256; i++)
        {
            dict[i] = -1;
        }

        int start = 0;
        int maxLen = 0;

        // Sliding window
        for(int i = 0; i < str.Length; i++)
        {
            // If character already seen in current window
            if(dict[str[i]] >= start)
                start = dict[str[i]] + 1;

            // Update last seen index
            dict[str[i]] = i;

            //calculate window length
            int length = i - start + 1;

            if(length > maxLen)
            {
                maxLen = length;
            }
        }
        Console.WriteLine("Longest Substring Length: " + maxLen);
    }
}