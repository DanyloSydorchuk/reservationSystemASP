using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public class EFCRUDSeanseRepository : ICRUDSeanseRepository
    {
        private ApplicationDbContext _context;

        public EFCRUDSeanseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SeanseModel Find(int id)
        {
            return _context.Seanses.Find(id);
        }

        public SeanseModel Delete(int id)
        {
            var seanse = _context.Seanses.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return seanse;
        }

        public SeanseModel Add(SeanseModel seanse)
        {
            var entity = _context.Seanses.Add(seanse).Entity;
            _context.SaveChanges();
            return entity;
        }

        public SeanseModel Update(SeanseModel seanse)
        {
            var entity = _context.Seanses.Update(seanse).Entity;
            _context.SaveChanges();
            return entity;
        }

        public IList<SeanseModel> FindAll()
        {
            return _context.Seanses.ToList();
        }
    }
}
