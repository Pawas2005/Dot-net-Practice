using System;

namespace GreatestCommonDivisor
{
    public class Program
    {
        //Simple approach
        // public static int gcd(int a, int b)
        // {
        //     while(b != 0)
        //     {
        //         int temp = b;
        //         b = a % b;
        //         a = temp;
        //     }
        //     return a;
        // }

        //Recursive approach
        public static int gcd(int a, int b)
        {
            if(b == 0)
            {
                return a;
            }

            return gcd(b, a % b);
        }

        public static void Main()
        {
            Console.Write("Enter the value of a : ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter the value of b : ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"G.C.D of a: {a} & b: {b} = " + gcd(a, b));
        }
    }
}