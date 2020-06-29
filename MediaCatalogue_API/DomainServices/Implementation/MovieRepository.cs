using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using System;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public class MovieRepository: IMovieRepository
    {
        private IRepositoryWrapper<Movie> _repositoryWrapper;
        private IFactory<Movie> _factory;

        public MovieRepository(IRepositoryWrapper<Movie> repositoryWrapper, IFactory<Movie> factory)
        {
            _repositoryWrapper = repositoryWrapper;
            _factory = factory;
        }

        public int Add(string title, string year, List<Actor> actors, List<Crew> crew, Genre genre)
        {
            Movie movie = _factory.Create(new object[] { title, year, actors, crew, genre });
            return _repositoryWrapper.Create(movie);
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
