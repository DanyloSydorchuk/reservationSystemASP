using System;
using Xunit;
using ReservationSystemASP.Models;
using System.Collections.Generic;
using System.Linq;

namespace reservationSystemASPTest
{
    class SeanseModelTest : ICRUDSeanseRepository
    {
        private Dictionary<int, SeanseModel> seanses = new Dictionary<int, SeanseModel>();
        private int index = 0;
        public SeanseModel Add(SeanseModel seanseModel)
        {
            seanseModel.Id = ++index;
            seanses.Add(seanseModel.Id, seanseModel);
            return seanseModel;
        }

        public SeanseModel Delete(int id)
        {
            throw new NotImplementedException();
        }
        public SeanseModel FindById(int id) 
        {
            return seanses[id];
        }
        public SeanseModel Update(SeanseModel seanse)
        {
            throw new NotImplementedException();
        }
        public IList<SeanseModel> FindAll()
        {
            return seanses.Values.ToList();
        }


    

        
    }
}
