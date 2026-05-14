using MyPersonalLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalLib.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
    }
}
