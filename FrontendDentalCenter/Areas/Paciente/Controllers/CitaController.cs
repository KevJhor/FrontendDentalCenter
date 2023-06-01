using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using FrontendDentalCenter.Areas.Medico.Models;

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
        public async Task<IActionResult> RegistroCita(int idP)
        {
            var Paciente = await PacienteService.GetPacientesbyId(idP);
            ViewBag.Paciente = Paciente;
            var Medico = await MedicoService.GetMedicos();
            ViewBag.MedicoList = Medico;
            var Especialidad = await EspecialidadService.GetEspecialidades();
            ViewBag.Especialidades = Especialidad;
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
        public async Task<IActionResult> TablaCitasPorPaciente(int idP)
        {
            var citas = await CitaServices.GetCitaByPacienteId(idP);
            ViewBag.CitasLista = citas;
            var medicos = await MedicoService.GetMedicos();
            ViewBag.Medicos = medicos;
            ViewBag.Paciente = idP;
            return View();
        }
        public async Task<IActionResult> GuardarCita(int idCita, int idPaciente,
                                                int idMedico, string estado, DateTime fechaHora)
        {
            bool exito = true;
            var objCita = new CitaViewModel()
            {
                IdCita = idCita,
                IdPaciente = idPaciente,
                IdMedico = idMedico,
                Estado = estado,
                FechaHora = fechaHora
            };
            exito = await CitaServices.UpdateCita(objCita);
            return Json(exito);
        }
    }
}
