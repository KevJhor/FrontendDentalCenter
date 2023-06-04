
using FrontendDentalCenter.Areas.Paciente.Models;
using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FrontendDentalCenter.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> RegistroCita(string correo)
        {
            var Medicos = await MedicoService.GetMedicos();
            var Especialidades = await EspecialidadService.GetEspecialidades();
            ViewBag.MedicoList = Medicos;
            ViewBag.Especialidades = Especialidades;
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var pacientes = await PacienteService.GetPacientes();
            ViewBag.PacienteList = pacientes;
            return PartialView();
        }
        public async Task<IActionResult> Obtener(int id)
        {
            var paciente = await PacienteService.GetPacientesbyId(id);
            return Json(paciente);
        }
        public async Task<IActionResult> CrearCita(int idCita, string idPaciente,
                                                string nombreMedico, string estado, string fecha, string hora)
        {
            bool exito = true;
            var pacientes = await PacienteService.GetPacientes();
            var idPac = 0;
            foreach (var item in pacientes)
            {
                if(item.Correo == idPaciente)
                {
                    idPac = item.IdPaciente;
                }
            }
            int idMedico = 0;
            string compuesto = "";
            string? fechaYhora = "";
            fechaYhora = fecha + ' ' + hora;
            string formato = "yyyy-MM-dd HH:mm";
            DateTime fechaCita;
            DateTime.TryParseExact(fechaYhora, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaCita);
            var medicos = await MedicoService.GetMedicos();
            foreach (var item in medicos)
            {
                compuesto = item.Nombre + ' ' + item.Apellido;
                if (compuesto == nombreMedico)
                {
                    idMedico = item.IdMedico;
                }
            }
            var objCita = new PacienteCitaViewModelPost()
            {
                IdPaciente = idPac,
                IdMedico = idMedico,
                Estado = estado,
                FechaHora = fechaCita
            };
            exito = await CitaServices.InsertCita(objCita);
            return Json(exito);
        }
        public async Task<IActionResult> Guardar(int idPaciente, string nombre, string apellido,
                                                int dni, DateTime fechaDeNac, string telefono,
                                                string correo, bool frecuente)
        {

            bool exito = true;
            if (idPaciente == -1)//para nuevos registros
            {
                var objPaciente = new PacienteViewModelPost()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Dni = dni,
                    FechaDeNac = fechaDeNac,
                    Telefono = telefono,
                    Correo = correo,
                    Frecuente = frecuente
                };
                exito = await PacienteService.InsertPaciente(objPaciente);
            }
            else
            {
                var objPaciente = new PacienteViewModel()
                {
                    IdPaciente = idPaciente,
                    Nombre = nombre,
                    Apellido = apellido,
                    Dni = dni,
                    FechaDeNac = fechaDeNac,
                    Telefono = telefono,
                    Correo = correo,
                    Frecuente = frecuente
                };
                exito = await PacienteService.UpdatePaciente(objPaciente);
            }
            return Json(exito);
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            var exito = await PacienteService.DeletePaciente(id);
            return Json(exito);
        }

    }
}
