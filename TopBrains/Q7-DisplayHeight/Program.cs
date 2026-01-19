using System;

namespace DisplayHeight
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the height in CM : ");
            int height = int.Parse(Console.ReadLine());

            if(height < 150)
            {
                Console.WriteLine("Short");
            }
            else if(height >= 180)
            {
                Console.WriteLine("Tall");
            }
            else
            {
                Console.WriteLine("Average");
            }
        }
    }
}