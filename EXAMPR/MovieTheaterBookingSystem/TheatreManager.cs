using System;

namespace MovieTheatreBookingSystem;

public class TheatreManager
{
    private List<MovieScreening> movieScreenings = new List<MovieScreening>();

    // Adds new screening
    public void AddScreaning(string title, DateTime time, string screen, int seats, double price)
    {
        movieScreenings.Add(new MovieScreening(title, time, screen, seats, price));
        Console.WriteLine("Screening added successfully.\n");
    }

    // Books tickets if available seats
    public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
    {
        var screening = movieScreenings
                        .FirstOrDefault(m => m.MovieTitle == movieTitle
                        && m.ShowTime == showTime);

        if(screening.AvailableSeats() >= tickets)
        {
            screening.BookedSeats += tickets;
            Console.WriteLine("Tickets booked successfully.\n");
            return true;
        }
        else
        {
            Console.WriteLine("Not enough seats available.\n");
            return false;
        }
    }

    // Groups screenings by movie title
    public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
    {
        var screening = movieScreenings.GroupBy(m => m.MovieTitle)
                        .ToDictionary(g => g.Key, g => g.ToList());

        return new Dictionary<string, List<MovieScreening>>(screening);
    }

    // Calculates total revenue from all bookings
    public double CalculateTotalRevenue()
    {
        double total = 0;
        foreach(var item in movieScreenings)
        {
            total += item.BookedSeats * item.TicketPrice;
        }
        return total;
    }

    // Returns screenings with at least minSeats available
    public List<MovieScreening> GetAvailableScreenings(int minSeats)
    {
        return movieScreenings.Where(s => s.AvailableSeats() >= minSeats).ToList();
    }

    // Display all
    public void DisplayAll()
    {
        foreach (var s in movieScreenings)
        {
            Console.WriteLine($"{s.MovieTitle} | {s.ShowTime} | Screen {s.ScreenNumber} | " + $"Available: {s.AvailableSeats()}");
        }
        Console.WriteLine();
    }
}