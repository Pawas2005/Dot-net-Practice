using System;

namespace StudentScholarship
{
    public delegate bool IsEligibleforScholarship(Student std);
    public class Program
    {
        public static bool ScholarshipEligibility(Student std)
        {
            if(std.Marks > 80 && std.SportsGrade == 'A')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetEligibleStudents(List<Student> studentsList, IsEligibleforScholarship isEligible)
        {
            List<string> eligibleNames = new List<string>();

            foreach(var name in studentsList)
            {
                if (isEligible(name))
                {
                    eligibleNames.Add(name.Name);
                }
            }

            return string.Join(", ", eligibleNames);
        }

        public static void Main()
        {
            List<Student> lstStudents = new List<Student>();

            Student obj1 = new Student() { RollNo = 1, Name = "Raj", Marks = 75, SportsGrade = 'A' };    
            Student obj2 = new Student() { RollNo = 2, Name = "Rahul", Marks = 82, SportsGrade = 'A' };
            Student obj3 = new Student() { RollNo = 3, Name = "Kiran", Marks = 89, SportsGrade = 'B' };
            Student obj4 = new Student() { RollNo = 4, Name = "Sunil", Marks = 86, SportsGrade = 'A' };

            lstStudents.Add(obj1);    
            lstStudents.Add(obj2);   
            lstStudents.Add(obj3);   
            lstStudents.Add(obj4);

            //instance of delegate
            IsEligibleforScholarship del = ScholarshipEligibility;

            string result = GetEligibleStudents(lstStudents, del);

            Console.WriteLine(result);           
        }
    }
}