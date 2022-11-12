using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class HistoriaMedicaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaHistoriaMedica()
        {
            var historiaMedicas = await HistoriaMedicaService.GetHistoriaMedicaIdMedico(1);
            ViewBag.HistoriasMedicasList = historiaMedicas;
            return View();
        }


    }
}
