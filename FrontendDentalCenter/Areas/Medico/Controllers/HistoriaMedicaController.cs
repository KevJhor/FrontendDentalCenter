using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;
using FrontendDentalCenter.Controllers;
using FrontendDentalCenter.Models;
using FrontendDentalCenter.ViewModels;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class HistoriaMedicaController : Controller
    {
        private readonly SecurityController securityController;
        int idMedico;
        public HistoriaMedicaController(SecurityController security)
        {
            securityController = security;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaHistoriaMedica()
        {
            
            var historiaMedicas = await HistoriaMedicaService.GetHistoriaMedicaIdMedico(securityController.getIdMedico());
            ViewBag.HistoriasMedicasList = historiaMedicas;
            return View();
        }

        /*public async Task<IActionResult> RegistrarHistoria(PacienteViewModel paciente)
        {
            var Tratamientos = await TratamientoService.GetTratamientos();
            ViewBag.TratamientoList = Tratamientos;
            ViewBag.PacienteList = paciente;
            return View();
        }*/

        public async Task<IActionResult> RegistrarHistoria(string Nombre, string Correo, string Apellido, string Telefono, string Dni, string NombreM, string ApellidoM)
        {
            var Tratamientos = await TratamientoService.GetTratamientos();
            var Medicamentos = await MedicamentoServices.GetMedicamentos();
            ViewBag.TratamientoList = Tratamientos;
            ViewBag.NombreList = Nombre;
            ViewBag.CorreoList = Correo;
            ViewBag.ApellidoList = Apellido;
            ViewBag.TelefonoList = Telefono;
            ViewBag.DniList = Dni;
            ViewBag.NombreM = NombreM;
            ViewBag.ApellidoM = ApellidoM;
            ViewBag.MedicamentoList = Medicamentos;
            return View();
        }

        public async Task<IActionResult> CrearCabecera(string nombreClinica, DateTime fecha)
        {
            CabRecetaViewModelPost cabModel = new CabRecetaViewModelPost();
            cabModel.NombreDeClinica = nombreClinica;
            cabModel.Fecha = fecha;
            bool exito = await CabRecetaServices.InsertCabReceta(cabModel);
            return Json(exito);
        }
    }
    
}
