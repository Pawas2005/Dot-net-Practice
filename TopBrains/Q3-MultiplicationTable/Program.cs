using System;

namespace MultiplicationTable
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the no. u want to multiply : ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter the no. upto wich u multiply : ");
            int upto = int.Parse(Console.ReadLine());

            int[] result = new int[upto];

            for(int i = 1; i <= upto; i++)
            {
                result[i - 1] = n * i;
            }

            Console.WriteLine($"Result of Multiplication table of {n} upto {upto} is : [{string.Join(", ", result)}]"); 
        }
    }
}