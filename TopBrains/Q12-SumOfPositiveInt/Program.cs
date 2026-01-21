using System;

namespace SumOfPositiveIntegers
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the value of n : ");
            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];
            for(int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                if(nums[i] > 0)
                {
                    sum += nums[i]; //only add +ve values
                }
                else if(nums[i] == 0) 
                {
                    break; //stop when 0 comes
                }
                else 
                {
                    continue; //ignore negatives
                }
            }

            Console.WriteLine("Sum : " + sum);
        }
    }
}