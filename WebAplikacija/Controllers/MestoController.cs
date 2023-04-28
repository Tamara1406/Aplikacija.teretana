using Microsoft.AspNetCore.Mvc;
using PristupPodacima;
using PristupPodacima.Jedinica_Posla;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class MestoController : Controller
    {
        private readonly IJedinicaPosla jedinicaPosla;
        public MestoController(IJedinicaPosla jedinicaPosla)
        {
            this.jedinicaPosla = jedinicaPosla;
        }

        public IActionResult Index()
        {
            List<MestoViewModel> model = jedinicaPosla
                .MestoRepozitorijum
                .VratiSve()
                .Select(m => new MestoViewModel
                {
                    MestoID = m.MestoID,
                    Naziv = m.Naziv,
                })
                .ToList();
            return View(model);
        }
    }
}
