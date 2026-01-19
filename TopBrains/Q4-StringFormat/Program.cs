using System;
using System.Text.Json;

namespace StringFormat
{
    public record Student(string Name, int Score);
    public class Program
    {
        public static string BuildStudentJson(string[] items, int minScore)
        {
            if(items == null || items.Length == 0)
            {
                return "[]";
            }

            List<Student> students = new List<Student>();

            foreach (var item in items)
            {
                int idx = item.LastIndexOf(':');
                if(idx == -1) continue;

                string name = item.Substring(0, idx);

                if(!int.TryParse(item.Substring(idx + 1), out int score))
                    continue;

                if(score >= minScore)
                {
                    students.Add(new Student(name, score));
                }
            }

            var result = students
                            .OrderByDescending(s => s.Name)
                            .ThenBy(S => S.Name)
                            .ToList();

            return JsonSerializer.Serialize(result);
        }

        public static void Main()
        {
            string[] items = { "Amrita:85", "Riya:92", "Amit:90", "Neha:70" };
            int minScore = 80;

            string json = BuildStudentJson(items, minScore);
            Console.WriteLine(json);
        }
    }
}