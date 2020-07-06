using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue_WPF.Interactors.Interfaces
{
    public interface IMovieInteractor
    {
        ResponseModel<Movie> AddMovie(MovieRequestModel request);
        ResponseModel<Movie> UpdateMovie(MovieRequestModel request);
        ResponseModel<Movie> DeleteMovie(MovieRequestModel request);
    }
}
