﻿using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using FrontendDentalCenter.Areas.Medico.Models;
using FrontendDentalCenter.Areas.Paciente.Models;
using System.Globalization;

namespace FrontendDentalCenter.Areas.Paciente.Controllers
{
    [Area("Paciente")]
    public class CitaController : Controller
    {
        public async Task<IActionResult> Index(int idP)
        {
            var Paciente = await PacienteService.GetPacientesbyId(idP);
            ViewBag.Paciente = Paciente;
            var especialidad = await EspecialidadService.GetEspecialidades();
            ViewBag.EspecialidadList = especialidad;
            var medico = await MedicoService.GetMedicos();
            ViewBag.MedicoList = medico;
            return View();
        }
        public async Task<IActionResult> RegistroCita(int idP)
        {
            var Paciente = await PacienteService.GetPacientesbyId(idP);
            ViewBag.Paciente = Paciente;
            var Medico = await MedicoService.GetMedicos();
            ViewBag.MedicoList = Medico;
            var Especialidad = await EspecialidadService.GetEspecialidades();
            ViewBag.Especialidades = Especialidad;
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var pacientes = await PacienteService.GetPacientes();
            ViewBag.PacienteList = pacientes;
            return PartialView();
        }
        public async Task<IActionResult> ListadoDeEspecialidades() 
        {
            var especialidad = await EspecialidadService.GetEspecialidades();
            ViewBag.EspecialidadList = especialidad;
            return View();
        }
        public async Task<IActionResult> TablaCitasPorPaciente(int idP)
        {
            var citas = await CitaServices.GetCitaByPacienteId(idP);
            ViewBag.CitasLista = citas;
            var medicos = await MedicoService.GetMedicos();
            ViewBag.Medicos = medicos;
            ViewBag.Paciente = idP;
            return View();
        }
        public async Task<IActionResult> GuardarCita(int idCita, int idPaciente,
                                                int idMedico, string estado, DateTime fechaHora)
        {
            bool exito = true;
            var objCita = new CitaViewModel()
            {
                IdCita = idCita,
                IdPaciente = idPaciente,
                IdMedico = idMedico,
                Estado = estado,
                FechaHora = fechaHora
            };
            exito = await CitaServices.UpdateCita(objCita);
            return Json(exito);
        }
        public async Task<IActionResult> CrearCita(int idCita, int idPaciente,
                                                string nombreMedico, string estado, string fecha, string hora)
        {
            bool exito = true;
            int idMedico=0;
            string compuesto = "";
            string? fechaYhora = "";
            fechaYhora = fecha + ' ' + hora;
            string formato = "yyyy-MM-dd HH:mm";
            DateTime fechaCita;
            DateTime.TryParseExact(fechaYhora, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaCita);
            var medicos = await MedicoService.GetMedicos();
            foreach(var item in medicos)
            {
                compuesto = item.Nombre + ' ' +item.Apellido;
                if(compuesto == nombreMedico)
                {
                    idMedico = item.IdMedico;
                }
            }
            var objCita = new PacienteCitaViewModelPost()
            {
                IdPaciente = idPaciente,
                IdMedico = idMedico,
                Estado = estado,
                FechaHora = fechaCita//lo recibe en dos partes
            };
            exito = await CitaServices.InsertCita(objCita);
            return Json(exito);
        }
    }
}
