using System;
namespace EmployeeManagementSystem;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
    public DateTime JoiningDate { get; set; }

    public override string ToString()
    {
        //Generate Employee ID → E001, E002...
        return $"EmployeeID: E{EmployeeId:D3}, Name: {Name}, Department: {Department}, Salary: {Salary}, Joining Date: {JoiningDate}";
    }
}