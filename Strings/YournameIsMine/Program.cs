using System;

public class Program
{
    public static bool IsValidName(string name)
    {
        foreach (char ch in name)
        {
            if (!char.IsLetter(ch) && ch != ' ')
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsSubsequence(string a, string b)
    {
        int i = 0, j = 0;

        while (i < a.Length && j < b.Length)
        {
            if (a[i] == b[j])
                i++;
            j++;
        }

        return i == a.Length;
    }

    public static int CompatibilityValue(string s1, string s2)
    {
        int m = s1.Length;
        int n = s2.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0)
                    dp[i, j] = j;
                else if (j == 0)
                    dp[i, j] = i;
                else if (s1[i - 1] == s2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                else
                    dp[i, j] = 1 + Math.Min(
                        dp[i - 1, j - 1],
                        Math.Min(dp[i - 1, j], dp[i, j - 1])
                    );
            }
        }

        return dp[m, n];
    }

    public static void Main()
    {
        Console.WriteLine("Enter the man name");
        string mName = Console.ReadLine().ToLower();

        Console.WriteLine("Enter the woman name");
        string wName = Console.ReadLine().ToLower();

        bool manValid = IsValidName(mName);
        bool womanValid = IsValidName(wName);

        if (!manValid && !womanValid)
        {
            Console.WriteLine($"Both {mName} and {wName} are invalid names");
            return;
        }
        else if (!manValid)
        {
            Console.WriteLine($"{mName} is an invalid name");
            return;
        }
        else if (!womanValid)
        {
            Console.WriteLine($"{wName} is an invalid name");
            return;
        }

        if (IsSubsequence(mName, wName) || IsSubsequence(wName, mName))
        {
            Console.WriteLine($"{mName} and {wName} are made for each other");

            int value = CompatibilityValue(mName, wName);
            Console.WriteLine($"Compatibility Value is {value}");
        }
        else
        {
            Console.WriteLine($"{mName} and {wName} are not made for each other");
        }
    }
}
