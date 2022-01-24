using Microsoft.AspNetCore.Mvc;
using ReservationSystemASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReservationSystemASP.Controllers
{
    public class SeanseController : Controller
    {
        private ISeanseRepository seanseRepository;
        private ICRUDSeanseRepository repository;
        public SeanseController(ICRUDSeanseRepository repository,ISeanseRepository seanseRepository)
        {
            this.repository = repository;
            this.seanseRepository = seanseRepository;
        }

        [HttpGet]
        public IActionResult Seanse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SeanseModel seanse)
        {

            if (ModelState.IsValid)
            {
                repository.Add(seanse);
                return View("SeanseList",repository.FindAll());
            }
            else { 
                return View();
            }
        }

        public IActionResult FindAll()
        {
            return View("SeanseList", repository.FindAll());
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return View("SeanseList", repository.FindAll());
        }

        public IActionResult EditForm(int id)
        {
            return View(repository.FindById(id));
        }

        public IActionResult Edit(SeanseModel seanse)
        {
            repository.Update(seanse);
            return View("SeanseList", repository.FindAll());
        }
        // public IActionResult Book(SeanseModel seanse)
        //{
        //    return View("BookForm");
        //}
        //public IActionResult BookingAdd(SeanseModel seanse)
        //{
        //    return View("BookingList", repository.FindAll());
        //}

       


        //private static List<SeanseModel> _seanses = new List<SeanseModel>()
        //{
        //    new SeanseModel()
        //    {
        //        Date=DateTime.Now, SeanseStart=TimeSpan.Parse("15:00"),
        //        SeanseEnd=TimeSpan.Parse("16:30"), CountPlaces=20
        //    },
        //    new SeanseModel()
        //    {
        //        Date=DateTime.Now, SeanseStart=TimeSpan.Parse("17:00"),
        //        SeanseEnd=TimeSpan.Parse("18:30"), CountPlaces=20
        //    },
        //    new SeanseModel()
        //    {
        //        Date=DateTime.Now, SeanseStart=TimeSpan.Parse("19:00"),
        //        SeanseEnd=TimeSpan.Parse("20:30"), CountPlaces=20
        //    },
        //    new SeanseModel()
        //    {
        //        Date=DateTime.Now, SeanseStart=TimeSpan.Parse("21:00"),
        //        SeanseEnd=TimeSpan.Parse("22:30"), CountPlaces=20
        //    }

        //};
    }
}
