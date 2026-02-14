using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Studentutility studentutility = new Studentutility();

            while (true)
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Remove");
                Console.WriteLine("5. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data

                        studentutility.DisplayRanking();
                        break;

                    case 2:
                        // TODO: Add entity
                        string[] inp = Console.ReadLine().Split(' ');

                        Student std = new Student()
                        {
                            Id = inp[0],
                            Name = inp[1],
                            GPA = double.Parse(inp[2])
                        };

                        studentutility.AddStudent(std);
                        break;

                    case 3:
                        // TODO: Update entity
                        string id = Console.ReadLine();
                        double gpa = double.Parse(Console.ReadLine());

                        studentutility.UpdateGPA(id, gpa);
                        break;

                    case 4:
                        // TODO: Remove entity
                        string rid = Console.ReadLine();

                        studentutility.Remove(rid);
                        break;

                    case 5:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid choice! Please select 1-4");
                        break;
                }
            }
        }
    }
}
