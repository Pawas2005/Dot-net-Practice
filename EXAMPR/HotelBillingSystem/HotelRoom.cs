using System;

namespace HotelBillingSystem;

public class HotelRoom : Room
{
    private string roomType { get; set; } 
    private double ratePerNight { get; set; }
    private string guestName { get; set; }

    public HotelRoom(string roomType, double ratePerNight, string guestName)
    {
        this.roomType = roomType;
        this.ratePerNight = ratePerNight;
        this.guestName = guestName;
    }

    public int calculateMembershipYears(int joiningYear)
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - joiningYear;
    }

    public double calculateTotalBill(int nightsStayed, int joiningYear)
    {
        double TotalBill = nightsStayed * ratePerNight;

        int memberShipYear = calculateMembershipYears(joiningYear);

        if(memberShipYear > 3)
        {
            TotalBill *= 0.90;
        }

        return Math.Round(TotalBill);
    }
}