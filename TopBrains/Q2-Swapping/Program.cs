using System;
using System.Security.Cryptography.X509Certificates;

namespace Swapping
{
    public class Program
    {
        // Method 1: Using ref(Temp)
        // public static void SwapUsingTemp(ref int a, ref int b)
        // {
        //     int temp = a;
        //     a = b;
        //     b = temp;
        // }

        // Method 1: Using ref(Without using temp)
        public static void SwapWithoutTemp(ref int a, ref int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }

        //Method 2: Using out(Without using temp)
        public static void SwapOut(int x, int y, out int a, out int b)
        {
            a = y;
            b = x;
        }

        public static void Main()
        {
            int x = 5;
            int y = 6;

            Console.WriteLine("Before Swap: x => " + x + ", y = " + y);
            
            // SwapUsingTemp(ref x, ref y);
            // Console.WriteLine("After Swap using Ref method : x => " + x + ", y = " + y);

            SwapWithoutTemp(ref x, ref y);
            Console.WriteLine("After Swap using Ref method without temp : x => " + x + ", y = " + y);

            SwapOut(x, y, out int a, out int b);
            Console.WriteLine("After Swap using Out method without temp : a => " + a + ", b = " + b);
        }
    }
}