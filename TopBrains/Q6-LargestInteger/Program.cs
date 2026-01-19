using System;

namespace LargestInteger
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the value of a : ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter the value of b : ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Enter the value of c : ");
            int c = int.Parse(Console.ReadLine());

            if(a > b && a > c)
            {
                Console.WriteLine($"\na : {a} is the largest.");
            }
            else if(b > a && b > c)
            {
                Console.WriteLine($"\nb : {b} is the largest.");
            }
            else
            {
                Console.WriteLine($"\nc : {c} is the largest.");
            }
        }
    }
}