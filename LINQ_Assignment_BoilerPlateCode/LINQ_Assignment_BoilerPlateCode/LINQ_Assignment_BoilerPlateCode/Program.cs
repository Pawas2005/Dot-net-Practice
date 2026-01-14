
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Assignment_BoilerPlateCode.Repos;
using LINQ_Assignment_BoilerPlateCode.DTOs;
using LINQ_Assignment_BoilerPlateCode.Models;

namespace LINQ_Assignment_BoilerPlateCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // =======================
            // SAMPLE DATA
            // =======================
            var employees = EmployeeRepo.SeedEmployees();
            var projects = ProjectRepo. SeedProjects();

            Console.WriteLine("LINQ Scenario Boilerplate Loaded");

            Console.WriteLine("TODO 1.1");
            GetHighEarningEmployees(employees);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("TODO 1.2");
            GetEmployeeNames(employees);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("TODO 1.3");
            bool res = HasHREmployees(employees);
            Console.WriteLine(res);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("TODO 2.1");
            GetDepartmentWiseCount(employees);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("TODO 2.2");
            GetHighestPaidEmployee(employees);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("TODO 2.3");
            SortEmployeesBySalaryAndName(employees);
            Console.WriteLine("---------------------------------------------");


            Console.ReadLine();
        }

        // =====================================================
        // 🟢 SECTION 1 – HR ANALYTICS
        // =====================================================

        // TODO 1.1: Get employees earning more than 60,000
        static List<Employee> GetHighEarningEmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            
            List<Employee> highEarningEmoployees = employees.Where(e => e.Salary > 60000).ToList();
            
            foreach(var emp in highEarningEmoployees)
            {
                Console.WriteLine(emp);
            }

            return highEarningEmoployees;
        }

        // TODO 1.2: Get list of employee names only
        static List<string> GetEmployeeNames(List<Employee> employees)
        {
            // TODO: Write LINQ query here

            List<string> employeeName = employees.Select(e => e.Name).ToList();

            foreach (var emp in employeeName)
            {
                Console.WriteLine(emp.ToString());
            }

            return employeeName;
        }

        // TODO 1.3: Check if any employee belongs to HR department
        static bool HasHREmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            bool HREmployee = employees.Any(e => e.Department == "HR");

            return HREmployee;
        }

        // =====================================================
        // 🟡 SECTION 2 – MANAGEMENT INSIGHTS
        // =====================================================

        // TODO 2.1: Get department-wise employee count
        static List<DepartmentCount> GetDepartmentWiseCount(List<Employee> employees)
        {
            // TODO: Write LINQ query here

            var result = employees.GroupBy(e => e.Department).Select(grp => new DepartmentCount
            {
                Department = grp.Key,
                Count = grp.Count()
            }).ToList();

            foreach(var emp in result)
            {
                Console.WriteLine($"{emp.Department} {emp.Count}");
            }

            return result;
        }

        // TODO 2.2: Find the highest paid employee
        static Employee GetHighestPaidEmployee(List<Employee> employees)
        {
            // TODO: Write LINQ query here

            Employee highestPaidEmployee = employees.OrderByDescending(e => e.Salary).FirstOrDefault();
            Console.WriteLine("Highest Paid Employee : " + highestPaidEmployee);

            return highestPaidEmployee;
        }

        // TODO 2.3: Sort employees by Salary (DESC), then Name (ASC)
        static List<Employee> SortEmployeesBySalaryAndName(List<Employee> employees)
        {
            // TODO: Write LINQ query here

            List<Employee> sortedEmployeesBySalaryAndName = employees.OrderByDescending(e => e.Salary).ThenBy(e => e.Name).ToList();

            foreach(var emp in sortedEmployeesBySalaryAndName)
            {
                Console.WriteLine(emp);
            }

            return sortedEmployeesBySalaryAndName;
        }

        // =====================================================
        // 🔵 SECTION 3 – PROJECT & SKILL INTELLIGENCE
        // =====================================================

        // TODO 3.1: Join employees with projects
        static List<EmployeeProject> GetEmployeeProjectMappings(
            List<Employee> employees,
            List<Project> projects)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 3.2: Find employees who are NOT assigned to any project
        static List<Employee> GetUnassignedEmployees(
            List<Employee> employees,
            List<Project> projects)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 3.3: Get all unique skills across the organization
        static List<string> GetAllUniqueSkills(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // =====================================================
        // 🔴 SECTION 4 – ADVANCED WORKFORCE ANALYTICS
        // =====================================================

        // TODO 4.1: Get top 3 highest-paid employees per department
        static List<DepartmentTopEmployees> GetTopEarnersByDepartment(
            List<Employee> employees)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 4.2: Remove duplicate employees based on Id
        static List<Employee> RemoveDuplicateEmployees(List<Employee> employees)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }

        // TODO 4.3: Implement pagination
        static List<Employee> GetEmployeesByPage(
            List<Employee> employees,
            int pageNumber,
            int pageSize = 5)
        {
            // TODO: Write LINQ query here
            throw new NotImplementedException();
        }


    }
}
