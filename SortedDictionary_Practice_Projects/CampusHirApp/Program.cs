using System;
namespace CampusHireApplicantManagementSystem;

public class Program
{
    public static void Main()
    {
        ApplicantManager applicantManager = new ApplicantManager();

        while (true)
        {
            Console.WriteLine("===== CampusHire Management =====");
            Console.WriteLine("1. Add Applicant");
            Console.WriteLine("2. Display All");
            Console.WriteLine("3. Search by ID");
            Console.WriteLine("4. Update Applicant");
            Console.WriteLine("5. Delete Applicant");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Applicant app = new Applicant()
                        {
                            ApplicantID = Console.ReadLine(),
                            ApplicantName = Console.ReadLine(),
                            CurrentLocation = Console.ReadLine(),
                            PreferredJobLocation = Console.ReadLine(),
                            CoreCompetency = Console.ReadLine(),
                            PassingYear = int.Parse(Console.ReadLine())
                        };
                        
                        applicantManager.addApplicant(app);
                        break;

                    case 2:
                        applicantManager.DisplayAll();
                        break;

                    case 3:
                        string id = Console.ReadLine();
                        var serach = applicantManager.SearchApp(id);

                        if(serach == null)
                        {
                            Console.WriteLine("Not found");
                        }
                        else
                        {
                            Console.WriteLine(serach);
                        }
                        break;

                    case 4:
                        applicantManager.UpdateApp(Console.ReadLine());
                        break;

                    case 5:
                        applicantManager.DeleteApp(Console.ReadLine());
                        break;

                    case 6:
                        Console.WriteLine("Thank You");
                        return;
                    
                    default:
                        Console.WriteLine("Invalid Choice, please select between 1-6");
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}