using System.Collections.Generic;

namespace MediaCatalogue_API.RepositoryWrapper
{
    public interface IRepositoryWrapper<TEntity> where TEntity: class
    {
        int InsertMovie(TEntity entity);
        int InsertGenre(TEntity entity);
        int InsertActor(TEntity entity);
        int InsertCrew(TEntity entity);

        int InsertActorMovie(int actorId, int movieId);
        int InsertCrewMovie(int crewId, int movieId);

        List<TEntity> ReadAll(string queryString);
        List<TEntity> ReadMovieByTitle(string queryString);

        TEntity ReadMovieByID(object id);
        TEntity ReadGenreByID(object id);
        TEntity ReadActorByID(object id);
        TEntity ReadCrewByID(object id);

        List<TEntity> ReadGenreByName(object name);
        List<TEntity> ReadActorByName(object name);
        List<TEntity> ReadCrewByName(object name);

        int UpdateMovie(TEntity entity);


        bool Delete(TEntity entityToDelete);        
    }
}