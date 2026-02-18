using System;
namespace CampusHireApplicantManagementSystem;

public class Applicant
{
    public string ApplicantID { get; set; }
    public string ApplicantName { get; set; }
    public string CurrentLocation { get; set; }
    public string PreferredJobLocation { get; set; }
    public string CoreCompetency { get; set; }
    public int PassingYear { get; set; }

    public Applicant() {}

    public Applicant(string id, string name, string currloc, string prefjobloc, string core, int pass)
    {
        ApplicantID = id;
        ApplicantName = name;
        CurrentLocation = currloc;
        PreferredJobLocation = prefjobloc;
        CoreCompetency = core;
        PassingYear = pass;
    }

    public override string ToString()
    {
        return $"ID: {ApplicantID}\n" +
               $"Name: {ApplicantName}\n" +
               $"Current Location: {CurrentLocation}\n" +
               $"Preferred Location: {PreferredJobLocation}\n" +
               $"Core Competency: {CoreCompetency}\n" +
               $"Passing Year: {PassingYear}\n";
    }
}