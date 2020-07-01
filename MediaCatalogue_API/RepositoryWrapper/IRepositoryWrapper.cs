using System.Collections.Generic;

namespace MediaCatalogue_API.RepositoryWrapper
{
    public interface IRepositoryWrapper<TEntity> where TEntity: class
    {
        int Create(TEntity movie);
        List<TEntity> ReadAll(string queryString);
        TEntity ReadByID(object id);
        bool Update(TEntity movie);
        bool Delete(TEntity entityToDelete);        
    }
}