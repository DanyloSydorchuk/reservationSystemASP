using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models.Book
{
    public interface ICRUDBookRepository
    {
        BookModel FindById(int id);
        BookModel Delete(int id);
        BookModel Add(BookModel book,SeanseModel seanse);
        BookModel Update(BookModel book);

        IList<BookModel> FindAll();
    }
}
