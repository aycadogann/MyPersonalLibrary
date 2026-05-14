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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            if (DbConnection.Connection.State==ConnectionState.Closed)
                DbConnection.Connection.Open();

                SqlCommand cmd = new SqlCommand("select * from Books", DbConnection.Connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Book book = new Book();
                    book.ID = Convert.ToInt32(dr["ID"]);
                    book.BookName = dr["BookName"].ToString();
                    book.Author = dr["Author"].ToString();
                    book.Genre = dr["Genre"].ToString();
                    book.StartDate = dr["StartDate"]==DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["StartDate"]);
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
            throw new NotImplementedException();
        }
    }
}
