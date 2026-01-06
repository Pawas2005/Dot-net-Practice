using System;
namespace MovieLibrary;

class Program
{
    public static void Main()
    {
        IFilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film("Dhurandhar", "Aaditya Dhar", 2025));
        library.AddFilm(new Film("Salaar", "Prashant Neel", 2023));
        library.AddFilm(new Film("Game Of Thrones", "GOT", 2020));
        library.AddFilm(new Film("Bahubali", "Rajamouli", 2020));

        Console.WriteLine("All movies are : ");
        foreach(var film in library.GetFilms())
        {
            Console.WriteLine(film);
        }

        Console.WriteLine("\n Search for 'Salaar' : ");
        foreach(var film in library.SearchFilms("Salaar"))
        {
            Console.WriteLine(film);
        }

        Console.WriteLine("\n Removing 'Game Of Thrones'");
        library.RemoveFilm("Game Of Thrones");

        Console.WriteLine("\n Movies after removal:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine(film);
        }

        Console.WriteLine($"\n Total Movies : {library.GetTotalFilmCount()}");
    }
}