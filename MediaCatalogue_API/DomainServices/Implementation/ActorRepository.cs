using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using System;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public class ActorRepository: IActorRepository
    {
        private IRepositoryWrapper<Actor> _repositoryWrapper;
        private IFactory<Actor> _factory;

        public ActorRepository(IRepositoryWrapper<Actor> repositoryWrapper, IFactory<Actor> factory)
        {
            _repositoryWrapper = repositoryWrapper;
            _factory = factory;
        }

        public Actor Add(string actorName)
        {
            Actor actor = _factory.Create(new object[] { actorName });
            int actorId = _repositoryWrapper.InsertActor(actor);

            return _repositoryWrapper.ReadActorByID(actorId);
        }

        public List<Actor> GetActorByName(string actorName)
        {
            return _repositoryWrapper.ReadActorByName(actorName);
        }

        public List<Actor> GetAllActors()
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAllMovies(string actorName)
        {
            throw new NotImplementedException();
        }

        public List<Actor> GetActorsByMovie(string movieName)
        {
            return _repositoryWrapper.ReadActorsByMovie(movieName);
        }

        public Actor GetActorById(int actorId)
        {
            return _repositoryWrapper.ReadActorByID(actorId);
        }        
    }
}
