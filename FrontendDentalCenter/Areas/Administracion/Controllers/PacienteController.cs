
using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
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
