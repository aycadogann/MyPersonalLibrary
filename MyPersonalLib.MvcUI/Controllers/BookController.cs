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
    public class BookController : Controller
    {
        IBookService _bookService;

        public BookController()
        {
            _bookService = new BookManager(new EfBookDal());
        }

        // GET: Book
        public ActionResult Index()
        {
            var books=_bookService.GetAll();
            IEnumerable<BookListViewModel> viewModelList = books.Select(b => new BookListViewModel
            {
                BookName = b.BookName, // Kendi property isimlerine göre eşitle
                Author = b.Author,
                Status = b.Status==true? "Okundu" : "Okunacak",
                Rate = b.Rate
            }).ToList();
            return View(viewModelList);
        }
    }
}