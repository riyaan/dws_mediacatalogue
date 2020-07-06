using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System;
using MediaCatalogue_WPF.Interactors.Interfaces;

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

            RestRequest request = new RestRequest("Add", Method.POST);
            request.AddJsonBody(json);

            RestClient client = new RestClient("http://localhost:8000/api/movie");
            var response = client.Execute(request);

            ResponseModel<Movie> movieResponseModel = new ResponseModel<Movie>();

            movieResponseModel.StatusCode = response.StatusCode;
            movieResponseModel.Message = response.StatusDescription;          

            return movieResponseModel;
        }

        public ResponseModel<Movie> UpdateMovie(MovieRequestModel request)
        {
            // retrieve the movie
            ResponseModel<Movie> movieSearchResult = _searchInteractor.SearchMovieById(request.UpdateId.MovieId);

            if (movieSearchResult.Data.Count.Equals(0))
                return movieSearchResult;


            Movie mappedRequest = new Movie()
            {
                Id = request.UpdateId.MovieId,
                Title = request.Title,
                Year = request.Year,
                Genre = new Genre() { Id = request.UpdateId.GenreId, Name = request.Genre },
                Crew = new List<Crew>() { new Crew() { Id = request.UpdateId.DirectorId, Name = request.Director } },
                Actors = new List<Actor>(),
                Location = request.Location,
                UpdateId = new MediaCatalogue_API.Models.UpdateId()
                {
                    ActorIds = request.UpdateId.ActorIds,
                    DirectorId = request.UpdateId.DirectorId,
                    GenreId = request.UpdateId.GenreId,
                    MovieId = request.UpdateId.MovieId
                }
            };

            foreach(var actor in request.UpdateId.ActorIds)
            {
                mappedRequest.Actors.Add(new Actor() { Id = actor.Key, Name = actor.Value });
            }

            string json = JsonConvert.SerializeObject(mappedRequest);

            RestRequest restRequest = new RestRequest("Update", Method.POST);
            restRequest.AddJsonBody(json);

            RestClient client = new RestClient("http://localhost:8000/api/movie");
            var response = client.Execute(restRequest);

            ResponseModel<Movie> movieResponseModel = new ResponseModel<Movie>();

            if (response.IsSuccessful)
                movieResponseModel.Message = response.StatusDescription;
            else
                movieResponseModel.Message = response.ErrorMessage;

            return movieResponseModel;
        }

        public ResponseModel<Movie> DeleteMovie(MovieRequestModel request)
        {
            // retrieve the movie
            ResponseModel<Movie> movieSearchResult = _searchInteractor.SearchMovieByTitle(request.Title);

            if (movieSearchResult.Data.Count.Equals(0))
                return movieSearchResult;

            string json = JsonConvert.SerializeObject(movieSearchResult.Data[0].Id);

            RestRequest restRequest = new RestRequest("Delete", Method.POST);
            restRequest.AddJsonBody(json);

            RestClient client = new RestClient("http://localhost:8000/api/movie");
            var response = client.Execute(restRequest);

            ResponseModel<Movie> movieResponseModel = new ResponseModel<Movie>();

            if (response.IsSuccessful)
                movieResponseModel.Message = response.StatusDescription;
            else
                movieResponseModel.Message = response.ErrorMessage;

            return movieResponseModel;
        }
    }
}
