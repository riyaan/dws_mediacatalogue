using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace MediaCatalogue_WPF.Interactors
{
    public class MovieInteractor : IMovieInteractor
    {
        private ISearchInteractor _searchInteractor;
        private IGenreInteractor _genreInteractor;
        private IActorInteractor _actorInteractor;
        private ICrewInteractor _crewInteractor;

        public MovieInteractor(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor, 
            IActorInteractor actorInteractor, ICrewInteractor crewInteractor)
        {
            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;
            _actorInteractor = actorInteractor;
            _crewInteractor = crewInteractor;
        }

        public ResponseModel<Movie> AddMovie(MovieRequestModel requestModel)
        {
            RestClient client = new RestClient("http://localhost:8000/api/movie");

            // Lookup the Id for the Genre
            // If it does not exist, then create it then get the id
            ResponseModel<Genre> genreResponseModel = new ResponseModel<Genre>();

            ResponseModel<Genre> genreSearchResult = _searchInteractor.SearchGenre(requestModel.Genre);
            if (genreSearchResult.Data.Count.Equals(0))
                genreResponseModel = _genreInteractor.AddGenre(new GenreRequestModel() { Name = requestModel.Genre });
            else
                genreResponseModel = genreSearchResult;


            // Lookup the Actors, if they exist in the database, retrieve them, else create then retrieve them
            ResponseModel<Actor> actorResponseModel = new ResponseModel<Actor>();

            // TODO: Just catering for 1 for now. To add more, edit the movie
            ResponseModel<Actor> actorSearchResult = new ResponseModel<Actor>();

            foreach (string actor in requestModel.Actors)
            {
                actorSearchResult = _searchInteractor.SearchActor(actor);
                if (actorSearchResult.Data.Count.Equals(0))
                    actorResponseModel.Data.Add(_actorInteractor.AddActor(new ActorRequestModel() { Name = actor }).Data.FirstOrDefault());
                else
                    actorResponseModel.Data.Add(actorSearchResult.Data.FirstOrDefault());
            }

            // Lookup the Id for the Director
            // If it does not exist, then create it then get the id
            ResponseModel<Crew> crewResponseModel = new ResponseModel<Crew>();

            ResponseModel<Crew> crewSearchResult = _searchInteractor.SearchCrew(requestModel.Director);
            if (crewSearchResult.Data.Count.Equals(0))
                crewResponseModel = _crewInteractor.AddCrew(new CrewRequestModel() { Name = requestModel.Director });
            else
                crewResponseModel = crewSearchResult;


            RestRequest request = new RestRequest("Add", Method.POST);

            Movie mappedRequest = new Movie()
            {
                  Genre = genreResponseModel.Data.FirstOrDefault(),
                  Actors = actorResponseModel.Data,
                  Crew = crewResponseModel.Data,
                  Title = requestModel.Title,
                  Year = requestModel.Year,
                  Location = requestModel.Location
            };

            string json = JsonConvert.SerializeObject(mappedRequest);

            request.AddJsonBody(json);
            var response = client.Execute(request);

            ResponseModel<Movie> movieResponseModel = new ResponseModel<Movie>();

            if (response.IsSuccessful)
                movieResponseModel.Message = response.StatusDescription;
            else
                movieResponseModel.Message = response.ErrorMessage;

            return movieResponseModel;
        }
    }
}
