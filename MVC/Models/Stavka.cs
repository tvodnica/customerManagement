using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Stavka
    {
        public int IDStavka { get; set; }
        public int RacunID { get; set; }
        [Display(Name = "Količina")]
        public int Kolicina { get; set; }
        [Display(Name = "Proizvod")]
        public int ProizvodID { get; set; }
        [Display(Name = "Cijena po komadu")]
        public double CijenaPoKomadu { get; set; }
        [Display(Name = "Popust u postocima")]
        public double PopustUPostocima { get; set; }
        [Display(Name = "Ukupna cijena")]
        public double UkupnaCijena { get; set; }
    }
}