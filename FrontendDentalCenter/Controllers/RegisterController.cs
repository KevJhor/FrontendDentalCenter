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
            var idPac = await PacienteService.GetPacientesbyCorreo(correo);
            var idPaciente = idPac.IdPaciente;
            var objLogin = new LoginPacientePostViewModel()
            {
                Usuario = correo,
                Contraseña = contraseña,
                IdPaciente = idPaciente,
                Tipo = "Paciente"
            };
            exito = await LoginService.InsertLogin(objLogin);
            return Json(exito);
        }
    }
}
