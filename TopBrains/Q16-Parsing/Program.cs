using System;

namespace Parsing
{
    public class Program
    {
        public static int sumValidInt(string[] tokens)
        {
            int sum = 0;
            foreach(string token in tokens)
            {
                if(int.TryParse(token, out int value))
                {
                    sum += value;
                }
            }
            return sum;
        }

        public static void Main()
        {
            string[] tokens = { "10", "abc", "20", "99999999999", "-5", "3.5", "40" };
            int res = sumValidInt(tokens);

            Console.WriteLine(res);   
        }
    }
}