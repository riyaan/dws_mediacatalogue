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

        // POST: api/Movie
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public void Delete(int id)
        {
        }
    }
}
