using System;
using System.ComponentModel;

namespace HotelBillingSystem;

public interface Room
{
    double calculateTotalBill(int nightsStayed, int joiningYear);
    int calculateMembershipYears(int joiningYear);
}