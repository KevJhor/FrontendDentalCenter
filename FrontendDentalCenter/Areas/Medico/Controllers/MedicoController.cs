using FrontendDentalCenter.Areas.Medico.Models;
using FrontendDentalCenter.Helpers;
using FrontendDentalCenter.Models;
using FrontendDentalCenter.Providers;
using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class MedicoController : Controller
    {
        private HelperUploadFiles helperUpload;
        public MedicoController(HelperUploadFiles helperUpload)
        {
            this.helperUpload = helperUpload;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Odontograma()
        {
            return View();
        }
        public IActionResult Radioterapia()
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



        public async Task<IActionResult> RadioterapiaF(IFormFile imagen, int ubicacion)
        {
            string nombreImagen = imagen.FileName;

            string path = "";

            path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Images);


            ViewBag.Mensaje = "Elemento ingresado satisfactoriamente";
            
            return RedirectToAction("Radioterapia");

        }
        public async Task<IActionResult> ListaHistoriaMedicaByPaciente(int id)
        {
            var Historia = await MedicoService.GetHistoriaMedicaByIdPaciente(1);
            List<CabHistoriaMedicaViewModel> cabHistoria = new List<CabHistoriaMedicaViewModel>();
            List<MedicoViewModel> medicos = new List<MedicoViewModel>();
            foreach(var item in Historia)
            {
                cabHistoria.AddRange(await MedicoService.GetCabHistoriaMedicabyId(item.IdHistoriaMedica));
                medicos.Add(await MedicoService.GetMedicosbyId(item.IdMedico));
            }
            ViewBag.HistoriaList = Historia;
            ViewBag.CabHistoriaList = cabHistoria;
            ViewBag.MedicoList = medicos;
            return View();
        }

        

    }
}
