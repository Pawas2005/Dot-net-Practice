using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class Studentutility
    {
        private SortedDictionary<double, List<Student>> students = new SortedDictionary<double, List<Student>>();

        public void AddStudent(Student student)
        {
            if (student.GPA < 0 || student.GPA > 10)
            {
                throw new Exceptions.InvalidGPAException("GPA must be 0-10");
            }

            if (students.Values.Any(List => List.Any(s => s.Id == student.Id)))
            {
                throw new Exceptions.DuplicateStudentException("Duplicate Student ID");
            }

            if (!students.ContainsKey(student.GPA))
            {
                students[student.GPA] = new List<Student>();
            }

            students[student.GPA].Add(student);
            Console.WriteLine("Student Added Successfully.");
        }

        public void DisplayRanking()
        {
            if(students.Count == 0)
            {
                Console.WriteLine("No Students Available");
                return;
            }
            else
            {
                foreach(var gpa in students.Keys)
                {
                    foreach(var s in students[gpa])
                    {
                        Console.WriteLine($"Details: {s.Id} {s.Name} {s.GPA}");
                    }
                }
            }
        }

        public void UpdateGPA(string id, double newGpa)
        {
            if(newGpa < 0 || newGpa > 10)
            {
                throw new Exceptions.InvalidGPAException("Invalid GPA");
            }

            foreach (var item in students.Values)
            {
                var stud = item.FirstOrDefault(s => s.Id == id);

                if(stud != null)
                {
                    stud.GPA = newGpa;
                    Console.WriteLine("Student GPA Updated Successfully.");
                    return;
                }
            }
            throw new Exceptions.StudentNotFoundException("Student Not Found");
        }

        public void Remove(string id)
        {
            foreach(var gpakey in students.Keys.ToList())
            {
                var stud = students[gpakey].FirstOrDefault(s => s.Id == id);

                if(stud != null)
                {
                    students[gpakey].Remove(stud);

                    if(students[gpakey].Count() == 0)
                    {
                        students.Remove(gpakey);
                    }
                    Console.WriteLine("Student Removed Successfully.");
                    return;
                }
            }
            throw new StudentNotFoundException("Student Not Found");
        }
    }
}