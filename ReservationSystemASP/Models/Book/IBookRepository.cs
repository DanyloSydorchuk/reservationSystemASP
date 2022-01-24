using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public interface IBookRepository
    {
        IQueryable<BookModel> Bookings { get; }
    }
}
