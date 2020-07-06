using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
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

        public Movie Add(string title, int year, string location, List<Actor> actors, List<Crew> crew, Genre genre)
        {
            Movie movie = _factory.Create(new object[] { title, year, location, actors, crew, genre });

            int movieId = _repositoryWrapper.InsertMovie(movie);

            // TODO: insert actormovie
            foreach (Actor actor in actors)
                _repositoryWrapper.InsertActorMovie(actor.Id, movieId);

            // TODO: insert crewmovie
            foreach (Crew crewMember in crew)
                _repositoryWrapper.InsertCrewMovie(crewMember.Id, movieId);

            return _repositoryWrapper.ReadMovieByID(movieId);
        }

        public List<Movie> Find(string query)
        {
            return _repositoryWrapper.ReadMovieByTitle(query);
        }

        public Movie Edit(int id,  string title, int year, string location, List<Actor> actors, List<Crew> crew, Genre genre)
        {
            Movie movie = _repositoryWrapper.ReadMovieByID(id);

            movie.Title = title;
            movie.Year = year;
            movie.Location = location;
            movie.Actors = actors;
            movie.Crew = crew;
            movie.Genre = genre;
                        
            _repositoryWrapper.UpdateMovie(movie);

            return _repositoryWrapper.ReadMovieByID(id);
        }

        public bool Delete(int movieId)
        {
            return _repositoryWrapper.Delete(_repositoryWrapper.ReadMovieByID(movieId));
        }       
    }
}
