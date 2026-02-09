using System;

namespace GymMembershipMgmt;

public class FitnessClass
{
    public string ClassName { get; set; }
    public string Instructor { get; set; }
    public DateTime Schedule { get; set; }
    public int MaxParticipants { get; set; }
    public List<string> RegisteredMembers { get; set; }

    public FitnessClass() {}

    public FitnessClass(string name, string instructor, DateTime schedule, int maxParticipants)
    {
        ClassName = name;
        Instructor = instructor;
        Schedule = schedule;
        MaxParticipants = maxParticipants;
        RegisteredMembers = new List<string>();
    }
}