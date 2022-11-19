using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class MedicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Odontograma()
        {
            return View();
        }
        public IActionResult Radioterapia()
        {
            return View();
        }

        public IActionResult Tratamiento()
        {
            return View();
        }
    }
}
