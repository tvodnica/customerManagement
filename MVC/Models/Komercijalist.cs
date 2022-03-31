using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Komercijalist
    {
        public int IDKomercijalist { get; set; }
        public string Ime { get; set; }
        public string Prezime{ get; set; }
        public bool StalniZaposlenik { get; set; }

        public override string ToString() => Ime + " " + Prezime;
    }
}