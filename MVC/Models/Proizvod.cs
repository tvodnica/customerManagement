using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Proizvod
    {
        public int IDProizvod { get; set; }

        [Display(Name = "Potkategorija")]
        [Required(ErrorMessage = "Potkategorija je obavezna")]
        public int PotkategorijaID { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Naziv { get; set; }

        [Display(Name = "Broj proizvoda")]
        [Required(ErrorMessage = "Broj proizvoda je obavezan")]
        public string BrojProizvoda { get; set; }

        [Required(ErrorMessage = "Boja je obavezna")]
        public string Boja { get; set; }

        [Display(Name = "Minimalna količina na skladištu")]
        [Required(ErrorMessage = "Minimalna količina je obavezna")]
        public int MinimalnaKolicinaNaSkladistu { get; set; }

        [Display(Name = "Cijena bez PDV-a")]
        [Required(ErrorMessage = "Cijena je obavezna")]
        public double CijenaBezPDV { get; set; }
    }
}