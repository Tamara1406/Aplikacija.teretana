using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace WebAplikacija.Models
{
    public class ObrisiGrupuViewModel
    {
        public int GrupaID { get; set; }
        public string GrupaIme { get; set; }
        public int TrenerID { get; set; }
        public string Trener { get; set; }
        public int MestoID { get; set; }
        public string Mesto { get; set; }
    }
}
