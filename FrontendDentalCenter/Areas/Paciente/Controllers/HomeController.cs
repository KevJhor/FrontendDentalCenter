using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Paciente.Controllers
{
    [Area("Paciente")]
    public class HomeController : Controller
    {
        //private int idPac;
        //public async Task idPaciente(int idP)
        //{
        //    var Paciente = await PacienteService.GetPacientesbyId(idP);
        //    var IdPaciente = Paciente.IdPaciente;
        //    idPac = IdPaciente;
        //}
        public async Task<IActionResult> Index(int idP)
        {
            var Paciente = await PacienteService.GetPacientesbyId(idP);
            ViewBag.Paciente = Paciente;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
