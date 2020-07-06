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
    public class ActorInteractor: IActorInteractor
    {
        public ResponseModel<Actor> AddActor(ActorRequestModel requestModel)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            RestRequest request = new RestRequest("AddActor", Method.POST);            

            string json = JsonConvert.SerializeObject(requestModel);

            request.AddJsonBody(json);
            var response = client.Execute(request);

            ResponseModel<Actor> responseModel = new ResponseModel<Actor>();
            responseModel.Data.Add(JsonConvert.DeserializeObject<Actor>(response.Content));

            if (response.IsSuccessful)
                responseModel.Message = response.StatusDescription;
            else
                responseModel.Message = response.ErrorMessage;

            return responseModel;
        }
    }
}
