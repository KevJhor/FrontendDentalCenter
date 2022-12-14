using FrontendDentalCenter.Areas.Medico.Models;
using FrontendDentalCenter.Helpers;
using FrontendDentalCenter.Models;
using FrontendDentalCenter.Providers;
using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class MedicoController : Controller
    {
       
        //private int idMedico;
        /*public MedicoController(int id)
        {
            idMedico = id;
            
        }*/
        
        
        public async Task<IActionResult> Index(int idM)
        {
            //ViewBag.idMedico = idM;
            var Medico = await MedicoService.GetMedicosbyId(idM);
            ViewBag.Medico = Medico;
            return View();
        }
        public IActionResult Odontograma()
        {
            return View();
        }
       

        /*public IActionResult Tratamiento()
        {
            var Tratamientos = TratamientoService.GetTratamientos();
            ViewBag.TratamientoList = Tratamientos;
            return View();
        }*/

        public async Task<IActionResult> Tratamiento()
        {
            var Tratamientos = await TratamientoService.GetTratamientos();
            ViewBag.TratamientoList = Tratamientos;
            return View();
        }
        
        public IActionResult CancelarTratamiento()
        {

            return RedirectToAction("RegistrarHistoria", "HistoriaMedica", new { Area = "Medico" });


        }
       
        /*public async Task<IActionResult> ListaHistoriaMedicaByPaciente(int id,string Nombre, string Apellido)
        {
            var Historia = await MedicoService.GetHistoriaMedicaByIdPaciente(id);
            List<CabHistoriaMedicaViewModel> cabHistoria = new List<CabHistoriaMedicaViewModel>();
            List<MedicoViewModel> medicos = new List<MedicoViewModel>();
            //List<HistoriaMedicaViewModel> historiaMed = new List<HistoriaMedicaViewModel>();
            
            foreach(var item in Historia)
            {
                cabHistoria.AddRange(await MedicoService.GetCabHistoriaMedicabyId(item.IdHistoriaMedica));
                medicos.Add(await MedicoService.GetMedicosbyId(item.IdMedico));
                //historiaMed.AddRange(await HistoriaMedicaService.GetHistoriaMedicaIdCab(item.IdHistoriaMedica));
            }
            ViewBag.HistoriaList = Historia;
            ViewBag.CabHistoriaList = cabHistoria;
            ViewBag.MedicoList = medicos;
            ViewBag.Nombres = Nombre;
            ViewBag.Apellidos = Apellido;
            //ViewBag.ListHistoriaMed = historiaMed;
            return View();
        }*/
        public async Task<IActionResult> ListaHistoriaMedica(int id, string Nombre, string Apellido)
        {
            var Historia = await MedicoService.GetHistoriaMedicaByIdPaciente(id);
            List<CabHistoriaMedicaViewModel> cabHistoria = new List<CabHistoriaMedicaViewModel>();
            List<MedicoViewModel> medicos = new List<MedicoViewModel>();
            //List<HistoriaMedicaViewModel> historiaMed = new List<HistoriaMedicaViewModel>();

            foreach (var item in Historia)
            {
                cabHistoria.AddRange(await MedicoService.GetCabHistoriaMedicabyId(item.IdHistoriaMedica));
                medicos.Add(await MedicoService.GetMedicosbyId(item.IdMedico));
                //historiaMed.AddRange(await HistoriaMedicaService.GetHistoriaMedicaIdCab(item.IdHistoriaMedica));
            }
            ViewBag.HistoriaList = Historia;
            ViewBag.CabHistoriaList = cabHistoria;
            ViewBag.MedicoList = medicos;
            ViewBag.Nombres = Nombre;
            ViewBag.Apellidos = Apellido;
            //ViewBag.ListHistoriaMed = historiaMed;
            return View();
        }

       

    }
}
