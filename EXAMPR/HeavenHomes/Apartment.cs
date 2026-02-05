using System;
using System.Collections.Generic;

namespace HeavenHomes;

public class Apartment
{
    private Dictionary<String, Double> apartmentDetailsMap = new Dictionary<string, double>();

    public Dictionary<String, Double> ApartmentDetailsMap
    {
        get { return apartmentDetailsMap; }
        set { apartmentDetailsMap = value; }
    }

    public void addApartmentDetails(string apartmentNumber, double rent)
    {
        if (!apartmentDetailsMap.ContainsKey(apartmentNumber))
        {
            apartmentDetailsMap.Add(apartmentNumber, rent);
        }
    }

    public double findTotalRentOfApartmentsInTheGivenRange(double minimumRent, double maximumRent)
    {
        double total = 0;

        foreach(var item in apartmentDetailsMap)
        {
            if(item.Value >= minimumRent && item.Value <= maximumRent)
            {
                total += item.Value;
            }
        }
        return total;
    }
}