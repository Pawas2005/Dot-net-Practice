using System;

namespace StudentGradeManagementSystem;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string GradeLevel { get; set; }

    // Subject->Grade
    public Dictionary<string, double> Subjects { get; set; } = new Dictionary<string, double>();

    public override string ToString()
    {
        string subjectDetails = string.Join(", ", Subjects.Select(S => $"{S.Key}:{S.Value}"));
        return $"Student ID: S{StudentId:D3}, Name: {Name}, Grade Level: {GradeLevel}, Subjects: [{subjectDetails}]";
    }
}