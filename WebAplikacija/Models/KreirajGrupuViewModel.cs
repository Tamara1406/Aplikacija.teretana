using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    public class KreirajGrupuViewModel
    {
        public int GrupaID { get; set; }

        [Required(ErrorMessage = "Morate uneti naziv grupe!")]
        public string GrupaIme { get; set; }
        public List<SelectListItem>? Treneri { get; set; }
        public int TrenerID { get; set; }
        public List<SelectListItem>? Mesta { get; set; }
        public int MestoID { get; set; }


    }
}
