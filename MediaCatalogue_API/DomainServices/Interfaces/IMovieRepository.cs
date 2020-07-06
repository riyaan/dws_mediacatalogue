using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public interface IMovieRepository
    {
        Movie Add(string title, int year, string location, List<Actor> actors, List<Crew> _crew, Genre _genre);
        List<Movie> Find(string query);
        Movie GetMovieById(int movieId);
        Movie Edit(Movie movie);
        bool Delete(int movieId);
    }
}
