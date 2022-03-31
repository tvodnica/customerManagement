using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class StavkaVM
    {
        public Stavka Stavka { get; set; }
        public Proizvod Proizvod { get; set; }
        public Kategorija Kategorija { get; set; }
        public Potkategorija Potkategorija { get; set; }
    }
}