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

        public EFCRUDBookRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public BookModel FindById(int id)
        {
            return _context.Bookings.Find(id);
        }
        public BookModel Delete(int id)
        {
            var book = _context.Bookings.Remove(_context.Bookings.Find(id)).Entity;
            _context.SaveChanges();
            return book;
        }

        public BookModel Add(BookModel book,SeanseModel seanse)
        {
            var entity = _context.Bookings.Add(book).Entity;
            SeanseModel original = _context.Seanses.Find(seanse.Id);
            original.CountPlaces = seanse.CountPlaces - book.CountPlaces;
            _context.Seanses.Update(original);
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
            return _context.Bookings.ToList();
        }
    }
}
