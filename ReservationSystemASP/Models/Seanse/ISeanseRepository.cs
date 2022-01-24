using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public interface ISeanseRepository
    {
        IQueryable<SeanseModel> Seanses { get; }

        //void addBook(int seanseId, BookModel book);
    }
    
}
