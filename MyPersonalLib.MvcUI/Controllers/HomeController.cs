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
    public class HomeController : Controller
    {

        IBookService _bookService;
        public HomeController()
        {
            _bookService = new BookManager(new EfBookDal());
        }
        // GET: Home
        public ActionResult Index()
        {
            var books = _bookService.GetAll();
            IEnumerable<BookListViewModel> viewModelList = books.Select(b => new BookListViewModel
            {
                ID = b.ID,
                BookName = b.BookName,
                Author = b.Author,
                Status = b.Status == true ? "Okundu" : "Okunacak",
                Rate = b.Rate
            }).ToList();
            return View(viewModelList);
        }
    }
}