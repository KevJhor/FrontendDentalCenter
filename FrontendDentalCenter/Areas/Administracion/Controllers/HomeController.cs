using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
