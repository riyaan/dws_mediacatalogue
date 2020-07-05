using MediaCatalogue_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalogue_WPF.Interactors
{
    public interface IGenreInteractor
    {
        ResponseModel AddGenre(GenreRequestModel request);
    }
}
