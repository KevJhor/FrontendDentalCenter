using FrontendDentalCenter.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace FrontendDentalCenter.Services
{
    public class LoginService
    {
        public static async Task<bool> InsertLogin(LoginPacientePostViewModel usuario)
        {
            var url = "http://localhost:5010/api/Login/crear";
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var usuarioResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return usuarioResponse;
        }
    }
}
