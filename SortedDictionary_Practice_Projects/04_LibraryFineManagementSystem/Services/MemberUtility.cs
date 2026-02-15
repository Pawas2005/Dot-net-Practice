using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Services
{
    public class MemberUtility
    {
        private SortedDictionary<int, List<Member>> members = new SortedDictionary<int, List<Member>>();

        public void AddMember(Member member)
        {
            if(member.FineAmount < 0)
            {
                throw new Exceptions.InvalidFineException("Invalid Fine Amount");
            }

            if (!members.ContainsKey(member.FineAmount))
            {
                members[member.FineAmount] = new List<Member>();
            }
            members[member.FineAmount].Add(member);
            Console.WriteLine("Member added Successfully.");
        }

        public void DisplayMembers()
        {
            if(members.Count == 0)
            {
                throw new Exceptions.MemberNotFoundException("Member Not Found");
            }

            foreach(var fine in members.Keys)
            {
                foreach(var m in members[fine])
                {
                    Console.WriteLine($"Details: {m.MemberId} {m.Name} {m.FineAmount}");
                }
            }
        }

        public void PayFine(string id, int amount)
        {
            if (amount <= 0)
                throw new InvalidFineException("Invalid Fine Payment");

            foreach(var fineKey in members.Keys.ToList())
            {
                var fine = members[fineKey].FirstOrDefault(m => m.MemberId == id);

                if(fine != null)
                {
                    if(amount > fine.FineAmount)
                    {
                        throw new InvalidFineException("Payment exceeds fine amount");
                    }

                    members[fineKey].Remove(fine);

                    if(members[fineKey].Count == 0)
                    {
                        members.Remove(fineKey);
                    }

                    fine.FineAmount -= amount;

                    if (!members.ContainsKey(fine.FineAmount))
                    {
                        members[fine.FineAmount] = new List<Member>();
                    }
                    members[fine.FineAmount].Add(fine);

                    Console.WriteLine("Fine Paid Successfully.");
                    return;
                }
            }
            throw new Exceptions.MemberNotFoundException("Member Not Found");
        }
    }
}