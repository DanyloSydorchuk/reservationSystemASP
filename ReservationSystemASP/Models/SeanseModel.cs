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
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan SeanseStart { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan SeanseEnd { get; set; }
        [Required]
        public int CountPlaces { get; set; }
    }
}
