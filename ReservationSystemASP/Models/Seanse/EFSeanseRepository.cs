using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReservationSystemASP.Models
{
    public class EFSeanseRepository : ISeanseRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public EFSeanseRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public IQueryable<SeanseModel> Seanses => _applicationDbContext.Seanses;

        //public void addBook(int seanseId, BookModel book)
        //{
        //    SeanseModel seanse = _applicationDbContext.Seanses.Find(seanseId);
        //    seanse.CountPlaces = seanse.CountPlaces - book.CountPlaces;
        //    _applicationDbContext.Seanses.AddBookUpdate(seanse);
        //    _applicationDbContext.SaveChanges();
        //}
    }
}
