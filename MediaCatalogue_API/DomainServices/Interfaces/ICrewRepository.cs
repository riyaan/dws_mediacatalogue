using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public interface ICrewRepository
    {
        Crew Add(string name);
        List<Crew> GetAllCrew();
        List<Crew> GetCrewByName(string name);
        Crew GetCrewById(int crewId);
        List<Crew> GetCrewByMovie(string name);
    }
}
