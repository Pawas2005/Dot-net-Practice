using System;
using System.Security.Cryptography.X509Certificates;

namespace Meeting;

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public float Salary { get; set; }

    //parameterized constructor
    public Employee(int ID, string Name, float Salary)
    {
        this.ID = ID;
        this.Name = Name;
        this.Salary = Salary;
    }

    public void Display()
    {
        Console.WriteLine("Employee ID : " + ID);
        Console.WriteLine("Employee Name : " + Name);
        Console.WriteLine("Employee Salary : " + Salary);
    }
}