using MediaCatalogue_API.Models;
using System;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public class MovieRepository: IMovieRepository
    {
        public MovieRepository()
        {
        }

        public int Add(string title, string year, List<Actor> actors, List<Crew> _crew, Genre _genre)
        {
            throw new NotImplementedException();
        }

        public bool Edit(string title, string year, List<Actor> actors, List<Crew> _crew, Genre _genre)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
