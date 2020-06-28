using MediaCatalogue_API.Models;
using System;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public class ActorRepository: IActorRepository
    {
        public ActorRepository()
        {                
        }

        public List<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }
    }
}
