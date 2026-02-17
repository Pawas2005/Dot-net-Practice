using System;
namespace CalculateNumbers;

public class Program
{
    public static List<int> NumberList = new List<int>();

    public  void AddNumbers(int numbers)
    {
        NumberList.Add(numbers);
    }

    public double GetGPAScored()
    {
        if(NumberList.Count == 0) return -1;

        double sum = 0;
        foreach(int num in NumberList)
        {
            sum += num * 3;
        }

        double gpa = sum / (NumberList.Count * 3);
        return gpa;
    }

    public char GetGradeScored(double gpa)
    {
        if(gpa < 5 || gpa > 10) return '\0';

        if(gpa == 10) return 'S';
        if(gpa >= 9) return 'A';
        if(gpa >= 8) return 'B';
        if(gpa >= 7) return 'C';
        if(gpa >= 6) return 'D';
        return 'E';
    }

    public static void Main()
    {
        Program p = new Program();

        Console.Write("Enter how many numbers: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            p.AddNumbers(int.Parse(Console.ReadLine()));
        }

        double gpa = p.GetGPAScored();
        if (gpa == -1)
        {
            Console.WriteLine("No Numbers Available");
            return;
        }

        Console.WriteLine($"GPA: {gpa}");
        char grade = p.GetGradeScored(gpa);

        if (grade == '\0')
            Console.WriteLine("Invalid GPA");
        else
            Console.WriteLine($"Grade: {grade}");
    }
}