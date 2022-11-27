using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Paciente.Controllers
{
    [Area("Paciente")]
    public class CitaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var especialidad = await EspecialidadService.GetEspecialidades();
            ViewBag.EspecialidadList = especialidad;
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var pacientes = await PacienteService.GetPacientes();
            ViewBag.PacienteList = pacientes;
            return View();
        }
        public async Task<IActionResult> ListadoDeEspecialidades() 
        {
            var especialidad = await EspecialidadService.GetEspecialidades();
            ViewBag.EspecialidadList = especialidad;
            return View();

        }
    }
}
