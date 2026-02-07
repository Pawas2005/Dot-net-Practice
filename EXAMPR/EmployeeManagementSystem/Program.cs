using System;
namespace EmployeeManagementSystem;

public class Program
{
    public static void Main()
    {
        HRManager manager = new HRManager();

        // Add Employees
        manager.AddEmployee("Alice", "HR", 50000);
        manager.AddEmployee("Bob", "IT", 70000);
        manager.AddEmployee("Charlie", "Sales", 45000);
        manager.AddEmployee("David", "IT", 80000);
        manager.AddEmployee("Eva", "HR", 52000);

        // Group By Department
        Console.WriteLine("Employees Grouped By Department:\n");
        var grouped = manager.GroupEmployeesByDepartment();
        foreach(var group in grouped)
        {
            Console.WriteLine($"Department: {group.Key}");
            foreach(var emp in group.Value)
            {
                Console.WriteLine($" {emp}");
            }
            Console.WriteLine();
        }

        // Department Salary
        Console.WriteLine("Enter the department id: ");
        string deptID = Console.ReadLine();

        double totalSalary = manager.CalculateDepartmentSalary(deptID);
        Console.WriteLine($"Total Salary in {deptID} Department = {totalSalary}");

        // Joined After Date
        Console.WriteLine("\nEnter Date (dd-mm-yyyy):");
        DateTime date = DateTime.Parse(Console.ReadLine());

        var recentEmp = manager.GetEmployeesJoinedAfter(date);
        Console.WriteLine("\nEmployees Joined After Given Date:\n");

        foreach(var emp in recentEmp)
        {
            Console.WriteLine(emp);
        }
    }
}