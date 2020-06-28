using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public interface ICrewRepository
    {
        List<Movie> GetAllMovies();
        List<Role> GetAllRoles();
    }
}
