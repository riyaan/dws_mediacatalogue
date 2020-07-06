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
    public class GenreInteractor: IGenreInteractor
    {
        public ResponseModel<Genre> AddGenre(GenreRequestModel requestModel)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            RestRequest request = new RestRequest("AddGenre", Method.POST);            

            string json = JsonConvert.SerializeObject(requestModel);

            request.AddJsonBody(json);
            var response = client.Execute(request);

            ResponseModel<Genre> responseModel = new ResponseModel<Genre>();
            responseModel.Data.Add(JsonConvert.DeserializeObject<Genre>(response.Content));

            if (response.IsSuccessful)
                responseModel.Message = response.StatusDescription;
            else
                responseModel.Message = response.ErrorMessage;

            return responseModel;
        }
    }
}
