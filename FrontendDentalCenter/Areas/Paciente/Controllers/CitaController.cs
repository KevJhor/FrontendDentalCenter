using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Paciente.Controllers
{
    [Area("Paciente")]
    public class CitaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var pacientes = await PacienteService.GetPacientes();
            ViewBag.PacienteList = pacientes;
            return View();
        }
    }
}
