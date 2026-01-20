using System;

namespace SortedArrays
{
    public class Program
    {
        public static T[] MergeSortedArrays<T>(T[] a, T[] b) where T : IComparable<T>
        {
            int n = a.Length;
            int m = b.Length;

            T[] merged = new T[n + m];
            int i = 0, j = 0, k = 0;

            while(i < n && j < m)
            {
                if(a[i].CompareTo(b[j]) <= 0)
                {
                    merged[k++] = a[i++];
                }
                else
                {
                    merged[k++] = b[j++];
                }
            }

            while(i < n)
            {
                merged[k++] = a[i++];
            }

            while(j < m)
            {
                merged[k++] = b[j++];
            }

            return merged;
        }

        public static void Main()
        {
            Console.Write("Enter the no. of elemnts in n : ");
            int n = int.Parse(Console.ReadLine());

            int[] a = new int[n];
            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter the number of elements in b : ");
            int m = int.Parse(Console.ReadLine());

            int[] b = new int[m];
            for(int i = 0; i < m; i++)
            {
                b[i] = int.Parse(Console.ReadLine());
            }

            int[] merged = MergeSortedArrays(a, b);
            Console.WriteLine("\nMerged Sorted Arrays : ");
            Console.WriteLine(String.Join(" ", merged));
        }
    }
}