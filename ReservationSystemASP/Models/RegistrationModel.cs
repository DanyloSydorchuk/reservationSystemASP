using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystemASP.Models
{
    public class RegistrationModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać imię!")]
        //public string FirstName { get; set; }
        //[Required(ErrorMessage = "Proszę podać nazwisko!")]
        //public string Surname { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Proszę podać poprawny Email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string PasswordHash { get; set; }

    
        
    }

    
}
