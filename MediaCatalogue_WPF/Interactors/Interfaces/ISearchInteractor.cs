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
    }
}
