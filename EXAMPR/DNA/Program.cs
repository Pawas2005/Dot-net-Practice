using System;
using System.Transactions;

namespace DNA;

public class Program
{
    public static void Main()
    {
        ForensicReport report = new ForensicReport();

        Console.WriteLine("Enter number of reports to be added");
        int noOfReports = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the Forensic reports (Reporting Officer:Report Filed Date)");
        for(int i = 0; i < noOfReports; i++)
        {
            string[] input = Console.ReadLine().Split(':');
            report.addReportDetails(input[0], DateTime.Parse(input[1]));
        }

        Console.WriteLine("Enter the filed date to identify the reporting officers");
        DateTime searchDate = DateTime.Parse(Console.ReadLine());

        List<string> result = report.getOfficersWhoFiledReportsOnDate(searchDate);

        if(result.Count == 0)
        {
            Console.WriteLine("No reporting officer filled the report");
        }
        else
        {
            Console.WriteLine($"Reports filled on the {searchDate} are by");
            foreach(string name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
}