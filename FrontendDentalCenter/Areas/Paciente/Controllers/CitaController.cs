using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace FrontendDentalCenter.Areas.Paciente.Controllers
{
    [Area("Paciente")]
    public class CitaController : Controller
    {
        public async Task<IActionResult> Index(int idP)
        {
            var Paciente = await PacienteService.GetPacientesbyId(idP);
            ViewBag.Paciente = Paciente;
            var especialidad = await EspecialidadService.GetEspecialidades();
            ViewBag.EspecialidadList = especialidad;
            var medico = await MedicoService.GetMedicos();
            ViewBag.MedicoList = medico;
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var pacientes = await PacienteService.GetPacientes();
            ViewBag.PacienteList = pacientes;
            return PartialView();
        }
        public async Task<IActionResult> ListadoDeEspecialidades() 
        {
            var especialidad = await EspecialidadService.GetEspecialidades();
            ViewBag.EspecialidadList = especialidad;
            return View();
        }
    }
}
