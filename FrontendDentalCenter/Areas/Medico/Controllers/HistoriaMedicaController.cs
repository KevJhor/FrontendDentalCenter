using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;
using FrontendDentalCenter.Controllers;
namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class HistoriaMedicaController : Controller
    {
        int idMedico;
        public HistoriaMedicaController(SecurityController security)
        {
            idMedico = security.getIdMedico();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaHistoriaMedica()
        {
            
            var historiaMedicas = await HistoriaMedicaService.GetHistoriaMedicaIdMedico(idMedico);
            ViewBag.HistoriasMedicasList = historiaMedicas;
            return View();
        }

        public IActionResult RegistrarHistoria()
        {
            return View();
        }

    }
    
}
