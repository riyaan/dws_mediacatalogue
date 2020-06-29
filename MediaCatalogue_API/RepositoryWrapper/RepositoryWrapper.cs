using System;
using System.Collections.Generic;

namespace MediaCatalogue_API.RepositoryWrapper
{
    public class RepositoryWrapper<TEntity> : IRepositoryWrapper<TEntity> where TEntity : class
    {
        public int Create(TEntity movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entityToDelete)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> ReadAll(string queryString)
        {
            throw new NotImplementedException();
        }

        public TEntity ReadByID(object id)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity movie)
        {
            throw new NotImplementedException();
        }
    }
}