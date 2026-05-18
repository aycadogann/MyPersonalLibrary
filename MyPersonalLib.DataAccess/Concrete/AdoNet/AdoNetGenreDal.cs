using MyPersonalLib.DataAccess.Abstract;
using MyPersonalLib.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalLib.DataAccess.Concrete.AdoNet
{
    public class AdoNetGenreDal : IGenreDal
    {
        public List<Genre> GetAll()
        {
            List<Genre> genres = new List<Genre>();
            if (DbConnection.Connection.State == ConnectionState.Closed)
                DbConnection.Connection.Open();

            SqlCommand cmd = new SqlCommand("select * from Genres", DbConnection.Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Genre genre = new Genre() { 
                    ID=Convert.ToInt32(dr["ID"]),
                    BookGenre = dr["BookGenre"].ToString() };
                genres.Add(genre);
            }
            dr.Close();
            DbConnection.Connection.Close();

            return genres;
        }
    }
}
