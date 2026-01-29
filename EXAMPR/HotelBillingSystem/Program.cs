using System;

namespace HotelBillingSystem;

public class Program
{
    public static void Main()
    {
        // -------- Deluxe Room ---------------
        Console.WriteLine("Enter Deluxe Room Details:");
        Console.Write("Guest Name:");
        string dRName = Console.ReadLine();

        Console.Write("Rate per Night:");
        double drate = double.Parse(Console.ReadLine());

        Console.Write("Nights Stayed:");
        int dnightStayed = int.Parse(Console.ReadLine());

        Console.Write("Joining Year:");
        int dyear = int.Parse(Console.ReadLine());

        HotelRoom deluxe = new HotelRoom("Deluxe", drate, dRName);
        int dMembership = deluxe.calculateMembershipYears(dyear);
        double dBill = deluxe.calculateTotalBill(dnightStayed, dyear);

        Console.WriteLine();

        // ----------- Suite Room -------------
        Console.WriteLine("Enter Suite Room Details:");
        Console.Write("Guest Name:");
        string SName = Console.ReadLine();

        Console.Write("Rate per Night:");
        double Srate = double.Parse(Console.ReadLine());

        Console.Write("Nights Stayed:");
        int SnightStayed = int.Parse(Console.ReadLine());

        Console.Write("Joining Year:");
        int Syear = int.Parse(Console.ReadLine());

        HotelRoom suite = new HotelRoom("Suite", Srate, SName);
        int SMembership = suite.calculateMembershipYears(Syear);
        double SBill = suite.calculateTotalBill(SnightStayed, Syear);

        Console.WriteLine();

        // ------- Output ------------
        Console.WriteLine("Room Summary:");
        Console.WriteLine($"Deluxe Room:{dRName}, {drate:F1} per night, Membership:{dMembership} years");
        Console.WriteLine($"Suite Room:{SName}, {Srate:F1} per night, Membership:{SMembership} years");

        Console.WriteLine();

        Console.WriteLine("Total Bill:");
        Console.WriteLine($"For {dRName} (Deluxe):{dBill:F1}");
        Console.WriteLine($"For {SName} (Suite):{SBill:F1}");
    }
}