using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public interface IMovieRepository
    {
        int Add(string title, string year, List<Actor> actors, List<Crew> _crew, Genre _genre);
        bool Edit(string title, string year, List<Actor> actors, List<Crew> _crew, Genre _genre);
        bool Delete(int movieId);
    }
}
