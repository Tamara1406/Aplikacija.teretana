using Microsoft.AspNetCore.Mvc;

namespace WebAplikacija.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
