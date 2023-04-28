using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAplikacija.Models
{
    public class TrenerViewModel
    {
        public int TrenerID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Obrazovanje { get; set; }
        public string ImePrezime { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }

    }
}
