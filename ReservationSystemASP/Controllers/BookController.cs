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
        public IActionResult Book()
        {
            return View("BookForm");
        }
        [HttpPost]
        public IActionResult Add(BookModel book,SeanseModel seanse)
        {
                repository.Add(book,seanse);
                return View("BookingList", repository.FindAll());
        }
        public IActionResult FindAll()
        {
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
