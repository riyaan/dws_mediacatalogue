using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using System;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public class CrewRepository: ICrewRepository
    {
        private IRepositoryWrapper<Crew> _repositoryWrapper;
        private IFactory<Crew> _factory;


        public CrewRepository(IRepositoryWrapper<Crew> repositoryWrapper, IFactory<Crew> factory)
        {
            _repositoryWrapper = repositoryWrapper;
            _factory = factory;
        }

        public Crew Add(string name)
        {
            Crew crew = _factory.Create(new object[] { name });
            int crewId = _repositoryWrapper.InsertCrew(crew);

            return _repositoryWrapper.ReadCrewByID(crewId);
        }

        public List<Crew> GetAllCrew()
        {
            throw new NotImplementedException();
        }

        public List<Crew> GetCrewByName(string name)
        {
            return _repositoryWrapper.ReadCrewByName(name);
        }
    }
}
