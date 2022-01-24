using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public interface ICRUDSeanseRepository
    {
        SeanseModel FindById(int id);
        SeanseModel Delete(int id);
        SeanseModel Add(SeanseModel seanse);
        SeanseModel Update(SeanseModel seanse);
        //SeanseModel AddBookUpdate(SeanseModel seanse);

        IList<SeanseModel> FindAll();
    }
}
