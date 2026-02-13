using System;

namespace BikeUtil;

public class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        Bike b = new Bike();
        b.Model = model;
        b.Brand = brand;
        b.PricePerDay = pricePerDay;

        Program.bikeDetails.Add(Program.bikeDetails.Count + 1, b);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> result = new SortedDictionary<string, List<Bike>>();

        foreach (Bike b in Program.bikeDetails.Values)
        {
            if (!result.ContainsKey(b.Brand))
                result.Add(b.Brand, new List<Bike>());

            result[b.Brand].Add(b);
        }
        return result;
    }
}