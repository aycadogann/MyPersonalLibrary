using MyPersonalLib.Business.Abstract;
using MyPersonalLib.Business.Concrete;
using MyPersonalLib.DataAccess.Concrete.EntityFramework;
using MyPersonalLib.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPersonalLib.MvcUI.Controllers
{
    public class GenreController : Controller
    {
        IGenreService _genreService;

        public GenreController()
        {
            _genreService = new GenreManager(new EfGenreDal());
        }

        // GET: Genre
        public ActionResult Index()
        {
            var genres = _genreService.GetAll();
            IEnumerable<GenreListViewModel> genreListViewModels = genres.Select(g => new GenreListViewModel
            {
                ID = g.ID,
                BookGenre = g.BookGenre
            }).ToList();

            return View(genreListViewModels);
        }
    }
}