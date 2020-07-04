using System.Collections.Generic;

namespace MediaCatalogue_API.RepositoryWrapper
{
    public interface IRepositoryWrapper<TEntity> where TEntity: class
    {
        int InsertMovie(TEntity entity);
        List<TEntity> ReadAll(string queryString);
        TEntity ReadByID(object id);
        bool Update(TEntity entity);
        bool Delete(TEntity entityToDelete);        
    }
}