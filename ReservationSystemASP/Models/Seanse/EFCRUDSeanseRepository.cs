using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            this._context = context;
        }

        public SeanseModel FindById(int id)
        {
            return _context.Seanses.Find(id);
        }

        public SeanseModel Delete(int id)
        {
            var seanse = _context.Seanses.Remove(_context.Seanses.Find(id)).Entity;
            _context.SaveChanges();
            return seanse;
        }

        public SeanseModel Add(SeanseModel seanse)
        {
            if(seanse.Date>=DateTime.Now && seanse.SeanseStart<=seanse.SeanseEnd && seanse.SeanseStart.Hours>= DateTime.Now.Hour) 
            { 
                var entity = _context.Seanses.Add(seanse).Entity;
                _context.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public SeanseModel Update(SeanseModel seanse)
        {
            SeanseModel original = _context.Seanses.Find(seanse.Id);
            original.Date = seanse.Date;
            original.SeanseStart = seanse.SeanseStart;
            original.SeanseEnd = seanse.SeanseEnd;
            original.CountPlaces = seanse.CountPlaces;
            EntityEntry<SeanseModel> entityEntry = _context.Seanses.Update(original);
            _context.SaveChanges();
            return entityEntry.Entity;

        }

        public IList<SeanseModel> FindAll()
        {
            var seanses = from s in _context.Seanses orderby s.Date, s.SeanseStart select s;
            return seanses.ToList();
            //return _context.Seanses.ToList();
        }
    }
}
