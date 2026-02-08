using System;

namespace StudentGradeManagementSystem;

public class Program
{
    public static void Main()
    {
        SchoolManager schoolManager = new SchoolManager();

        // Add Students
        schoolManager.AddStudent("Alice", "10th");
        schoolManager.AddStudent("Bob", "10th");
        schoolManager.AddStudent("Charlie", "11th");
        schoolManager.AddStudent("David", "12th");
        
        // Add Grades
        schoolManager.AddGrade(1, "Math", 90);
        schoolManager.AddGrade(1, "Science", 85);

        schoolManager.AddGrade(2, "Math", 70);
        schoolManager.AddGrade(2, "Science", 75);

        schoolManager.AddGrade(3, "Math", 95);
        schoolManager.AddGrade(3, "Science", 92);

        schoolManager.AddGrade(4, "Math", 88);
        schoolManager.AddGrade(4, "Science", 80);

        // Group By Grade Level
        Console.WriteLine("Students Grouped By Grade Level:\n");

        var grouped = schoolManager.GroupStudentsByGradeLevel();
        foreach(var grade in grouped)
        {
            Console.WriteLine($"Grade: {grade.Key}");
            foreach(var student in grade.Value)
            {
                Console.WriteLine($" {student}");
            }
            Console.WriteLine();
        }

        // Student Average
        Console.Write("Enter Student Numeric Id (e.g., 1): ");
        int avgGrade = int.Parse(Console.ReadLine());

        Console.WriteLine(schoolManager.CalculateStudentAverage(avgGrade));

        // Subject Averages
        Console.WriteLine("\nSubject Averages:\n");

        var subjectAvg = schoolManager.CalculateSubjectAverages();
        foreach(var subject in subjectAvg)
        {
            Console.WriteLine($"{subject.Key} -> {subject.Value}");
        }

        //Top Performers
        Console.WriteLine("\nTop 2 Performers:\n");

        var toppers = schoolManager.GetTopPerformers(2);
        foreach(var topper in toppers)
        {
            Console.WriteLine(topper);
        }
    }
}