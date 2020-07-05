using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue_WPF.Interactors
{
    public interface ISearchInteractor
    {
        ResponseModel SearchMovieByTitle(string query);
        ResponseModel SearchMovieByActor(string query);
        ResponseModel SearchMovieByDirector(string query);

        List<Genre> SearchGenre(string query);

    }
}
