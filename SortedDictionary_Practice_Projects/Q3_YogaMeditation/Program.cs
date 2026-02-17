using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
namespace YogaMeditation;

public class Program
{
    public static ArrayList  memberList = new ArrayList();

    public void AddMember(int memberId, int age, double weight, double height, string goal)
    {
        Meditation m = new Meditation()
        {
            MemberId = memberId,
            Age = age,
            Weight = weight,
            Height = height,
            Goal = goal,
            BMI = 0
        };
        memberList.Add(m);
    }

    public double CalculateBMI(int memberId)
    {
        foreach(Meditation m in memberList)
        {
            if(m.MemberId == memberId)
            {
                double bmi = m.Weight / (m.Height * m.Height);

                bmi = Math.Floor(bmi * 100) / 100;

                m.BMI = bmi;
                return bmi;
            }
        }
        return 0;
    }

    public int CalculateYogaFee(int memberId)
    {
        foreach(Meditation m in memberList)
        {
            if(m.MemberId == memberId)
            {
                if(m.BMI == 0)
                    CalculateBMI(memberId);

                if(m.Goal == "Weight Gain")
                    return 2500;

                if(m.Goal == "Weight Loss")
                {
                    if(m.BMI >= 25 && m.BMI < 30)   return 2000;
                    if(m.BMI >= 30 && m.BMI < 35)   return 2500;
                    if(m.BMI >= 35)   return 3000;
                }
                return 0;
            }
        }
        return 0;
    }

    public static void Main()
    {
        Program p = new Program();

        p.AddMember(101, 26, 78, 68, "Weight Loss");
        p.AddMember(102, 30, 55, 64, "Weight Gain");

        Console.Write("Enter MemberId to calculate BMI: ");
        int id = int.Parse(Console.ReadLine());

        double bmi = p.CalculateBMI(id);
        if(bmi == 0)
        {
            Console.WriteLine($"MemberId '{id}' is not present");
            return;
        }

        Console.WriteLine($"BMI: {bmi}");

        int fee = p.CalculateYogaFee(id);
        Console.WriteLine($"Yoga Fee: {fee}");
    }
}