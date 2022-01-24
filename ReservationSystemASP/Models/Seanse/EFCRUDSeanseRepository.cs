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
            var entity = _context.Seanses.Add(seanse).Entity;
            _context.SaveChanges();
            return entity;
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

        //public SeanseModel AddBookUpdate(SeanseModel seanse)
        //{
        //    EntityEntry<SeanseModel> entityEntry = _context.Seanses.Update(seanse);
        //    _context.SaveChanges();
        //    return entityEntry.Entity;
        //}

        public IList<SeanseModel> FindAll()
        {
            return _context.Seanses.ToList();
        }
    }
}
