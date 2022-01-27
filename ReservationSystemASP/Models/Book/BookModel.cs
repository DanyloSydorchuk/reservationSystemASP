using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public class BookModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [HiddenInput]
        public string UserName { get; set; }
        [HiddenInput]
        public SeanseModel Seanse { get; set; }
        [Required(ErrorMessage = "Proszę podać liczbę miejsc")]
        [Range(1, 20, ErrorMessage = "Liczba miejsc pomiędzy 1 a 20")]
        public int CountPlaces { get; set; }

    }
}
