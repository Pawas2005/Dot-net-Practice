using System;

namespace MovieTheatreBookingSystem;

public class Program
{
    public static void Main()
    {
        TheatreManager theatreManager = new TheatreManager();

        while (true)
        {
            Console.WriteLine("==== Movie Theater Booking System Menu ====");
            Console.WriteLine("1. Add Screening");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. View All Screenings");
            Console.WriteLine("4. Group By Movie");
            Console.WriteLine("5. Available Screenings");
            Console.WriteLine("6. Total Revenue");
            Console.WriteLine("7. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Movie Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Show Time (yyyy-mm-dd hh:mm): ");
                    DateTime time = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter Screen Number: ");
                    string screen = Console.ReadLine();

                    Console.Write("Enter seats: ");
                    int seats = int.Parse(Console.ReadLine());

                    Console.Write("Enter the Price: ");
                    double price = double.Parse(Console.ReadLine());

                    theatreManager.AddScreaning(title, time, screen, seats, price);
                    break;

                case 2:
                    Console.Write("Enter Movie Title: ");
                    string movieTitle = Console.ReadLine();

                    Console.Write("Show Time (yyyy-mm-dd hh:mm");
                    DateTime showTime = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter the no. of tickets: ");
                    int tickets = int.Parse(Console.ReadLine());

                    theatreManager.BookTickets(movieTitle, showTime, tickets);
                    break;

                case 3:
                    theatreManager.DisplayAll();
                    break;
                
                case 4:
                    var grouped = theatreManager.GroupScreeningsByMovie();
                    foreach(var movie in grouped)
                    {
                        Console.WriteLine($"Movie: {movie.Key}");
                        foreach(var s in movie.Value)
                        {
                            Console.WriteLine($"  {s.ShowTime} | Screen {s.ScreenNumber}");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 5:
                    Console.Write("Enter minimum seats: ");
                    int minSeats = int.Parse(Console.ReadLine());

                    var available = theatreManager.GetAvailableScreenings(minSeats);
                    foreach(var s in available)
                    {
                        Console.WriteLine($"{s.MovieTitle} | {s.ShowTime} | Seats: {s.AvailableSeats()}");
                    }
                    Console.WriteLine();
                    break;

                case 6:
                    double revenue = theatreManager.CalculateTotalRevenue();
                    Console.WriteLine($"Total Revenue: {revenue}\n");
                    break;

                case 7:
                    return;
            }
        }
    }
}