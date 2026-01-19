using System;

namespace LuckyNumber
{
    public class Program
    {
        public static bool isPrime(int n)
        {
            if(n <= 1) return false;
            for(int i = 2; i * i <= n; i++)
            {
                if(n % i == 0)
                    return false;
            }    
            return true;
        }

        //function for sum of the digits of n
        public static int SumOfDigits(int n)
        {
            int sum = 0;
            while(n > 0)
            {
                int dgt = n % 10;
                sum += dgt;
                n /= 10;
            }
            return sum;
        }

        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            int cnt = 0;

            for(int i = m; i <= n; i++)
            {
                if (!isPrime(i)) //must be non-prime
                {
                    int sx = SumOfDigits(i);
                    int sxx = SumOfDigits(i * i);

                    if(sxx == sx * sx)
                    {
                        cnt++;
                    }
                }
            }
            Console.WriteLine(cnt);
        }
    }
}