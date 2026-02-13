using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProj
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 45, 67, 2, 78, 98, 9, 56, 76, 34, 23, 87, 75, 43 };

            //int count = 0;
            //for(int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] > 40)
            //        count += 1;
            //}

            //int[] brr = new int[count];
            //int index = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] > 40)
            //    {
            //        brr[index] = arr[i];
            //        index += 1;
            //    }
            //}

            //Array.Sort(brr);
            //Array.Reverse(brr);

            var brr = from i in arr where i > 40 orderby i descending select i;

            foreach(int i in brr)
                Console.WriteLine(i + " ");
            Console.ReadLine();
        }
    }
}
