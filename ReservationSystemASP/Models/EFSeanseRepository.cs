using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReservationSystemASP.Models
{
    public class EFSeanseRepository : ISeanseRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public EFSeanseRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public IQueryable<SeanseModel> Seanses => _applicationDbContext.Seanses;

        //public void addIssue(int seanseId, Issue issue)
        //{
        //    SeanseModel seanse = _applicationDbContext.Seanses.Find(seanseId);
        //    seanse.Issue.Add(issue);
        //    _applicationDbContext.Seanses.Update(seanse);
        //    _applicationDbContext.SaveChanges();
        //}
    }
}
