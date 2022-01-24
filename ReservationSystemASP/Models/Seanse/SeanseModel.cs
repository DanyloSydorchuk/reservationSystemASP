using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public class SeanseModel 
    {
        public SeanseModel()
        {
            Bookings = new HashSet<BookModel>();
        }
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać datę przeprowadzenia seansu")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Proszę podać godzinę rozpoczęcia seansu")]
        [DataType(DataType.Time)]
        public TimeSpan SeanseStart { get; set; }
        [Required(ErrorMessage ="Proszę podać godzinę zakończenia seansu")]
        [DataType(DataType.Time)]
        public TimeSpan SeanseEnd { get; set; }
        [Required(ErrorMessage ="Proszę podać liczbę miejsc")]
        [Range(1,20,ErrorMessage = "Liczba miejsc pomiędzy 1 a 20")]
        public int CountPlaces { get; set; }
        public ICollection<BookModel> Bookings { get; set; }
    }
}
 