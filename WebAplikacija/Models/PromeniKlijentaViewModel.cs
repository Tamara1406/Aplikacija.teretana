using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    public class PromeniKlijentaViewModel
    {
        public int KlijentID { get; set; }
        [Required(ErrorMessage = "Morate uneti ime!")]

        public string Ime { get; set; }
        [Required(ErrorMessage = "Morate uneti prezime!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Morate uneti kilažu!")]
        public int Kilaza { get; set; }
        [Required(ErrorMessage = "Morate uneti visinu!")]
        public int Visina { get; set; }
        public int PolID { get; set; }
        public List<SelectListItem>? Polovi { get; set; }
        public int GrupaID { get; set; }
        public List<SelectListItem>? Grupe { get; set; }


    }
}