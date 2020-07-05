using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public interface IGenreRepository
    {
        int Add(string name);
        List<Genre> GetAllGenres();
        List<Genre> GetGenreByName(string name);
    }
}
