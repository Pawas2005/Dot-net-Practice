using System;
namespace CarRentalAgency;

public class RentalCar
{
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string CarType { get; set; }
    public bool IsAvailable { get; set; }
    public double DailyRate { get; set; }

    public RentalCar() {}

    public RentalCar(string LicensePlate, string Make, string Model, string CarType, double DailyRate)
    {
        this.LicensePlate = LicensePlate;
        this.Make = Make;
        this.Model =Model;
        this.CarType = CarType;
        this.DailyRate = DailyRate;
        this.IsAvailable = true;
    }
}