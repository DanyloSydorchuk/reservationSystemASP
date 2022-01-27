using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReservationSystemASP.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public class EFCRUDBookRepository : ICRUDBookRepository
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public EFCRUDBookRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager,
       SignInManager<IdentityUser> signInManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public BookModel FindById(int id)
        {
            return _context.Bookings.Find(id);
        }
        public BookModel Delete(int id)
        { 
            var y = _context.Bookings.Find(id);
            //var seans = from b in _context.Bookings join s in _context.Seanses on b.Seanse.Id equals s.Id where y.Id==b.Id select s;
            
            var seans 
                = from b in _context.Bookings join s in _context.Seanses 
                  on b.Seanse.Id equals s.Id 
                  where y.Id==b.Id 
                  select new { id=b.Id, UserName=b.UserName, SeanseId=s.Id, CountPlaces=b.CountPlaces};

            var x = _context.Seanses.Where(x => x.Id.Equals(seans.First().SeanseId)).Single();
            x.CountPlaces += y.CountPlaces;
            _context.Seanses.Update(x);
            var book = _context.Bookings.Remove(_context.Bookings.Find(id)).Entity;
            _context.SaveChanges();
            return book;
        }


        public BookModel Add(BookModel book, int? seanseId,IdentityUser identityUser)
        {
            //IdentityUser identityUser = new IdentityUser { UserName = model.Username };
            //var user = new IdentityUser { UserName = model.UserName, Email=model.Email, PhoneNumber=model.PhoneNumber };
            //Task<IdentityResult> result = _userManager.CreateAsync(identityUser, model.Password);

            var x = _context.Seanses.Where(x => x.Id.Equals(seanseId)).First();
            x.CountPlaces -= book.CountPlaces;
            BookModel booking = new()
            {
               Id = book.Id,
               UserName = identityUser.UserName,
               Seanse = book.Seanse,
               CountPlaces = book.CountPlaces
            };
            x.Bookings.Add(booking);
            _context.Seanses.Update(x);
            
            BookModel entity = _context.Bookings.Add(booking).Entity;
            _context.SaveChanges();
            return entity;
        }

        public BookModel Update(BookModel book)
        {
            BookModel original = _context.Bookings.Find(book.Id);
            original.CountPlaces = book.CountPlaces;
            EntityEntry<BookModel> entityEntry = _context.Bookings.Update(original);
            _context.SaveChanges();
            return entityEntry.Entity;

        }

        public IList<BookModel> FindAll()
        {
            //var seans = (from b in _context.Bookings
            //             join s in _context.Seanses on b.Seanse.Id equals s.Id
            //             select new { id = b.Id, UserName = b.UserName, SeanseId = s.Id, CountPlaces = b.CountPlaces }).ToList();
            ////var result = from b in _context.Bookings select b;
            //return seans.ToList();
            return _context.Bookings.ToList();
        }
    }
}
