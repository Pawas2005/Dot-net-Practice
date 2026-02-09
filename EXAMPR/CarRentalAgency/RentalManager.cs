using System;
namespace CarRentalAgency;

public class RentalManager
{
    private List<RentalCar> rentalCars = new List<RentalCar>();
    private List<Rental> rentals = new List<Rental>();
    private int autoID = 1; 

    public void AddCar(string license, string make, string model, string type, double rate)
    {
        rentalCars.Add(new RentalCar(
            license, make, model, type, rate
        ));
    }

    // Creates rental if car available
    public bool RentCar(string license, string customer, DateTime start, int days)
    {
        var car = rentalCars.FirstOrDefault(c => c.LicensePlate == license);

        if(car == null)
        {
            Console.WriteLine("Car not found.\n");
            return false;
        }

        if (!car.IsAvailable)
        {
            Console.WriteLine("Car not available.\n");
            return false;
        }

        DateTime endDate = start.AddDays(days);
        double cost = days * car.DailyRate;

        rentals.Add(new Rental(
            autoID, license, customer, start, endDate, cost
        ));

        car.IsAvailable = false;

        Console.WriteLine("Rental created successfully.");
        return true;
    }

    // Groups available cars by type
    public Dictionary<string, List<RentalCar>> GroupCarsByType()
    {
        var grouped = rentalCars
                        .Where(c => c.IsAvailable)
                        .GroupBy(c => c.CarType)
                        .ToDictionary(g => g.Key, g => g.ToList());

        return new Dictionary<string, List<RentalCar>>(grouped);
    }

    // Returns current rentals
    public List<Rental> GetActiveRentals()
    {
        DateTime today = DateTime.Now;

        return rentals.Where(r => r.EndDate >= today).ToList();
    }

    // Sum of all rental costs
    public double CalculateTotalRentalRevenue()
    {
        return rentals.Sum(r => r.TotalCost);
    }

    public void DisplayCars()
    {
        foreach (var c in rentalCars)
        {
            Console.WriteLine(
                $"{c.LicensePlate} | {c.Make} {c.Model} | {c.CarType} | " + $"Rate:{c.DailyRate} | Available:{c.IsAvailable}");
        }
        Console.WriteLine();
    }
}