using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Trener
    {
        public int TrenerID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Obrazovanje Obrazovanje { get; set; }
        public int ObrazovanjeID { get; set; }
        public string ImePrezime
        {
            get => Ime + " " + Prezime;
        }
        public string Opis { get; set; }
        public string? Slika { get; set; }
    }
}
