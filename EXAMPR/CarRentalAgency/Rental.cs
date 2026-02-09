using System;
namespace CarRentalAgency;

public class Rental
{
    public int RentalId { get; set; }
    public string LicensePlate { get; set; }
    public string CustomerName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double TotalCost { get; set; }

    public Rental() {}

    public Rental(int id, string licensePlate, string name, DateTime startdate, DateTime endDate, double totalCost)
    {
        this.RentalId = id;
        this.LicensePlate = licensePlate;
        this.CustomerName = name;
        this.StartDate = startdate;
        this.EndDate = endDate;
        this.TotalCost = totalCost;
    }
}