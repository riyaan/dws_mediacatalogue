using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MediaCatalogue_API.Controllers
{
    public class MovieController : ApiController
    {
        private IMovieRepository _movieRepository;
        private IGenreRepository _genreRepository;
        private IActorRepository _actorRepository;
        private ICrewRepository _crewRepository;

        public MovieController(IMovieRepository movieRepository, IGenreRepository genreRepository, IActorRepository actorRepository, ICrewRepository crewRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;
            _crewRepository = crewRepository;
        }

        public IEnumerable<string> Welcome()
        {
            return new string[] { "Welcome to the Movie Catalogue" };
        }

        [HttpGet]
        public IEnumerable<Movie> Search(string query)
        {
            return _movieRepository.Find(query);
        }

        [HttpGet]
        public IEnumerable<Genre> SearchGenre(string genreName)
        {
            return _genreRepository.GetGenreByName(genreName);
        }

        [HttpGet]
        public IEnumerable<Actor> SearchActor(string actorName)
        {
            return _actorRepository.GetActorByName(actorName);
        }

        [HttpGet]
        public IEnumerable<Crew> SearchCrew(string crewName)
        {
            return _crewRepository.GetCrewByName(crewName);
        }

        public Movie Add([FromBody] Movie movie)
        {
            if (movie.Genre.Id == 0)
                movie.Genre.Id = _genreRepository.GetGenreByName(movie.Genre.Name).FirstOrDefault().Id;

            return _movieRepository.Add(movie.Title, movie.Year, movie.Location, movie.Actors, movie.Crew, movie.Genre);
        }

        public Movie Update([FromBody] Movie movie)
        {
            return _movieRepository.Edit(movie.Id, movie.Title, movie.Year, movie.Location, movie.Actors, movie.Crew, movie.Genre);
        }

        public Genre AddGenre([FromBody] Genre genre)
        {
            return _genreRepository.Add(genre.Name);
        }

        public Actor AddActor([FromBody] Actor actor)
        {
            return _actorRepository.Add(actor.Name);
        }

        public Crew AddCrew([FromBody] Crew crew)
        {
            return _crewRepository.Add(crew.Name);
        }

        public bool Delete(int id)
        {
            return _movieRepository.Delete(id);
        }
    }
}
