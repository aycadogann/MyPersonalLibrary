using MyPersonalLib.Business.Abstract;
using MyPersonalLib.Business.Concrete;
using MyPersonalLib.DataAccess.Abstract;
using MyPersonalLib.DataAccess.Concrete.AdoNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPersonalLib.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IBookService bookService = new BookManager(new AdoNetBookDal());
            IGenreService genreService = new GenreManager(new AdoNetGenreDal());

            Application.Run(new Form1(bookService,genreService));
        }


    }
}
