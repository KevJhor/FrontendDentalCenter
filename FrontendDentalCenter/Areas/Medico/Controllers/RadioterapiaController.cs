using FrontendDentalCenter.Helpers;
using FrontendDentalCenter.Providers;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class RadioterapiaController : Controller
    {
        private HelperUploadFiles helperUpload;
        
        public RadioterapiaController(HelperUploadFiles helperUpload)
        {
            this.helperUpload = helperUpload;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Radioterapia()
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
