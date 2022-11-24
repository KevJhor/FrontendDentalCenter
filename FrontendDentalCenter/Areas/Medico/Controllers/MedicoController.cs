using FrontendDentalCenter.Helpers;
using FrontendDentalCenter.Providers;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Tratamiento()
        {
            return View();
        }

        public async Task<IActionResult> RadioterapiaF(IFormFile imagen, int ubicacion)
        {
            string nombreImagen = imagen.FileName;

            string path = "";

            path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Images);


            ViewBag.Mensaje = "Elemento ingresado satisfactoriamente";
            
            return RedirectToAction("Radioterapia");

        }

    }
}
