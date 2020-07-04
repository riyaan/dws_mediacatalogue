using MediaCatalogue_API.DomainServices.Interface;
using MediaCatalogue_API.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MediaCatalogue_API.Controllers
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        private IMovieRepository _movieRepository;

        //public MovieController() { }

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/movie/welcome
        [HttpGet]
        public IEnumerable<string> Welcome()
        {
            return new string[] { "Welcome to the Movie Catalogue" };
        }

        // GET: api/movie/search/Goodfellas
        [Route("search/{query}")]
        [HttpGet]
        public IEnumerable<Movie> Get(string query)
        {
            return _movieRepository.Find(query);
        }

        // POST: api/movie/add/movie
        [Route("add/{movie}")]
        [HttpPost]
        public int Add([FromBody] Movie movie)
        {
            return _movieRepository.Add(movie.Title, movie.Year, movie.Location, movie.Actors, movie.Crew, movie.Genre);
        }

        // DELETE: api/movie/delete/5
        [Route("delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
