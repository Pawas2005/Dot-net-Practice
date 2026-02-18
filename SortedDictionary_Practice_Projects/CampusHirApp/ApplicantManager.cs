using System;
using System.Linq.Expressions;
namespace CampusHireApplicantManagementSystem;

public class ApplicantManager
{
    private List<Applicant> applicants = new List<Applicant>();

    private void ValidationApp(Applicant a)
    {
        if(String.IsNullOrWhiteSpace(a.ApplicantID) || 
        String.IsNullOrWhiteSpace(a.ApplicantName) ||
        String.IsNullOrWhiteSpace(a.CurrentLocation) ||
        String.IsNullOrWhiteSpace(a.PreferredJobLocation) ||
        String.IsNullOrWhiteSpace(a.CoreCompetency))
        {
            throw new Exception("All Fields are mandatory and cannot be left bank.");
        }    

        if(a.ApplicantID.Length != 8 || !a.ApplicantID.StartsWith("CH"))
            throw new Exception("Invalid Application ID");

        if(a.ApplicantName.Length < 4 || a.ApplicantName.Length > 15)
            throw new Exception("Invalid Application ID");

        if(a.PassingYear > DateTime.Now.Year)
            throw new Exception("Invalid Application ID");
    }

    public void addApplicant(Applicant a)
    {
        ValidationApp(a);
        applicants.Add(a);
        Console.WriteLine("Applicants added Successfully.");
    }

    public void DisplayAll()
    {
        if(applicants.Count == 0)
        {
            Console.WriteLine("No applicants found");
            return;
        }

        foreach(var app in applicants)
        {
            Console.WriteLine(app);
        }
    }

    public Applicant SearchApp(string id)
    {
        return applicants.FirstOrDefault(app => app.ApplicantID == id);
    }

    public void UpdateApp(String id)
    {
        var applicant = SearchApp(id);

        if(applicant == null)
        {
            Console.WriteLine("No Applicant found.");
            return;
        }

        Console.WriteLine("Enter new Name: ");
        applicant.ApplicantName = Console.ReadLine();

        Console.WriteLine("Enter new Preferred Job Location: ");
        applicant.PreferredJobLocation = Console.ReadLine();

        Console.WriteLine("Enter new Core Competency: ");
        applicant.CoreCompetency = Console.ReadLine();

        Console.WriteLine("Appliction details updted successfully.");
    }

    public void DeleteApp(string id)
    {
        var applicant = SearchApp(id);

        if(applicant == null)
        {
            Console.WriteLine("Nothing to delete");
            return;
        }

        applicants.Remove(applicant);
        Console.WriteLine("Deleted Successfully");
    }
}