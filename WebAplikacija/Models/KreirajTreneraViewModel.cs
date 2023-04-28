using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    public class KreirajTreneraViewModel
    {
        public int TrenerID { get; set; }
        [Required(ErrorMessage = "Morate uneti ime!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Morate uneti prezime!")]
        public string Prezime { get; set; }
        public int ObrazovanjeID { get; set; }
        public List<SelectListItem>? Obrazovanja { get; set; }
        [Required(ErrorMessage = "Morate uneti opis!")]
        public string Opis { get; set; }
        public string? Slika { get; set; }
    }
}
