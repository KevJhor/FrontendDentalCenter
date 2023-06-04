using FrontendDentalCenter.Areas.Medico.Models;
using FrontendDentalCenter.Helpers;
using FrontendDentalCenter.Models;
using FrontendDentalCenter.Providers;
using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using Microsoft.JSInterop;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;

namespace FrontendDentalCenter.Areas.Medico.Controllers
{
    [Area("Medico")]
    public class MedicoController : Controller
    {

        private int _miVariable;
        public int MiVariable
        {
            get { return _miVariable; }
            set { _miVariable = value; }
        }
        public IActionResult X()
        {
            _miVariable = (int)TempData["MiVariable"];
            return View();
        }
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public async Task<IActionResult> Index(int idM)
        {
            if (idM!=0)
            {
                _id = idM;
            }
            var Medico = await MedicoService.GetMedicosbyId(idM);
            if (idM == 0)
            {
                Medico = await MedicoService.GetMedicosbyId(id);
            }
            ViewBag.Medico = Medico;
            return View();
        }
        public IActionResult Odontograma()
        {
            return View();
        }
      

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
        public async Task<IActionResult> ListaHistoriaMedica(int id, string Nombre, string Apellido, int idCita, int idM)
        {
            var Paciente = await PacienteService.GetPacientes();
            int idPaciente = 0;
            foreach(var item in Paciente)
            {
                if (Nombre == item.Nombre)
                {
                    idPaciente = item.IdPaciente;
                }
            }
            var Citas = await CitaServices.GetCitaByPacienteId(idPaciente);
            List<CitaViewModel> listaCitas = new List<CitaViewModel>();
            var Historia = await MedicoService.GetHistoriaMedicaByIdPaciente(id);
            var Tratamiento = await TratamientoService.GetTratamientos();
            List<CabHistoriaMedicaViewModel> cabHistoria = new List<CabHistoriaMedicaViewModel>();
            List<MedicoViewModel> medicos = new List<MedicoViewModel>();
            var Medicamento = await MedicamentoServices.GetMedicamentos();
            foreach (var item in Historia)
            {
                cabHistoria.AddRange(await MedicoService.GetCabHistoriaMedicabyId(item.IdHistoriaMedica));
                medicos.Add(await MedicoService.GetMedicosbyId(item.IdMedico));
            }
            ViewBag.HistoriaList = Historia;
            ViewBag.CabHistoriaList = cabHistoria;
            ViewBag.MedicoList = medicos;
            ViewBag.Nombres = Nombre;
            ViewBag.Apellidos = Apellido;
            ViewBag.Tratamiento = Tratamiento;
            ViewBag.Medicamento = Medicamento;
            ViewBag.idCita = idCita;
            ViewBag.idM = idM;
            return View();
        }
        public async Task<IActionResult> GuardarReceta(string fecha)
        {
            DateTime hoy = DateTime.Today;
            bool exito = true;
            var objReceta = new CabRecetaViewModelPost()
            {
                NombreDeClinica = "DentalCenter",
                Fecha = hoy
            };
            exito = await CabRecetaServices.InsertCabReceta(objReceta);
            return Json(exito);
        }
        public async Task<IActionResult> GuardarDetHistoria(string tratamiento, string idPac, string apellido, int idCita)
        {
            var pacientes = await PacienteService.GetPacientes();
            var idPaciente=0;
            foreach (var item in pacientes)
            {
                if(item.Nombre == idPac)
                {
                    idPaciente = item.IdPaciente;
                }
            }
            bool exito = true;
            var cabReceta = await CabRecetaServices.GetUltimaCabReceta();
            int idReceta = cabReceta.IdRecetaMedica;
            var cabHistoria = await HistoriaMedicaService.GetHistoriaMedicaIdPac(idPaciente);
            var tratamientos = await TratamientoService.GetTratamientos();
            //Esto es para conseguir el idMedico
            var cita = await CitaServices.GetCitaByPacienteId(idPaciente);
            int idDoctor = 0;

            foreach (var item in cita)
            {
                if(item.IdCita == idCita)
                {
                    idDoctor = (int)item.IdMedico;
                }
                
            }
            int idTratamiento = 0;

            foreach (var item in tratamientos)
            {
                if (tratamiento == item.Descripcion)
                {
                    idTratamiento = item.IdTratamiento;
                }
            }
            int idCabHistoria = 0;

            foreach (var item in cabHistoria)
            {
                idCabHistoria = item.IdHistoriaMedica;
            }
            var objDetHistoria = new HistoriaMedicaViewModelPost()
            {
                IdHistoriaMedica = idCabHistoria,
                IdCita = idCita,
                IdMedico = idDoctor,
                IdAsistente = 1,
                IdRecetaMedica = idReceta,
                IdTratamiento = idTratamiento
            };
            exito = await HistoriaMedicaService.InsertDetHistoria(objDetHistoria);
            return Json(exito);
        }
        public async Task<IActionResult> GuardarDetReceta(string medicamento, string dosis, string unidad, string descripcion)
        {
            bool exito = true;
            var medicamentos = await MedicamentoServices.GetMedicamentos();
            var cabReceta = await CabRecetaServices.GetUltimaCabReceta();
            int idReceta = cabReceta.IdRecetaMedica;

            var idMedicamento = 0;
            foreach (var item in medicamentos)
            {
                if (item.Nombre == medicamento)
                {
                    idMedicamento = item.IdMedicamento;
                }
            }
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            double valDosis = Convert.ToDouble(dosis, provider);
            var objDetReceta = new RecetaViewModelPost()
            {
                IdRecetaMedica = idReceta,
                IdMedicamento = idMedicamento,
                Dosis = valDosis,
                UnidadMedida = unidad,
                Descripcion = descripcion
            };
            exito = await CabRecetaServices.InsertReceta(objDetReceta);

            return Json(exito);
        }
        public async Task<IActionResult> ObtenerReceta(int id)
        {
            var recetas = await CabRecetaServices.GetRecetaByIdCab(id);
            var medicamentos = await MedicamentoServices.GetMedicamentos();
            var unaReceta = new ValoresTablaMedicamentoViewModel();
            foreach (var item in recetas)
            {
                string nombreMedicamento = "";
                foreach(var item2 in medicamentos)
                {
                    if(item.IdMedicamento==item2.IdMedicamento)
                    {
                        nombreMedicamento = item2.Nombre;
                    }
                }

                unaReceta = new ValoresTablaMedicamentoViewModel()
                {
                    Medicamento = nombreMedicamento,
                    Dosis = item.Dosis.ToString(),
                    UnidadMedida = item.UnidadMedida,
                    Descripcion = item.Descripcion
                };
            }
            return Json(unaReceta);
        }
    }
}
