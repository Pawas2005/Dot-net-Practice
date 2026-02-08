using System;
using System.Linq;
using System.Collections.Generic;

namespace StudentGradeManagementSystem;

public class SchoolManager
{
    private List<Student> students = new List<Student>();
    private int counter = 1;

    // Add Student
    public void AddStudent(string name, string gradeLevel)
    {
        students.Add(new Student
        {
           StudentId = counter++,
           Name = name,
           GradeLevel = gradeLevel
        });
    }

    // Adds grade for student (0-100 scale)
    public void AddGrade(int studentId, string subject, double grade)
    {
        var student = students.FirstOrDefault(s => s.StudentId == studentId);

        if(student != null && grade >= 0 && grade <= 100)
        {
            student.Subjects[subject] = grade;
        }
    }

    // Groups students by grade level
    public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
    {
        var grouped = students.GroupBy(s => s.GradeLevel)
                    .ToDictionary(s => s.Key, s => s.ToList());

        return new SortedDictionary<string, List<Student>>(grouped);
    }

    // Returns student's average grade
    public double CalculateStudentAverage(int studentId)
    {
        var student =  students.FirstOrDefault(s => s.StudentId == studentId);

        if(student == null || !student.Subjects.Any())
            return 0;

        return student.Subjects.Values.Average();
    }

    // Returns average grade per subject across all students
    public Dictionary<string, double> CalculateSubjectAverages()
    {
        return students.SelectMany(s => s.Subjects)
                .GroupBy(sub => sub.Key)
                .ToDictionary(g => g.Key, g => g.Average(x => x.Value));
    }

    // Returns top N students by average grade
    public List<Student> GetTopPerformers(int count)
    {
        return students
        .OrderByDescending(s => s.Subjects.Any() ? s.Subjects.Values.Average() : 0)
        .Take(count).ToList();
    }
}