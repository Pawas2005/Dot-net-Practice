using System;
using System.Linq;

namespace EmployeeManagementSystem;

public class HRManager
{
    private List<Employee> employees = new List<Employee>();
    private int counter = 1; //for auto-generte 

    public void AddEmployee(string name, string dept, double salary)
    {
        employees.Add(new Employee
        {
           EmployeeId = counter++, 
           Name = name,
           Department = dept,
           Salary = salary,
           JoiningDate = DateTime.Now
        });
    }

    // SortedDictionary<string, List<Employee>>
    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        // SortedDictionary<string, List<Employee>> grouped = new SortedDictionary<string, List<Employee>>();

        // foreach(var emp in employees)
        // {
        //     if (!grouped.ContainsKey(emp.Department))
        //     {
        //         grouped[emp.Department] = new List<Employee>();
        //     }
        //     grouped[emp.Department].Add(emp);
        // }
        // return grouped;
        var grouped = employees.GroupBy(e => e.Department)
                        .ToDictionary(g => g.Key, g => g.ToList());

        return new SortedDictionary<string, List<Employee>>(grouped);
    }

    // Returns total salary of a department
    public double CalculateDepartmentSalary(string department)
    {
        return employees.Where(e => e.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
                .Sum(e => e.Salary);
    }

    // Returns employees joined after specific date
    public List<Employee> GetEmployeesJoinedAfter(DateTime date)
    {
        return employees.Where(e => e.JoiningDate > date).ToList();
    }
}