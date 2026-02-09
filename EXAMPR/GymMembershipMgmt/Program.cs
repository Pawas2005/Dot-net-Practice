using System;
namespace GymMembershipMgmt;

public class Program
{
    public static void Main()
    {
        GymManager gymManager = new GymManager();

        while (true)
        {
            Console.WriteLine("========= Gym Management Menu ========");
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. Add Fitness Class");
            Console.WriteLine("3. Register For Class");
            Console.WriteLine("4. View Members");
            Console.WriteLine("5. View Classes");
            Console.WriteLine("6. Group Members By Type");
            Console.WriteLine("7. Upcoming Classes");
            Console.WriteLine("8. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter MemberShip Type(Basic/Premium/Platinum): ");
                    string membershipType = Console.ReadLine();

                    Console.Write("Months: ");
                    int months = int.Parse(Console.ReadLine());

                    gymManager.AddMember(name, membershipType, months);
                    break;

                case 2:
                    Console.Write("Class Name: ");
                    string cname = Console.ReadLine();

                    Console.Write("Instructor: ");
                    string inst = Console.ReadLine();

                    Console.Write("Schedule (yyyy-MM-dd HH:mm): ");
                    DateTime schedule = DateTime.Parse(Console.ReadLine());

                    Console.Write("Max Participants: ");
                    int max = int.Parse(Console.ReadLine());

                    gymManager.AddClass(cname, inst, schedule, max);
                    break;

                case 3:
                    Console.Write("Member ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Class Name: ");
                    string className = Console.ReadLine();

                    gymManager.RegisterForClass(id, className);
                    break;

                case 4:
                    gymManager.DisplayMembers();
                    break;

                case 5:
                    gymManager.DisplayClasses();
                    break;

                case 6:
                    var grouped = gymManager.GroupMembersByMembershipType();

                    foreach(var group in grouped)
                    {
                        Console.WriteLine($"MemberShip: {group.Key}");
                        foreach(var m in group.Value)
                        {
                            Console.WriteLine($" {m.Name}");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 7:
                    var UpcomingClass = gymManager.GetUpcomingClasses();

                    foreach(var c in UpcomingClass)
                    {
                        Console.WriteLine($"{c.ClassName} | {c.Schedule} | Instructor:{c.Instructor}");
                    }
                    Console.WriteLine();
                    break;

                case 8:
                    return;
            }
        }
    }
}