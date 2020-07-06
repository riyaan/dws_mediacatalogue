using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Models;
using Newtonsoft.Json;
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
        public IEnumerable<Movie> SearchMovieByTitle(string query)
        {
            return _movieRepository.Find(query);
        }        

        

        [HttpGet]
        public IEnumerable<Actor> SearchActorsByMovie(string query)
        {
            return _actorRepository.GetActorsByMovie(query);
        }

        [HttpGet]
        public IEnumerable<Crew> SearchCrewByMovie(string query)
        {
            return _crewRepository.GetCrewByMovie(query);
        }

        [HttpGet]
        public IEnumerable<Crew> SearchCrew(string crewName)
        {
            return _crewRepository.GetCrewByName(crewName);
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
        public Actor SearchActorById(int actorId)
        {
            return _actorRepository.GetActorById(actorId);
        }

        [HttpGet]
        public Crew SearchCrewById(int crewId)
        {
            return _crewRepository.GetCrewById(crewId);
        }

        [HttpGet]
        public Genre SearchGenreById(int genreId)
        {
            return _genreRepository.GetGenreById(genreId);
        }

        [HttpGet]
        public Movie SearchMovieById(int movieId)
        {
            return _movieRepository.GetMovieById(movieId);
        }

        public Movie Add([FromBody] Movie movie)
        {
            List<Genre> genre = _genreRepository.GetGenreByName(movie.Genre.Name);
            movie.Genre = genre.SingleOrDefault();

            string json = JsonConvert.SerializeObject(movie);

            return _movieRepository.Add(movie.Title, movie.Year, movie.Location, movie.Actors, movie.Crew, movie.Genre);
        }

        public Movie Update([FromBody] Movie movie)
        {
            string json = JsonConvert.SerializeObject(movie);

            // get the genre to update
            Genre genre = _genreRepository.GetGenreById(movie.UpdateId.GenreId);
            genre.Name = movie.Genre.Name;

            // get the crew to update
            Crew crew = _crewRepository.GetCrewById(movie.UpdateId.DirectorId);
            crew.Name = movie.Crew[0].Name;

            List<Actor> actors = new List<Actor>();

            // get the actors to update
            foreach(var actor in movie.UpdateId.ActorIds)
            {
                Actor a = _actorRepository.GetActorById(actor.Key);
                actors.Add(new Actor() { Name = actor.Value });
            }

            movie.Genre = genre;
            movie.Crew = new List<Crew>() { crew };
            movie.Actors = actors;

            return _movieRepository.Edit(movie);
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
