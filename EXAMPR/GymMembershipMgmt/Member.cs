using System;
namespace GymMembershipMgmt;

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string MembershipType { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    public Member() {}

    public Member(string name, string type, int months)
    {
        Name = name;
        MembershipType = type;
        JoinDate = DateTime.Now;
        ExpiryDate = JoinDate.AddMonths(months);
    }
}