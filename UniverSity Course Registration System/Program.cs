using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods
                    switch (choice)
                    {
                        case "1":
                           Console.Write("Code: ");
                            string code = Console.ReadLine();

                            Console.Write("Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Credits: ");
                            int credits = int.Parse(Console.ReadLine());

                            system.AddCourse(code, name, credits);
                            Console.WriteLine("Course added.");
                            break; 
                        
                        case "2":
                            Console.Write("ID: ");
                            string id = Console.ReadLine();

                            Console.Write("Name: ");
                            string sname = Console.ReadLine();

                            Console.Write("Major: ");
                            string major = Console.ReadLine();

                            system.AddStudent(id, sname, major);
                            Console.WriteLine("Student added.");
                            break;

                        case "3":
                            Console.Write("Student ID: ");
                            string sid = Console.ReadLine();

                            Console.Write("Course Code: ");
                            string ccode = Console.ReadLine();

                            Console.WriteLine(system.RegisterStudentForCourse(sid, ccode) ? "Registered." : "Failed.");
                            break;

                        case "4":
                            Console.Write("Student ID: ");
                            sid = Console.ReadLine();

                            Console.Write("Course Code: ");
                            ccode = Console.ReadLine();

                            Console.WriteLine(system.DropStudentFromCourse(sid, ccode) ? "Dropped." : "Failed.");
                            break;

                        case "5":
                            system.DisplayAllCourses();
                            break;

                        case "6":
                            Console.Write("Student ID: ");
                            sid = Console.ReadLine();
                            system.DisplayStudentSchedule(sid);
                            break;

                        case "7":
                            system.DisplaySystemSummary();
                            break;

                        case "8":
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}