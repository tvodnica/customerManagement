using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Kategorija
    {
        public int IDKategorija { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Naziv { get; set; }
    }
}