using FrontendDentalCenter.Areas.Medico.Controllers;
using FrontendDentalCenter.Helpers;
using FrontendDentalCenter.Models;
using FrontendDentalCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontendDentalCenter.Controllers
{
    
    public class SecurityController : Controller
    {
        

        private int IDMedico;
        private int IdPaciente;
        private int IdAdmin;
        public int getIdMedico()
        {
            return IDMedico;
        }
        public int getIdPaciente()
        {
            return IdPaciente;
        }
        public int getIdAdmin(int id)
        {
            return IdAdmin;
        }
        public void setIdMedico(int id)
        {
            IDMedico = id;
        }
        public void setIdPaciente(int id)
        {
            IdPaciente = id;
        }
        public void setIdAdmin(int id)
        {
            IdAdmin = id;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

       /* [HttpPost]
        public IActionResult Validate(string email, string password)
        {
            if (email == "admin@peru.com" && password == "admin123")
                return RedirectToAction("Index", "Paciente", new { Area = "Administracion" });

            return RedirectToAction("Login", "Security");
        }*/


        public async Task<IActionResult> Signin(string correo, string clave)
        {
           
            var userLogin = new LoginData() 
            {
                Usuario = correo,
                Contraseña = clave
            };
            var auth = await UserServices.Login(userLogin);
            setIdMedico(auth.IdMedico);
            setIdPaciente(auth.IdPaciente);
            setIdAdmin(auth.IdAsistente);
            
           // MedicoController medicoController = new MedicoController(HelperUploadFiles,auth.IdMedico);
            if (auth == null || auth.Tipo==null)
                  return RedirectToAction("Login");
            else
            {
                if (auth.Tipo == "Medico")
                {
                    
                    return RedirectToAction("Index", "Medico", new { Area = "Medico", idM = getIdMedico() });
                }
                else if (auth.Tipo == "Paciente")
                {
                    return RedirectToAction("Index", "Home", new { Area = "Paciente", idP = getIdPaciente() });
                }

                //else if (auth.Tipo == "Administrador")
                //{
                //    return RedirectToAction("Index", "Home", new { Area = "Administracion", idA = getIdAdmin() });
                //}
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }





           /* if (correo == "renzo@uesan.com" && clave == "12345678")
            {
                return RedirectToAction("Index", "Home", new {Area = "Paciente"});
            }
            else
            {
                return View("Login");
            }*/
        }



    }

    
}
