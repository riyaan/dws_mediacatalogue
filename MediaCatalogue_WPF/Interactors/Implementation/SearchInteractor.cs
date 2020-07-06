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
            throw new NotImplementedException();
        }
    }
}
