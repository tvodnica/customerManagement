using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Potkategorija
    {
        public int IDPotkategorija { get; set; }

        [Required(ErrorMessage = "Kategorija je obavezna")]
        public int KategorijaID { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Naziv { get; set; }
    }
}