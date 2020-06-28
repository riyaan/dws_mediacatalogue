using MediaCatalogue_API.Models;
using System;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public class CrewRepository: ICrewRepository
    {
        public CrewRepository()
        {
        }

        public List<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
