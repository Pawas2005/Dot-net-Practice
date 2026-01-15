using System;

namespace MethodOverloading
{
    public class Program
    {
        public static void Main()
        {
            Source s = new Source();

            Console.WriteLine(s.Add(2, 3, 4));
            Console.WriteLine(s.Add(2.1, 3.1, 4.1));
        }
    }
}