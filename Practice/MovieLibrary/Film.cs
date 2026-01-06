namespace MovieLibrary;

public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }

    public Film(string title, string director, int year)
    {
        this.Title = title;
        this.Director = director;
        this.Year = year;
    }

    public override string ToString()
    {
        return $"{Title} ({Year}) - Directed by {Director}";
    }
}