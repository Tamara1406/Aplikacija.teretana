using Domen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PristupPodacima.Jedinica_Posla;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class TrenerController : Controller
    {
        private readonly IJedinicaPosla jedinicaPosla;

        public TrenerController(IJedinicaPosla jedinicaPosla)
        {
            this.jedinicaPosla = jedinicaPosla;
        }
    
        public IActionResult Index()
        {
            List<TrenerViewModel> model = jedinicaPosla
                .TrenerRepozitorijum
                .VratiSve()
                .Select(t => new TrenerViewModel
                {
                    TrenerID = t.TrenerID,
                    Ime = t.Ime,
                    Prezime = t.Prezime,
                    Obrazovanje = t.Obrazovanje.StepenObrazovanja,
                    ImePrezime = t.ImePrezime,
                    Opis = t.Opis,
                    Slika = t.Slika
                })
                .ToList();
            return View(model);
        }

        [Authorize(Roles = "Admin, Trener")]
        public IActionResult IndexAdmin()
        {
            List<TrenerViewModel> model = jedinicaPosla
                .TrenerRepozitorijum
                .VratiSve()
                .Select(t => new TrenerViewModel
                {
                    TrenerID = t.TrenerID,
                    Ime = t.Ime,
                    Prezime = t.Prezime,
                    Obrazovanje = t.Obrazovanje.StepenObrazovanja,
                    Opis = t.Opis,
                    Slika = t.Slika
                })
                .ToList();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Kreiraj()
        {
            KreirajTreneraViewModel model = new KreirajTreneraViewModel();
            model.Obrazovanja = jedinicaPosla.ObrazovanjeRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.StepenObrazovanja,
                    Value = g.ObrazovanjeID.ToString()
                })
                .ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Kreiraj(KreirajTreneraViewModel trener)
        {
            if (ModelState.IsValid)
            {
                Trener t = new Trener()
                {
                    Ime = trener.Ime,
                    Prezime = trener.Prezime,
                    ObrazovanjeID = trener.ObrazovanjeID,
                    Opis = trener.Opis,
                    Slika = trener.Slika
                };
                jedinicaPosla.TrenerRepozitorijum.Dodaj(t);
                jedinicaPosla.SacuvajPromene();

                return RedirectToAction("Index");
            }
            return await Kreiraj();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Promeni(int id)
        {

            Trener t = jedinicaPosla.TrenerRepozitorijum.Vrati(id);

            PromeniTreneraViewModel tr = new PromeniTreneraViewModel
            {
                TrenerID = t.TrenerID,
                Ime = t.Ime,
                Prezime = t.Prezime,
                ObrazovanjeID = t.ObrazovanjeID,
                Opis = t.Opis,
                Slika = t.Slika
            };

            tr.Obrazovanja = jedinicaPosla.ObrazovanjeRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.StepenObrazovanja,
                    Value = g.ObrazovanjeID.ToString()
                })
                .ToList();


            return View(tr);
        }

        [HttpPost]
        public IActionResult Promeni(PromeniTreneraViewModel model)
        {
            if (ModelState.IsValid)
            {
                Trener t = new Trener()
                {
                    TrenerID = model.TrenerID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    ObrazovanjeID = model.ObrazovanjeID,
                    Opis = model.Opis,
                    Slika = model.Slika
                };
                jedinicaPosla.TrenerRepozitorijum.Izmeni(t);
                jedinicaPosla.SacuvajPromene();
                return RedirectToAction("Index");

            }
            return Promeni(model.TrenerID);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Obrisi(int id)
        {
            List<ObrisiTreneraViewModel> list = jedinicaPosla
                .TrenerRepozitorijum
                .VratiSve()
                .Select(t => new ObrisiTreneraViewModel
                {
                    TrenerID = t.TrenerID,
                    Ime = t.Ime,
                    Prezime = t.Prezime,
                    ObrazovanjeID = t.ObrazovanjeID,
                    Obrazovanje = t.Obrazovanje.StepenObrazovanja,
                    Opis = t.Opis,
                    Slika=t.Slika

                })
                .ToList();

            ObrisiTreneraViewModel model = list.Single(t => t.TrenerID == id);


            return View(model);
        }

        [HttpPost]
        public IActionResult Obrisi(ObrisiTreneraViewModel model)
        {
            if (ModelState.IsValid)
            {

                Trener t = new Trener()
                {
                    TrenerID = model.TrenerID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    ObrazovanjeID = model.ObrazovanjeID,
                    Opis = model.Opis,
                    Slika = model.Slika
                };
                jedinicaPosla.TrenerRepozitorijum.Obrisi(t);
                jedinicaPosla.SacuvajPromene();
                

            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Pretrazi(string imePrezime)
        {
            List<PretraziTreneraViewModel> model = jedinicaPosla
                .TrenerRepozitorijum
                .VratiSve()
                .Select(t => new PretraziTreneraViewModel
                {
                    TrenerID = t.TrenerID,
                    Ime = t.Ime,
                    Prezime = t.Prezime,
                    ImePrezime = t.ImePrezime,
                    Obrazovanje = t.Obrazovanje.StepenObrazovanja,
                    Opis = t.Opis,
                    Slika = t.Slika
                })
                .ToList();


            PretraziTreneraViewModel? tr = model.FirstOrDefault(t => t.ImePrezime.Trim().ToLower().StartsWith(imePrezime.Trim().ToLower()));

            if (tr == null)
                return RedirectToAction("Index");

            return View(tr);


        }
    }
}
