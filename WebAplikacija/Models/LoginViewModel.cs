using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Morate uneti korisnicko ime!")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Morate uneti lozinku!")]
        public string Lozinka { get; set; }
    }
}
