using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue_WPF.Interactors.Interfaces
{
    public interface ISearchInteractor
    {
        ResponseModel<Movie> SearchMovieByTitle(string query);
        ResponseModel<Movie> SearchMovieByActor(string query);
        ResponseModel<Movie> SearchMovieByDirector(string query);

        ResponseModel<Genre> SearchGenre(string query);
        ResponseModel<Actor> SearchActor(string query);        

        ResponseModel<Crew> SearchCrew(string query);

        ResponseModel<Genre> SearchGenreById(int genreId);
        ResponseModel<Actor> SearchActorById(int actorId);

        ResponseModel<Crew> SearchCrewById(int crewId);
        ResponseModel<Movie> SearchMovieById(int movieId);



        ResponseModel<Actor> SearchActorsByMovie(string query);
        ResponseModel<Crew> SearchCrewByMovie(string query);
    }
}
