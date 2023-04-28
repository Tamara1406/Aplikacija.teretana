using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Klijent
    {
        public int KlijentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Kilaza { get; set; }
        public int Visina { get; set; }
        public Grupa? Grupa { get; set; }
        public int GrupaID { get; set; }
        public Pol? Pol { get; set; }
        public int PolID { get; set; }
        public string ImePrezime
        {
            get => Ime + " " + Prezime;
        }

    }
}