using FrontendDentalCenter.Models;
using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class CitaController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaCita(int idMed)
        {

            var citas = await CitaServices.GetCitaIdMedico(idMed);
            var Medico = await MedicoService.GetMedicosbyId(idMed);
            
            List<int> ids = new List<int>();
            List < PacienteViewModel > pacientes = new List<PacienteViewModel>();
           

            foreach(var item in citas)
            {
                if(item.Estado == "Activa")
                {
                    ids.Add((int)item.IdPaciente);
                }
            }
            List<int> idDistic = ids.Distinct().ToList();

            foreach (var item in idDistic)
            {
                pacientes.Add((PacienteViewModel)await PacienteService.GetPacientesbyId(item));
            }

            ViewBag.citaList = citas;
            ViewBag.pacienteList = pacientes;
            ViewBag.Medico = Medico;
            
            return View();
        }
    }
}
