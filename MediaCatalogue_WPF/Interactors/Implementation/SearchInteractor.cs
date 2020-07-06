using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Interactors.Interfaces;
using MediaCatalogue_WPF.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue_WPF.Interactors
{
    public class SearchInteractor : ISearchInteractor
    {
        public ResponseModel<Genre> SearchGenre(string query)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the Id for the Genre
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchGenre", Method.GET);
            request.AddParameter("genreName", query);

            IRestResponse<ResponseModel<Genre>> response = client.Execute<ResponseModel<Genre>>(request);

            ResponseModel<Genre> result = new ResponseModel<Genre>();
            result.Data = JsonConvert.DeserializeObject<List<Genre>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Actor> SearchActor(string query)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchActor", Method.GET);
            request.AddParameter("actorName", query);

            IRestResponse<ResponseModel<Actor>> response = client.Execute<ResponseModel<Actor>>(request);

            ResponseModel<Actor> result = new ResponseModel<Actor>();
            result.Data = JsonConvert.DeserializeObject<List<Actor>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Crew> SearchCrew(string query)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchCrew", Method.GET);
            request.AddParameter("crewName", query);

            IRestResponse<ResponseModel<Actor>> response = client.Execute<ResponseModel<Actor>>(request);

            ResponseModel<Crew> result = new ResponseModel<Crew>();
            result.Data = JsonConvert.DeserializeObject<List<Crew>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Movie> SearchMovieByActor(string query)
        {
            throw new NotImplementedException();
        }

        public ResponseModel<Movie> SearchMovieByDirector(string query)
        {
            throw new NotImplementedException();
        }

        public ResponseModel<Movie> SearchMovieByTitle(string query)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchMovieByTitle", Method.GET);
            request.AddParameter("query", query);

            IRestResponse<ResponseModel<List<Movie>>> response = client.Execute<ResponseModel<List<Movie>>>(request);

            ResponseModel<Movie> result = new ResponseModel<Movie>();
            result.Data = JsonConvert.DeserializeObject<List<Movie>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Actor> SearchActorsByMovie(string query)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchActorsByMovie", Method.GET);
            request.AddParameter("query", query);

            IRestResponse<ResponseModel<List<Actor>>> response = client.Execute<ResponseModel<List<Actor>>>(request);

            ResponseModel<Actor> result = new ResponseModel<Actor>();
            result.Data = JsonConvert.DeserializeObject<List<Actor>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Crew> SearchCrewByMovie(string query)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchCrewByMovie", Method.GET);
            request.AddParameter("query", query);

            IRestResponse<ResponseModel<List<Crew>>> response = client.Execute<ResponseModel<List<Crew>>>(request);

            ResponseModel<Crew> result = new ResponseModel<Crew>();
            result.Data = JsonConvert.DeserializeObject<List<Crew>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Genre> SearchGenreById(int genreId)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchGenreById", Method.GET);
            request.AddParameter("genreId", genreId);

            IRestResponse<ResponseModel<Genre>> response = client.Execute<ResponseModel<Genre>>(request);

            ResponseModel<Genre> result = new ResponseModel<Genre>();
            result.Data = JsonConvert.DeserializeObject<List<Genre>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Actor> SearchActorById(int actorId)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchActorById", Method.GET);
            request.AddParameter("actorId", actorId);

            IRestResponse<ResponseModel<Actor>> response = client.Execute<ResponseModel<Actor>>(request);

            ResponseModel<Actor> result = new ResponseModel<Actor>();
            result.Data = JsonConvert.DeserializeObject<List<Actor>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Crew> SearchCrewById(int crewId)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchCrewById", Method.GET);
            request.AddParameter("crewId", crewId);

            IRestResponse<ResponseModel<Crew>> response = client.Execute<ResponseModel<Crew>>(request);

            ResponseModel<Crew> result = new ResponseModel<Crew>();
            result.Data = JsonConvert.DeserializeObject<List<Crew>>(response.Content);
            result.Message = response.StatusCode.ToString();

            return result;
        }

        public ResponseModel<Movie> SearchMovieById(int movieId)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the actor
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchMovieById", Method.GET);
            request.AddParameter("movieId", movieId);

            IRestResponse<ResponseModel<Movie>> response = client.Execute<ResponseModel<Movie>>(request);

            ResponseModel<Movie> result = new ResponseModel<Movie>();
            result.Data.Add(JsonConvert.DeserializeObject<Movie>(response.Content));
            result.Message = response.StatusCode.ToString();

            return result;
        }
    }
}
