using System;
using System.Collections.Generic;
using System.Linq;

namespace GymMembershipMgmt;

public class GymManager
{
    private List<Member> members = new List<Member>();
    private List<FitnessClass> fitnessClasses = new List<FitnessClass>();

    private int autoId = 1;

    public void AddMember(string name, string membershipType, int months)
    {
        Member m = new Member(name, membershipType, months);
        m.MemberId = autoId++;
        members.Add(m);

        Console.WriteLine("Member added successfully.\n");
    }

    public void AddClass(string className, string instructor, DateTime schedule, int maxParticipants)
    {
        fitnessClasses.Add(new FitnessClass(
            className, instructor, schedule, maxParticipants));

        Console.WriteLine("Class added successfully.\n");
    }

    // Registers member if class has space
    public bool RegisterForClass(int memberId, string className)
    {
        var member = members.FirstOrDefault(m => m.MemberId == memberId);
        var FitClass = fitnessClasses.FirstOrDefault(f => f.ClassName == className);

        if(member == null || FitClass == null) return false;

        if(FitClass.RegisteredMembers.Count >= FitClass.MaxParticipants)
        {
            Console.WriteLine("Class is full.\n");
            return false;
        }

        FitClass.RegisteredMembers.Add(member.Name);

        Console.WriteLine("Registration successful.\n");
        return true;
    }

    // Groups members by their plan
    public Dictionary<string, List<Member>> GroupMembersByMembershipType()
    {
        return members.GroupBy(m => m.MembershipType)
                        .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Returns classes scheduled for next 7 days
    public List<FitnessClass> GetUpcomingClasses()
    {
        DateTime curr = DateTime.Now;
        DateTime nexWeek = curr.AddDays(7);

        return fitnessClasses
                    .Where(f => f.Schedule >= curr && f.Schedule <= nexWeek)
                    .ToList();
    }

    public void DisplayMembers()
    {
        foreach (var m in members)
        {
            Console.WriteLine($"ID:{m.MemberId} | {m.Name} | {m.MembershipType} | Expiry:{m.ExpiryDate:d}");
        }
        Console.WriteLine();
    }

    public void DisplayClasses()
    {
        foreach (var c in fitnessClasses)
        {
            Console.WriteLine(
                $"{c.ClassName} | {c.Schedule} | Instructor:{c.Instructor} | " +
                $"Seats:{c.RegisteredMembers.Count}/{c.MaxParticipants}");
        }
        Console.WriteLine();
    }
}