using MyPersonalLib.Business.Abstract;
using MyPersonalLib.DataAccess.Abstract;
using MyPersonalLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalLib.Business.Concrete
{
    public class GenreManager : IGenreService
    {
        IGenreDal _genreDal;
        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }
        public List<Genre> GetAll()
        {
            return _genreDal.GetAll();
        }
    }
}
