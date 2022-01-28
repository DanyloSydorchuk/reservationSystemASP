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
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private IBookRepository bookRepository;
        private ICRUDBookRepository repository;
        public BookController(ICRUDBookRepository repository, IBookRepository bookRepository, UserManager<IdentityUser> userManager,
       SignInManager<IdentityUser> signInManager)
        {
            this.repository = repository;
            this.bookRepository = bookRepository;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Book(SeanseModel seanse)
        {
            HttpContext.Session.SetInt32("id", seanse.Id);
            return View("BookForm");
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(BookModel book)
        {

            var x = book.Seanse;
            int? seanseId = HttpContext.Session.GetInt32("id");
            IdentityUser identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid) 
            {
                repository.AddBook(book, seanseId, identityUser);
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
