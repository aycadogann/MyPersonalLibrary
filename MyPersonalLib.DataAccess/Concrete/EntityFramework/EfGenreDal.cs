using MyPersonalLib.DataAccess.Abstract;
using MyPersonalLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalLib.DataAccess.Concrete.EntityFramework
{
    public class EfGenreDal : IGenreDal
    {
        public List<Genre> GetAll()
        {
            using (MyPersonalLibraryContext context=new MyPersonalLibraryContext())
            {
                return context.Genres.ToList();
            }
        }
    }
}
