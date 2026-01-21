using System;
using System.Globalization;
using System.Text;

namespace InventoryNameCleanup
{
    public class Program
    {
        public static string InventoryCleanUp(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                return "";

            //Step 1: Trim extra spaces
            // StringSplitOptions.RemoveEmptyEntries → removes extra spaces
            string trimmed = string.Join(" ", input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            // Step 2: Remove consecutive duplicate characters
            // StringBuilder → efficient duplicate removal
            StringBuilder sb = new StringBuilder();
            char prev = '\0';

            foreach(char c in trimmed.ToLower())
            {
                if(c != prev)
                {
                    sb.Append(c);
                    prev = c;
                }
            }

            string noDuplicates = sb.ToString();

            // Step 3: Convert to Title Case
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string result = textInfo.ToTitleCase(noDuplicates);   // TextInfo.ToTitleCase() → converts to Title Case

            return result;
        }

        public static void Main()
        {
            Console.Write("Enter the input : ");
            string input = Console.ReadLine();

            string output = InventoryCleanUp(input);

            Console.WriteLine(output);
        }
    }
}