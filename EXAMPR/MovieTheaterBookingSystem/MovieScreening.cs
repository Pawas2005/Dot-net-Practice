using System;
namespace MovieTheatreBookingSystem;

public class MovieScreening
{
    public string MovieTitle { get; set; }
    public DateTime ShowTime { get; set; }
    public string ScreenNumber { get; set; }
    public int TotalSeats { get; set; }
    public int BookedSeats { get; set; }
    public double TicketPrice { get; set; }

    public MovieScreening(string title, DateTime time, string screen, int seats, double price)
    {
        MovieTitle = title;
        ShowTime = time;
        ScreenNumber = screen;
        TotalSeats = seats;
        TicketPrice = price;
        BookedSeats = 0; //initial 0 bookings
    }

    public int AvailableSeats()
    {
        return TotalSeats - BookedSeats;
    }
}