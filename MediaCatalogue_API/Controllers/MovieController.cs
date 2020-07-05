using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MediaCatalogue_API.Controllers
{
    //[RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        private IMovieRepository _movieRepository;
        private IGenreRepository _genreRepository;
        private IActorRepository _actorRepository;
        private ICrewRepository _crewRepository;

        //public MovieController() { }

        public MovieController(IMovieRepository movieRepository, IGenreRepository genreRepository, IActorRepository actorRepository, ICrewRepository crewRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;
            _crewRepository = crewRepository;
        }

        // GET: api/movie/welcome
        [HttpGet]
        public IEnumerable<string> Welcome()
        {
            return new string[] { "Welcome to the Movie Catalogue" };
        }

        // GET: api/movie/search/Goodfellas
        //[Route("search/{query}")]
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

        // POST: api/movie/add/movie
        //[Route("add/{movie}")]
        //[HttpPost]
        public Movie Add([FromBody] Movie movie)
        {
            return _movieRepository.Add(movie.Title, movie.Year, movie.Location, movie.Actors, movie.Crew, movie.Genre);
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

        // DELETE: api/movie/delete/5
        //[Route("delete/{id}")]
        //[HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
