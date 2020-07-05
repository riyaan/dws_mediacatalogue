using System.Collections.Generic;

namespace MediaCatalogue_API.RepositoryWrapper
{
    public interface IRepositoryWrapper<TEntity> where TEntity: class
    {
        int InsertMovie(TEntity entity);
        int InsertGenre(TEntity entity);
        List<TEntity> ReadAll(string queryString);
        TEntity ReadByID(object id);
        List<TEntity> ReadGenreByName(object name);
        bool Update(TEntity entity);
        bool Delete(TEntity entityToDelete);        
    }
}