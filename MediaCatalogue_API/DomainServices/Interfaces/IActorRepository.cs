using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public interface IActorRepository
    {
        List<Movie> GetAllMovies(string actorName);

        Actor Add(string actorName);
        List<Actor> GetAllActors();
        List<Actor> GetActorByName(string actorName);
        Actor GetActorById(int actorId);
        List<Actor> GetActorsByMovie(string movieName);
    }
}
