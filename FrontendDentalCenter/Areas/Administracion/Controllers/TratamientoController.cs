using FrontendDentalCenter.ViewModels;
using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrontendDentalCenter.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class TratamientoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var tratamientos = await TratamientoService.GetTratamientos();
            ViewBag.TratamientoList = tratamientos;
            return PartialView();
        }

        public async Task<IActionResult> Obtener(int id)
        {
            var tratamiento = await TratamientoService.GetTratamientoById(id);
            return Json(tratamiento);
        }
        public async Task<IActionResult> Guardar(int idTratamiento, string tipo,
                                                int duracionDias, double precio, string descripcion)
        {

            bool exito = true;
            if (idTratamiento == -1)//para nuevos registros
            {
                var objTratamiento = new TratamientoViewModelPost()
                {
                    Tipo = tipo,
                    DuracionDias = duracionDias,
                    Precio = precio,
                    Descripcion = descripcion
                };
                exito = await TratamientoService.InsertTratamiento(objTratamiento);
            }
            else
            {
                var objTratamiento = new TratamientoViewModel()
                {
                    IdTratamiento = idTratamiento,
                    Tipo = tipo,
                    DuracionDias = duracionDias,
                    Precio = precio,
                    Descripcion = descripcion
                };
                exito = await TratamientoService.UpdateTratamiento(objTratamiento);
            }
            return Json(exito);
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            var exito = await TratamientoService.DeleteTratamiento(id);
            return Json(exito);
        }
    }
}
