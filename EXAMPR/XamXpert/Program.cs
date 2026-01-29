using System;

namespace XamXpert;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter Exam Details:");

        Console.WriteLine("Student Name:");
        string Name = Console.ReadLine();

        Console.WriteLine("Question Type (MCQ/Coding): ");
        string type = Console.ReadLine();

        Console.WriteLine("Total Questions: ");
        int total = int.Parse(Console.ReadLine());

        Console.WriteLine("Correct Answers: ");
        int correct = int.Parse(Console.ReadLine());

        Console.WriteLine("Wrong Answers: ");
        int wrong = int.Parse(Console.ReadLine());

        OnlineTest test = new OnlineTest(Name, total, correct, wrong, type);

        double percentage = test.calculateScore();
        string result = Exam.evaluateResult(percentage);

        Console.WriteLine();
        Console.WriteLine("Exam Summary:");
        Console.WriteLine($"{type} Test: {Name}, Total Score: {percentage:F1}, Result: {result}");
    }
}