using Domen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using PristupPodacima.Jedinica_Posla;
using System.Data;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class GrupaController : Controller
    {
        private readonly IJedinicaPosla jedinicaPosla;
        public GrupaController(IJedinicaPosla jedinicaPosla)
        {
            this.jedinicaPosla = jedinicaPosla;
        }

        public IActionResult Index()
        {
            List<GrupaViewModel> model = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new GrupaViewModel
                {
                    GrupaIme = g.GrupaIme,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv
                })
                .ToList();
            return View(model);
        }

        [Authorize(Roles ="Admin, Trener")]
        public IActionResult IndexAdmin()
        {
            List<GrupaViewModel> model = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new GrupaViewModel
                {
                    GrupaID = g.GrupaID,
                    GrupaIme = g.GrupaIme,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv
                })
                .ToList();
            return View(model);
        }

        public IActionResult Pretrazi(string naziv)
        {
            List<PretraziGrupuViewModel> model = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new PretraziGrupuViewModel
                {
                    GrupaIme = g.GrupaIme,
                    TrenerID = g.Trener.TrenerID,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv
                })
                .ToList();

            List<PretraziGrupuViewModel> nova = new List<PretraziGrupuViewModel>();

            foreach(var item in model)
            {
                if(item.Mesto.Equals(naziv))
                    nova.Add(item);
            }

            
            return View(nova);
        }


        public IActionResult PretraziTrener(int trener)
        {
            List<PretraziGrupuViewModel> model = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new PretraziGrupuViewModel
                {
                    GrupaIme = g.GrupaIme,
                    TrenerID = g.Trener.TrenerID,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv
                })
                .ToList();

            List<PretraziGrupuViewModel> nova = new List<PretraziGrupuViewModel>();

            foreach (var item in model)
            {
                if (item.TrenerID.Equals(trener))
                    nova.Add(item);
            }


            return View(nova);
        }

        [Authorize(Roles = "Admin,Trener")]
        public async Task<IActionResult> Kreiraj()
        {
            KreirajGrupuViewModel model = new KreirajGrupuViewModel();
            model.Treneri = jedinicaPosla.TrenerRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.ImePrezime,
                    Value = g.TrenerID.ToString()
                })
                .ToList();
            model.Mesta = jedinicaPosla.MestoRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.Naziv,
                    Value = g.MestoID.ToString()
                })
                .ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Kreiraj(KreirajGrupuViewModel grupa)
        {
            if (ModelState.IsValid)
            {
                Grupa g = new Grupa()
                {
                    GrupaIme = grupa.GrupaIme,
                    TrenerID = grupa.TrenerID,
                    MestoID = grupa.MestoID
                };
                jedinicaPosla.GrupaRepozitorijum.Dodaj(g);
                jedinicaPosla.SacuvajPromene();
                return RedirectToAction("Index");
            }
            return await Kreiraj();
        }


        [Authorize(Roles = "Admin, Trener")]
        public IActionResult Obrisi(int id)
        {
            List<ObrisiGrupuViewModel> list = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new ObrisiGrupuViewModel
                {
                    GrupaID = g.GrupaID,
                    GrupaIme = g.GrupaIme,
                    TrenerID = g.TrenerID,
                    MestoID = g.MestoID,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv

                })
                .ToList();

            ObrisiGrupuViewModel model = list.Single(g => g.GrupaID == id);


            return View(model);
        }

        [HttpPost]
        public IActionResult Obrisi(ObrisiGrupuViewModel model)
        {
            if (ModelState.IsValid)
            {

                Grupa g = new Grupa()
                {
                    GrupaID = model.GrupaID,
                    GrupaIme = model.GrupaIme,
                    TrenerID = model.TrenerID,
                    MestoID = model.MestoID
                };
                jedinicaPosla.GrupaRepozitorijum.Obrisi(g);
                jedinicaPosla.SacuvajPromene();


            }
            return RedirectToAction("Index");
        }

    
    }
}
