using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;
using FrontendDentalCenter.Controllers;
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

        public async Task<IActionResult> RegistrarHistoriaAsync()
        {
            var Tratamientos = await TratamientoService.GetTratamientos();
            ViewBag.TratamientoList = Tratamientos;
            return View();
        }

    }
    
}
