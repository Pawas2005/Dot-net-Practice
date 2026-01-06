using System.Collections.Generic;

namespace MovieLibrary;

public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();

    public void AddFilm(IFilm film)
    {
        _films.Add(film);
    }

    public bool RemoveFilm(string title)
    {
        IFilm film = null;

        foreach(var f in _films)
        {
            if(f.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                film = f;
                break; //stop once found
            }
        }

        if(film != null)
        {
            _films.Remove(film);
            return true;
        }

        return false;
    }

    public List<IFilm> GetFilms()
    {
        return _films;
    }

    public List<IFilm> SearchFilms(string query)
    {
        List<IFilm> result = new List<IFilm>();

        foreach(var film in _films)
        {
            // It checks whether the search word (query) exists inside the film’s Title OR inside the Director’s name, ignoring upper/lower case.
            if(film.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 || 
               film.Director.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                result.Add(film);
            }    
        }

        return result;
    }

    public int GetTotalFilmCount()
    {
        return _films.Count();
    }
}