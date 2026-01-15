using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary;

namespace UILogic
{
    [Dotcor(Name = "Vivek Don", CheckedOnDate = "12/01/2026")]
    [Dotcor(Name = "Shiva", CheckedOnDate = "12/11/2025")]
    [Dotcor(Name = "Shalini", CheckedOnDate = "21/08/2025")]
    [Serializable]
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;

            Console.WriteLine("Enter first number: ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            num2 = int.Parse(Console.ReadLine());

            SomeLogic logic = new SomeLogic();

            int numResult = logic.AddMe(num1, num2);
            Console.WriteLine($"The sum of {num1} and {num2} is: {numResult}");



            Console.ReadKey();

        }
    }
}
