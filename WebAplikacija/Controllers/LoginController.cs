using Domen;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PristupPodacima.Jedinica_Posla;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> signInManager;
        public LoginController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(model.KorisnickoIme != null && model.Lozinka != null)
            {
                var result = await signInManager.PasswordSignInAsync(model.KorisnickoIme, model.Lozinka, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
                
            ModelState.AddModelError("KorisnickoIme", "Proverite da li ste dobro uneli korisničko ime.");
            ModelState.AddModelError("Lozinka", "Niste dobro uneli lozinku!");
            return View("Index");
        }
    }
}
