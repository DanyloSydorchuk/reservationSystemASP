using Microsoft.AspNetCore.Identity;
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
        BookModel AddBook(BookModel book,int? seanseId,IdentityUser identityUser);
        BookModel Update(BookModel book);

        IList<BookModel> FindAll();
    }
}
