using MediaCatalogue_API.Factory;
using MediaCatalogue_API.Models;
using MediaCatalogue_API.RepositoryWrapper;
using System;
using System.Collections.Generic;

namespace MediaCatalogue_API.DomainServices.Interface
{
    public class GenreRepository : IGenreRepository
    {
        private IRepositoryWrapper<Genre> _repositoryWrapper;
        private IFactory<Genre> _factory;

        public GenreRepository(IRepositoryWrapper<Genre> repositoryWrapper, IFactory<Genre> factory)
        {
            _repositoryWrapper = repositoryWrapper;
            _factory = factory;
        }

        public Genre Add(string name)
        {
            Genre genre = _factory.Create(new object[] { name });
            int genreId = _repositoryWrapper.InsertGenre(genre);

            return _repositoryWrapper.ReadGenreByID(genreId);
        }

        public List<Genre> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetGenreByName(string name)
        {
            return _repositoryWrapper.ReadGenreByName(name);
        }
    }
}
