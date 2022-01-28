using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReservationSystemASP.Models;
using ReservationSystemASP.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepository;
        private ICRUDBookRepository repository;
        public BookController(ICRUDBookRepository repository, IBookRepository bookRepository)
        {
            this.repository = repository;
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult Book(SeanseModel seanse)
        {
            HttpContext.Session.SetInt32("id", seanse.Id);
            return View("BookForm");
        }
        [HttpPost]
        public IActionResult Add(BookModel book,IdentityUser identityUser)
        {

            var x = book.Seanse;
            int? seanseId = HttpContext.Session.GetInt32("id");
            //repository.Add(book,seanseId,identityUser);

            if (ModelState.IsValid) 
            {
                repository.Add(book, seanseId, identityUser);
                return View("BookingList", repository.FindAll());
            }
            else
            {
                return View();
            }
        }
        public IActionResult FindAll()
        {
            int? seanseId = HttpContext.Session.GetInt32("id");
            return View("BookingList", repository.FindAll());
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return View("BookingList", repository.FindAll());
        }

        public IActionResult EditForm(int id)
        {
            return View(repository.FindById(id));
        }

        public IActionResult Edit(BookModel book)
        {
            repository.Update(book);
            return View("BookingList", repository.FindAll());
        }
    }
}
