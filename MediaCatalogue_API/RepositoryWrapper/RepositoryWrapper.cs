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

        public bool Delete(TEntity entityToDelete)
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

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}