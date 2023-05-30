using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Paciente.Controllers
{
    [Area("Paciente")]
    public class CitaController : Controller
    {
        int idPaciente = 0;
        public async Task<IActionResult> Index()
        {
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
        public async Task<IActionResult> ListaCita()
        {
            var cita = await CitaServices.GetCitaByPacienteId(idPaciente);
            ViewBag.CitaList = cita;
            return View();
        }
    }
}
