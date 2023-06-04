using FrontendDentalCenter.Services;
using FrontendDentalCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Controllers
{
    public class RegisterController : Controller
    {
        public async Task<IActionResult> Guardar(string nombre, string apellido,string correo, int DNI, string telefono)
        {
            bool exito = true;
            var objPaciente = new PacienteViewModelPost2()
            {
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Dni = DNI,
                Telefono = telefono
            };
            exito = await PacienteService.InsertPaciente2(objPaciente);

        return Json(exito);
        }
        public async Task<IActionResult> GuardarUsuario(string correo, string contraseña)
        {
            bool exito = true;

            var todoPaciente = await PacienteService.GetPacientes();
            List<int> idPacientes = new List<int>();
            foreach (var item in todoPaciente)
            {
                idPacientes.Add((int)item.IdPaciente);
            }
            int idPac = idPacientes.Last();

            var objLogin = new LoginPacientePostViewModel()
            {
                Usuario = correo,
                Contraseña = contraseña,
                IdPaciente = idPac,
                Tipo = "Paciente"
            };
            exito = await LoginService.InsertLogin(objLogin);
            return Json(exito);
        }
        public async Task<IActionResult> GuardarCabHistoria(string correo)
        {
            var pacientes = await PacienteService.GetPacientes();
            var idPaciente = 0;
            foreach(var item in pacientes)
            {
                if(correo == item.Correo)
                {
                    idPaciente = item.IdPaciente;
                }
            }
            DateTime hoy = DateTime.Today;
            bool exito = true;
            var objCabHistoria = new CabHistoriaMedicaViewModelPost()
            {
                IdPaciente = idPaciente,
                FechaDeActualizacion = hoy
            };
            exito = await HistoriaMedicaService.InsertHistoria(objCabHistoria);
            return Json(exito);
        }

    }
}
