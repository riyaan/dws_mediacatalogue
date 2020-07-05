using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Models;
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
        public List<Genre> SearchGenre(string query)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the Id for the Genre
            // If it does not exist, then create it then get the id

            RestRequest request = new RestRequest("SearchGenre", Method.GET);

            IRestResponse<List<Genre>> response = client.Execute<List<Genre>>(request);

            return response.Data;
        }

        public ResponseModel SearchMovieByActor(string query)
        {
            throw new NotImplementedException();
        }

        public ResponseModel SearchMovieByDirector(string query)
        {
            throw new NotImplementedException();
        }

        public ResponseModel SearchMovieByTitle(string query)
        {
            throw new NotImplementedException();
        }
    }
}
