using System.Collections.Generic;

namespace MovieLibrary;

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    bool RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}