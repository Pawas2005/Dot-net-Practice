using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementService service = new ManagementService();

            while (true)
            {
                Console.WriteLine("================Hospital Emergency Patient Queue===================");           
                Console.WriteLine("1. Display Patients by Priority");
                Console.WriteLine("2. Update Severity");
                Console.WriteLine("3. Add Patient");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        service.DisplayPatientsByPriority();
                        break;

                    case 2:
                        // TODO: Update entity
                        string id = Console.ReadLine();
                        int level = int.Parse(Console.ReadLine());

                        service.UpdateSeverity(id, level);
                        break;

                    case 3:
                        // TODO: Add entity
                        string[] inp = Console.ReadLine().Split(' ');
                        Patient patient = new Patient()
                        {
                            PatientId = inp[0],
                            Name = inp[1],
                            SeverityLevel = int.Parse(inp[2])
                        };

                        service.AddPatient(patient);
                        break;
                        
                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice, Please select between 1-5");
                        break;
                }
            }
        }
    }
}
