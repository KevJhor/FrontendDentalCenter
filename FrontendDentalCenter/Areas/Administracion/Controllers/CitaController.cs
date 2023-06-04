using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using FrontendDentalCenter.Areas.Paciente.Models;
using FrontendDentalCenter.Areas.Medico.Models;

namespace FrontendDentalCenter.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class CitaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListadoCitas()
        {
            var citas = await CitaServices.GetCitas();
            ViewBag.citaList = citas;
            return PartialView();
        }
        public async Task<IActionResult> Obtener(int id)
        {
            var cita = await CitaServices.GetCitaByCitaId(id);
            return Json(cita);
        }
        public async Task<IActionResult> Guardar(int idCita, int idPaciente,
                                                int idMedico, string estado, DateTime fechaHora)
        {

            bool exito = true;
            if (idCita == -1)//para nuevos registros
            {
                var objCita = new PacienteCitaViewModelPost()
                {
                    IdPaciente = idPaciente,
                    IdMedico = idMedico,
                    Estado = estado,
                    FechaHora = fechaHora
                };
                exito = await CitaServices.InsertCita(objCita);
            }
            else
            {
                var objCita = new CitaViewModel()
                {
                    IdCita = idCita,
                    IdPaciente = idPaciente,
                    IdMedico = idMedico,
                    Estado = estado,
                    FechaHora = fechaHora
                };
                exito = await CitaServices.UpdateCita(objCita);
            }
            return Json(exito);
        }
    }
}
