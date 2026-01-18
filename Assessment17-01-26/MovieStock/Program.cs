using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStock
{
    public class Program
    {
        public static List<Movie> MovieList = new List<Movie>();

        //1. Add movie
        public static void AddMovie(string MovieDetails)
        {
            string[] data = MovieDetails.Split(',');

            Movie movie = new Movie();
            movie.Title = data[0].Trim();
            movie.Artist = data[1].Trim();
            movie.Genre = data[2].Trim();
            movie.Ratings = int.Parse(data[3].Trim());

            MovieList.Add(movie);
        }

        //2. View movies by genre
        public static List<Movie> ViewMoviesByGenre(string genre)
        {
            List<Movie> result = new List<Movie>();

            foreach(var movie in MovieList)
            {
                if(movie.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(movie);
                }
            }
            return result;
        }

        // 3. View movies by Ratings (ascending)
        public static List<Movie> ViewMoviesByRatings()
        {
            return MovieList.OrderBy(m => m.Ratings).ToList();
        }

        public static void Main()
        {
            Console.Write("Enter the no. of movies u want to add in Movie Stock App : ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("\nEnter the movie details (Title,Artist,Genre,Rating): ");
                string details = Console.ReadLine();
                AddMovie(details);
            }

            Console.Write("\nEnter the movie to search by genre : ");
            string genre = Console.ReadLine();

            var genreMovies = ViewMoviesByGenre(genre);

            if(genreMovies.Count == 0)
            {
                Console.WriteLine("No movie found in genre " + genre);
            }
            else
            {
                Console.WriteLine("\nMovies in genre " + genre + ":");
                foreach(var m in genreMovies)
                {
                    Console.WriteLine(m);
                }
            }

            Console.WriteLine("\nMovie sorted by rating : ");
            var sortedMovies = ViewMoviesByRatings();
            foreach(var s in sortedMovies)
            {
                Console.WriteLine(s);
            }
        }
    }
}