using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validate(string email, string password)
        {
            if (email == "admin@peru.com" && password == "admin123")
                return RedirectToAction("Index", "Paciente", new { Area = "Administracion" });

            return RedirectToAction("Login", "Security");
        }
    }
}
