using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberUtility memberUtility = new MemberUtility();

            while (true)
            {
                Console.WriteLine("=============Library Fine Management System==================");
                Console.WriteLine("1. Display Members by Fine");
                Console.WriteLine("2. Pay Fine");
                Console.WriteLine("3. Add Member");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        memberUtility.DisplayMembers();
                        break;

                    case 2:
                        string id = Console.ReadLine();
                        int amount = int.Parse(Console.ReadLine());

                        memberUtility.PayFine(id, amount);
                        break;

                    case 3:
                        string[] inp = Console.ReadLine().Split(' ');
                        Member member = new Member()
                        {
                            MemberId = inp[0],
                            Name = inp[1],
                            FineAmount = int.Parse(inp[2])
                        };

                        memberUtility.AddMember(member);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice. Please choose betwee");
                        break;
                }
            }
        }
    }
}
