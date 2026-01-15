using System;
namespace Meeting;

class Program
{
    public static void Main()
    {
        Employee emp1 = new Employee(101, "Rakesh", 21200);
        Employee emp2 = new Employee(102, "Mahesh", 89200);
        Employee emp3 = new Employee(111, "Mahesh", 89900);

        emp1.Display();
        Console.WriteLine("------------");
        emp2.Display();
        Console.WriteLine("------------");

        Employee[] employees = { emp1, emp2, emp3 };

        int highest = int.MinValue;
        int secHighest = int.MinValue;

        foreach(Employee emp in employees)
        {
            if(emp.ID > highest)
            {
                secHighest = highest;
                highest = emp.ID;
            }else if(emp.ID > secHighest && emp.ID != highest)
            {
                secHighest = emp.ID;
            }
        }
        Console.WriteLine("Second Highest : " + secHighest);
    }
}