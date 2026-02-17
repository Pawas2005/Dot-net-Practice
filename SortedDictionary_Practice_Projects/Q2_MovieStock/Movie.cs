using System;
namespace MovieStock;

public class Movie
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public int Ratings { get; set; }

    public Movie() {}

    public Movie(string title, string artist, string genre, int ratings)
    {
        this.Title = title;
        this.Artist = artist;
        this.Genre = genre;
        this.Ratings = ratings;
    }
}