using Microsoft.EntityFrameworkCore;
using MyPersonalLib.DataAccess.Abstract;
using MyPersonalLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalLib.DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : IBookDal
    {
        public void Add(Book book)
        {
            using (MyPersonalLibraryContext context = new MyPersonalLibraryContext())
            {
                context.Add(book);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (MyPersonalLibraryContext context = new MyPersonalLibraryContext())
            {
                Book book = context.Books.Find(id);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }

        public List<Book> GetAll()
        {
            using (MyPersonalLibraryContext context = new MyPersonalLibraryContext())
            {
                return context.Books.ToList();
            }
        }

        public void Update(Book book)
        {
            using (MyPersonalLibraryContext context = new MyPersonalLibraryContext())
            {
                var updatedBook = context.Entry(book);
                updatedBook.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
