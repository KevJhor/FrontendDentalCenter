using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrontendDentalCenter.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class MedicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado2()
        {
            var medicos = await MedicoService.GetMedicos();
            ViewBag.MedicoList = medicos;
            return PartialView();
        }

        public async Task<IActionResult> Listado()
        {
            var Medicos = await MedicoService.GetMedicos();
            ViewBag.MedicoList = Medicos;
            return PartialView();
        }
        public async Task<IActionResult> Guardar(int idMedico, string nombre,
                                                string apellido, string genero)
        {

            bool exito = true;
            if (idMedico == -1)//para nuevos registros
            {
                var objMedico = new MedicoViewModelPost()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Genero = genero
                };
                exito = await MedicoService.InsertMedico(objMedico);
            }
            else
            {
                var objMedico = new MedicoViewModel()
                {
                    IdMedico = idMedico,
                    Nombre = nombre,
                    Apellido = apellido,
                    Genero = genero
                };
                exito = await MedicoService.UpdateMedico(objMedico);
            }
            return Json(exito);
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            var exito = await MedicoService.DeleteMedico(id);
            return Json(exito);
        }
        public async Task<IActionResult> Obtener(int id)
        {
            var medico = await MedicoService.GetMedicosbyId(id);
            return Json(medico);
        }

    }
}
