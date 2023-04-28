using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    public class ObrisiKlijentaViewModel
    {
        public int KlijentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Kilaza { get; set; }
        public int Visina { get; set; }
        public int PolID { get; set; }
        public string Pol { get; set; }
        public int GrupaID { get; set; }
        public string Grupa { get; set; }


    }
}
