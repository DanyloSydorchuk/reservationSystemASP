using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public interface ICRUDSeanseRepository
    {
        SeanseModel Find(int id);
        SeanseModel Delete(int id);
        SeanseModel Add(SeanseModel seanse);
        SeanseModel Update(SeanseModel seanse);

        IList<SeanseModel> FindAll();
    }
}
