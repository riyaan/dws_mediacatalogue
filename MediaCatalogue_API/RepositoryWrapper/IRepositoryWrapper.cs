using System.Collections.Generic;

namespace MediaCatalogue_API.RepositoryWrapper
{
    public interface IRepositoryWrapper<TEntity> where TEntity: class
    {
        int Create(TEntity movie);
        List<TEntity> ReadAll(string queryString);
        TEntity ReadByID(object id);
        int Update(TEntity movie);
        void Delete(TEntity entityToDelete);        
    }
}