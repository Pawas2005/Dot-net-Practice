using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MovieStock;

public class Program
{
    public static List<Movie> movies = new List<Movie>();

    public void AddMMovie(string movieDetails)
    {
        string[] parts = movieDetails.Split(',');

        Movie m = new Movie()
        {
            Title = parts[0],
            Artist = parts[1],
            Genre = parts[2],
            Ratings = int.Parse(parts[3])
        };

        movies.Add(m);
    }

    public List<Movie> ViewMoviesByGenre(string genre)
    {
        return movies.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Movie> ViewMoviesByRatings()
    {
        return movies.OrderBy(k => k.Ratings).ToList();
    }

    public static void Main()
    {
        Program p = new Program();

        Console.WriteLine("Enter the number of movies: ");
        int n = int.Parse(Console.ReadLine());

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter movie details (Title,Artist,Genre,Ratings):");
            p.AddMMovie(Console.ReadLine());
        }

        Console.Write("Enter genre to search: ");
        string genre = Console.ReadLine();

        var byGenre = p.ViewMoviesByGenre(genre);
        if (byGenre.Count == 0)
        {
            Console.WriteLine("No movies found.");
        }
        else
        {
            foreach(var m in byGenre)
            {
                Console.WriteLine($"Details: {m.Title} {m.Artist} {m.Genre} {m.Ratings}");
            }
        }

        Console.WriteLine("Movies sorted by Ratings:");
        var byrating = p.ViewMoviesByRatings();
        foreach (var m in byrating)
            Console.WriteLine($"{m.Title} | {m.Artist} | {m.Genre} | {m.Ratings}");
    }
}