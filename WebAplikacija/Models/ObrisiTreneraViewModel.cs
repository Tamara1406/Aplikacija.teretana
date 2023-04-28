using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAplikacija.Models
{
    public class ObrisiTreneraViewModel
    {
        public int TrenerID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Obrazovanje { get; set; }
        public int ObrazovanjeID { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
    }
}
