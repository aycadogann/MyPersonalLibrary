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
    public class AdoNetBookDal : IBookDal
    {
        public void Add(Book book)
        {
            if (DbConnection.Connection.State == ConnectionState.Closed)
                DbConnection.Connection.Open();

            SqlCommand cmd = new SqlCommand("insert into Books (BookName, Author, GenreID, StartDate, FinishDate, ReadingStatus, Rating) values (@p1, @p2,@p3,@p4,@p5,@p6,@p7)", DbConnection.Connection);
            cmd.Parameters.AddWithValue("@p1", book.BookName);
            cmd.Parameters.AddWithValue("@p2", book.Author);
            cmd.Parameters.AddWithValue("@p3", book.GenreID);
            cmd.Parameters.AddWithValue("@p4", book.StartDate);
            cmd.Parameters.AddWithValue("@p5", book.FinishDate);
            cmd.Parameters.AddWithValue("@p6", book.Status);
            cmd.Parameters.AddWithValue("@p7", book.Rate);
            cmd.ExecuteNonQuery();
            DbConnection.Connection.Close();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            if (DbConnection.Connection.State == ConnectionState.Closed)
                DbConnection.Connection.Open();

            SqlCommand cmd = new SqlCommand("select * from Books", DbConnection.Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Book book = new Book();
                book.ID = Convert.ToInt32(dr["ID"]);
                book.BookName = dr["BookName"].ToString();               
                book.Author = dr["Author"].ToString();
                book.GenreID = Convert.ToInt32(dr["GenreID"]);
                book.StartDate = dr["StartDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["StartDate"]);
                book.FinishDate = dr["FinishDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FinishDate"]);
                book.Status = dr["ReadingStatus"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dr["ReadingStatus"]);
                book.Rate = dr["Rating"] == DBNull.Value ? (byte?)null : Convert.ToByte(dr["Rating"]);
                books.Add(book);
            }
            dr.Close();
            DbConnection.Connection.Close();
            return books;
        }

        public void Update(Book book)
        {
            if (DbConnection.Connection.State == ConnectionState.Closed)
                DbConnection.Connection.Open();

            SqlCommand cmd = new SqlCommand("update Books set BookName=@p1 , GenreID=@p2, Author=@p3, StartDate=@p4, FinishDate=@p5, ReadingStatus=@p6, Rating=@p7 where ID=@id", 
                DbConnection.Connection);
            cmd.Parameters.AddWithValue("@id", book.ID);
            cmd.Parameters.AddWithValue("@p1", book.BookName);
            cmd.Parameters.AddWithValue("@p2", book.GenreID);
            cmd.Parameters.AddWithValue("@p3", book.Author);
            cmd.Parameters.AddWithValue("@p4", book.StartDate);
            cmd.Parameters.AddWithValue("@p5", book.FinishDate);
            cmd.Parameters.AddWithValue("@p6", book.Status);
            cmd.Parameters.AddWithValue("@p7", book.Rate);
            cmd.ExecuteNonQuery();
            DbConnection.Connection.Close();

        }

    }
}
