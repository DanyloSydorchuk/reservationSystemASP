using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models.Book
{
    public class EFBookRepository : IBookRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public EFBookRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IQueryable<BookModel> Bookings => _applicationDbContext.Bookings;
        public IQueryable<SeanseModel> Seanses => _applicationDbContext.Seanses;
    }
}
