using MyPersonalLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalLib.DataAccess.Abstract
{
    public interface IGenreDal
    {
        List<Genre> GetAll();
    }
}
