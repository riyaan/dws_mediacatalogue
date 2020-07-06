using MediaCatalogue_API.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MediaCatalogue_API.RepositoryWrapper
{
    public class RepositoryWrapper<TEntity> : IRepositoryWrapper<TEntity> where TEntity : class
    {

        string connectionString = "Data Source=(local);Initial Catalog=MovieCatalogue;Integrated Security=true";

        public int InsertMovie(TEntity entity)
        {
            // TODO: Relook at this
            //Type objType = typeof(TEntity);
            //Movie item = (Movie)Activator.CreateInstance(objType);

            Movie item = entity as Movie;

            SqlParameter titleParam = new SqlParameter("@title", SqlDbType.VarChar);
            titleParam.Value = item.Title;

            SqlParameter yearParam = new SqlParameter("@year", SqlDbType.Int);
            yearParam.Value = item.Year;

            SqlParameter locationParam = new SqlParameter("@location", SqlDbType.VarChar);
            locationParam.Value = item.Location;

            SqlParameter genreParam = new SqlParameter("@genre", SqlDbType.Int);
            genreParam.Value = item.Genre.Id;

            SqlParameter[] parameters = { titleParam, yearParam, locationParam, genreParam };

            return Insert(parameters, "usp_InsertMovie");
        }

        public int InsertGenre(TEntity entity)
        {
            Genre item = entity as Genre;

            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar);
            nameParam.Value = item.Name;

            SqlParameter[] parameters = { nameParam };

            return Insert(parameters, "usp_InsertGenre");
        }

        public int InsertActor(TEntity entity)
        {
            Actor item = entity as Actor;

            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar);
            nameParam.Value = item.Name;

            SqlParameter[] parameters = { nameParam };

            return Insert(parameters, "usp_InsertActor");
        }

        public int InsertCrew(TEntity entity)
        {
            Crew item = entity as Crew;

            SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar);
            nameParam.Value = item.Name;

            SqlParameter[] parameters = { nameParam };

            return Insert(parameters, "usp_InsertCrew");
        }

        public int InsertActorMovie(int actorId, int movieId)
        {
            SqlParameter actorIdParam = new SqlParameter("@actorId", SqlDbType.Int);
            actorIdParam.Value = actorId;

            SqlParameter movieIdParam = new SqlParameter("@movieId", SqlDbType.Int);
            movieIdParam.Value = movieId;

            SqlParameter[] parameters = { actorIdParam, movieIdParam };

            return Insert(parameters, "usp_InsertActorMovie");
        }

        public int InsertCrewMovie(int crewId, int movieId)
        {
            SqlParameter crewIdParam = new SqlParameter("@crewId", SqlDbType.Int);
            crewIdParam.Value = crewId;

            SqlParameter movieIdParam = new SqlParameter("@movieId", SqlDbType.Int);
            movieIdParam.Value = movieId;

            SqlParameter[] parameters = { crewIdParam, movieIdParam };

            return Insert(parameters, "usp_InsertCrewMovie");
        }

        private int Insert(SqlParameter[] parameters, string storedProc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = connection,
                    CommandText = storedProc,
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddRange(parameters);

                connection.Open();

                return (int)command.ExecuteScalar();                
            }
        }

        public bool Delete(TEntity entity)
        {
            Movie movie = entity as Movie;

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = Convert.ToInt32(movie.Id);

            SqlParameter[] parameters = { idParam };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = connection,
                    CommandText = "usp_DeleteMovie",
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddRange(parameters);

                connection.Open();

                bool success = false;

                int result = (int)command.ExecuteScalar();

                if(result > 0) success = true;

                return success;
            }
        }

        public List<TEntity> ReadAll(string queryString)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> ReadGenreByName(object name)
        {
            SqlParameter titleParam = new SqlParameter("@query", SqlDbType.VarChar);
            titleParam.Value = name.ToString();

            SqlParameter[] parameters = { titleParam };

            DataSet ds = Reader(parameters, "usp_SearchGenreByName");
            DataTable dt = ds.Tables[0];
            
            List<Genre> genre = new List<Genre>();

            foreach(DataRow drc in dt.Rows)
            {
                genre.Add(new Genre() { Id = Convert.ToInt32(drc[0]), Name = drc[1].ToString() });
            }

            return genre as List<TEntity>;
        }

        public List<TEntity> ReadActorByName(object name)
        {
            SqlParameter titleParam = new SqlParameter("@query", SqlDbType.VarChar);
            titleParam.Value = name.ToString();

            SqlParameter[] parameters = { titleParam };

            DataSet ds = Reader(parameters, "usp_SearchActorByName");
            DataTable dt = ds.Tables[0];

            List<Actor> actor = new List<Actor>();

            foreach (DataRow drc in dt.Rows)
            {
                actor.Add(new Actor() { Id = Convert.ToInt32(drc[0]), Name = drc[1].ToString() });
            }

            return actor as List<TEntity>;
        }

        public List<TEntity> ReadCrewByName(object name)
        {
            SqlParameter titleParam = new SqlParameter("@query", SqlDbType.VarChar);
            titleParam.Value = name.ToString();

            SqlParameter[] parameters = { titleParam };

            DataSet ds = Reader(parameters, "usp_SearchCrewByName");
            DataTable dt = ds.Tables[0];

            List<Crew> crew = new List<Crew>();

            foreach (DataRow drc in dt.Rows)
            {
                crew.Add(new Crew() { Id = Convert.ToInt32(drc[0]), Name = drc[1].ToString(), Role = new Role() { Id = 1, Name = "Director" } });
            }

            return crew as List<TEntity>;
        }

        private DataSet Reader(SqlParameter[] parameters, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))                
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = connection,
                    CommandText = storedProcedure,
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddRange(parameters);

                using (var da = new SqlDataAdapter(command))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public int UpdateMovie(TEntity entity)
        {
            Movie movie = entity as Movie;

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = Convert.ToInt32(movie.Id);

            SqlParameter titleParam = new SqlParameter("@title", SqlDbType.VarChar);
            titleParam.Value = movie.Title;

            SqlParameter yearParam = new SqlParameter("@year", SqlDbType.Int);
            yearParam.Value = Convert.ToInt32(movie.Year);

            SqlParameter locationParam = new SqlParameter("@location", SqlDbType.VarChar);
            locationParam.Value = movie.Location;

            SqlParameter genreParam = new SqlParameter("@genre", SqlDbType.Int);
            genreParam.Value = Convert.ToInt32(movie.Genre.Id);

            SqlParameter[] parameters = { idParam, titleParam, yearParam, locationParam, genreParam };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = connection,
                    CommandText = "usp_UpdateMovie",
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddRange(parameters);

                connection.Open();

                return (int)command.ExecuteScalar();
            }
        }

        public TEntity ReadGenreByID(object id)
        {
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = Convert.ToInt32(id);

            SqlParameter[] parameters = { idParam };

            DataSet ds = Reader(parameters, "usp_SearchGenreById");
            DataTable dt = ds.Tables[0];

            Genre genre = new Genre();

            foreach (DataRow drc in dt.Rows)
            {
                genre.Id = Convert.ToInt32(drc[0]);
                genre.Name = drc[1].ToString();
            }

            return genre as TEntity;
        }

        public TEntity ReadActorByID(object id)
        {
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = Convert.ToInt32(id);

            SqlParameter[] parameters = { idParam };

            DataSet ds = Reader(parameters, "usp_SearchActorById");
            DataTable dt = ds.Tables[0];

            Actor actor = new Actor();

            foreach (DataRow drc in dt.Rows)
            {
                actor.Id = Convert.ToInt32(drc[0]);
                actor.Name = drc[1].ToString();
            }

            return actor as TEntity;
        }

        public TEntity ReadMovieByID(object id)
        {
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = Convert.ToInt32(id);

            SqlParameter[] parameters = { idParam };

            DataSet ds = Reader(parameters, "usp_SearchMovieById");
            DataTable dt = ds.Tables[0];

            Movie movie = new Movie();

            foreach (DataRow drc in dt.Rows)
            {
                movie.Id = Convert.ToInt32(drc[0]);
                movie.Title = drc[1].ToString();
                movie.Year = Convert.ToInt32(drc[2]);
                movie.Location = drc[3].ToString();
                movie.Genre = ReadGenreByID(drc[5]) as Genre;
            }

            return movie as TEntity;
        }


        public TEntity ReadCrewByID(object id)
        {
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = Convert.ToInt32(id);

            SqlParameter[] parameters = { idParam };

            DataSet ds = Reader(parameters, "usp_SearchCrewById");
            DataTable dt = ds.Tables[0];

            Crew crew = new Crew();

            foreach (DataRow drc in dt.Rows)
            {
                crew.Id = Convert.ToInt32(drc[0]);
                crew.Name = drc[1].ToString();
                crew.Role = new Role() { Id = 1, Name = "Director" }; // TODO: Hardcoding for now
            }

            return crew as TEntity;
        }        
    }
}