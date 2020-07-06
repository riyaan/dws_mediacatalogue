using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public interface IGenreRepository
    {
        Genre Add(string name);
        List<Genre> GetAllGenres();
        List<Genre> GetGenreByName(string name);
        Genre GetGenreById(int genreId);
    }
}
