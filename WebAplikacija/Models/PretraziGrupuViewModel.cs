using Domen;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAplikacija.Models
{
    public class PretraziGrupuViewModel
    {
        public int GrupaID { get; set; }
        public string GrupaIme { get; set; }
        public List<SelectListItem> Treneri { get; set; }
        public int TrenerID { get; set; }
        public string Trener { get; set; }
        public List<SelectListItem> Mesta { get; set; }
        public string Mesto { get; set; }
    }
}
