using Domen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NuGet.Protocol;
using PristupPodacima.Jedinica_Posla;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class KlijentController : Controller
    {

        private readonly IJedinicaPosla jedinicaPosla;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public KlijentController(IJedinicaPosla jedinicaPosla, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.jedinicaPosla = jedinicaPosla;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<KlijentViewModel> model = jedinicaPosla
                .KlijentRepozitorijum
                .VratiSve()
                .Select(k => new KlijentViewModel
                {
                    KlijentID = k.KlijentID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    ImePrezime = k.ImePrezime,
                    Visina = k.Visina,
                    Kilaza = k.Kilaza,
                    Pol = k.Pol.PolNaziv,
                    Grupa = k.Grupa.GrupaIme

                })
                .ToList();
            return View(model);
        }

        public async Task<IActionResult> Kreiraj()
        {
            //User v = new User
            //{
            //    UserName = "tamara",
            //    Email = "tamara@gmail.com",
            //    ImePrezime = "Tamara Tamaric",
            //};

            //var result = await userManager.CreateAsync(v, "Password!123");
            //User v = new User
            //{
            //    UserName = "Nata",
            //    Email = "nata@gmail.com",
            //    ImePrezime = "Nata Natic",
            //};

            //var result = await userManager.CreateAsync(v, "Password!123");

            KreirajKlijentaViewModel model = new KreirajKlijentaViewModel();
            model.Grupe = jedinicaPosla.GrupaRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.GrupaIme + "-" + g.Mesto.Naziv,
                    Value = g.GrupaID.ToString()
                })
                .ToList();
            model.Polovi = jedinicaPosla.PolRepozitorijum
                .VratiSve()
                .Select(p => new SelectListItem
                {
                    Text = p.PolNaziv,
                    Value = p.PolID.ToString()
                })
                .ToList();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Kreiraj(KreirajKlijentaViewModel klijent)
        {
            if (ModelState.IsValid)
            {
                if (klijent.Kilaza == 0)
                {
                    ModelState.AddModelError("Kilaza", "Morate uneti kilazu!");
                    return await Kreiraj();
                }
                if (klijent.Visina == 0)
                {
                    ModelState.AddModelError("Visina", "Morate uneti visinu!");
                    return await Kreiraj();
                }
                Klijent k = new Klijent()
                {
                    Ime = klijent.Ime,
                    Prezime = klijent.Prezime,
                    Kilaza = klijent.Kilaza,
                    Visina = klijent.Visina,
                    PolID = klijent.PolID,
                    GrupaID = klijent.GrupaID
                };
                jedinicaPosla.KlijentRepozitorijum.Dodaj(k);
                jedinicaPosla.SacuvajPromene();
                return RedirectToAction("Index");
            }
            return await Kreiraj();
        }

        [Authorize(Roles = "Trener")]
        public IActionResult Promeni(int id)
        {
            
            Klijent k = jedinicaPosla.KlijentRepozitorijum.Vrati(id);

            PromeniKlijentaViewModel kl = new PromeniKlijentaViewModel
                {
                KlijentID = k.KlijentID,
                Ime = k.Ime,
                Prezime = k.Prezime,
                Visina = k.Visina,
                Kilaza = k.Kilaza,
                PolID = k.PolID,
                GrupaID = k.GrupaID
                };

            kl.Grupe = jedinicaPosla.GrupaRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.GrupaIme + "-" + g.Mesto.Naziv,
                    Value = g.GrupaID.ToString()
                })
                .ToList();
            kl.Polovi = jedinicaPosla.PolRepozitorijum
                .VratiSve()
                .Select(p => new SelectListItem
                {
                    Text = p.PolNaziv,
                    Value = p.PolID.ToString()
                })
                .ToList();

            return View(kl);
        }

        [HttpPost]
        public IActionResult Promeni(PromeniKlijentaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Klijent k = new Klijent()
                {
                    KlijentID = model.KlijentID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Kilaza = model.Kilaza,
                    Visina = model.Visina,
                    PolID = model.PolID,
                    GrupaID = model.GrupaID
                };
                jedinicaPosla.KlijentRepozitorijum.Izmeni(k);
                jedinicaPosla.SacuvajPromene();
                return RedirectToAction("Index");
            }
            return Promeni(model.KlijentID);
        }


        [Authorize(Roles = "Trener")]
        public IActionResult Obrisi(int id)
        {
            List<ObrisiKlijentaViewModel> list = jedinicaPosla
                .KlijentRepozitorijum
                .VratiSve()
                .Select(k => new ObrisiKlijentaViewModel
                {
                    KlijentID=k.KlijentID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    Visina = k.Visina,
                    Kilaza = k.Kilaza,
                    PolID = k.PolID,
                    Pol = k.Pol.PolNaziv,
                    GrupaID = k.GrupaID,
                    Grupa = k.Grupa.GrupaIme

                })
                .ToList();

            

            ObrisiKlijentaViewModel model = list.Single(k => k.KlijentID == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Obrisi(ObrisiKlijentaViewModel model)
        {
            if (ModelState.IsValid)
            {

                Klijent k = new Klijent()
                {
                    KlijentID = model.KlijentID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Kilaza = model.Kilaza,
                    Visina = model.Visina,
                    PolID = model.PolID,
                    GrupaID = model.GrupaID
                };
                jedinicaPosla.KlijentRepozitorijum.Obrisi(k);
                jedinicaPosla.SacuvajPromene();
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Pretrazi(string imePrezime)
        {
            List<PretraziKlijentaViewModel> model = jedinicaPosla
                .KlijentRepozitorijum
                .Pretrazi(imePrezime)
                .Select(k => new PretraziKlijentaViewModel
                {
                    KlijentID = k.KlijentID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    ImePrezime = k.ImePrezime,
                    Visina = k.Visina,
                    Kilaza = k.Kilaza,
                    Pol = k.Pol.PolNaziv,
                    Grupa = k.Grupa.GrupaIme
                })
                .ToList();
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
            
        }

        [Authorize(Roles = "Trener")]

        public async Task<IActionResult> Detalji(int id)
        {
            List<KlijentViewModel> model = jedinicaPosla
                .KlijentRepozitorijum
                .VratiSve()
                .Select(k => new KlijentViewModel
                {
                    KlijentID = k.KlijentID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    ImePrezime = k.ImePrezime,
                    Visina = k.Visina,
                    Kilaza = k.Kilaza,
                    Pol = k.Pol.PolNaziv,
                    Grupa = k.Grupa.GrupaIme
                })
                .ToList();


            KlijentViewModel? kl = model.Single(t => t.KlijentID == id);

            if (kl == null)
                return RedirectToAction("Index");

            return View(kl);


        }

    }
}
