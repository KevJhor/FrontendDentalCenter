using FrontendDentalCenter.Helpers;
using FrontendDentalCenter.Providers;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class OdontogramaController : Controller
    {
        private HelperUploadFiles helperUpload;

        public OdontogramaController(HelperUploadFiles helperUpload)
        {
            this.helperUpload = helperUpload;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(IFormFile imagen, int ubicacion)
        {
            string nombreImagen = imagen.FileName;

            string path = "";

            path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Images);


            ViewBag.Mensaje = "Fichero " + nombreImagen + " subido a " + path;
            return View();

        }
    }
}

