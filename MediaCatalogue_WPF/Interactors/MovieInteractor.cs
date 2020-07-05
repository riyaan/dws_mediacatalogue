using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace MediaCatalogue_WPF.Interactors
{
    public class MovieInteractor: IMovieInteractor
    {
        private ISearchInteractor _searchInteractor;
        private IGenreInteractor _genreInteractor;

        public MovieInteractor(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor)
        {
            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;
        }

        public ResponseModel AddMovie(MovieRequestModel requestModel)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the Id for the Genre
            // If it does not exist, then create it then get the id
            List<Genre> genreList = _searchInteractor.SearchGenre(requestModel.Genre);
            if (genreList.Count.Equals(0))
            {
                _genreInteractor.AddGenre(new GenreRequestModel() { Name = requestModel.Genre });
            }

            RestRequest request = new RestRequest("Add", Method.POST);            

            string json = JsonConvert.SerializeObject(requestModel);

            request.AddJsonBody(json);
            var response = client.Execute(request);

            ResponseModel responseModel = new ResponseModel();

            if (response.IsSuccessful)
                responseModel.Message = response.StatusDescription;
            else
                responseModel.Message = response.ErrorMessage;

            return responseModel;
        }
    }
}
