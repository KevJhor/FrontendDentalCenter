using FrontendDentalCenter.Models;
using FrontendDentalCenter.ViewModels;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Text;

namespace FrontendDentalCenter.Services
{
    public class PacienteService
    {
        public static async Task<IEnumerable<PacienteViewModel>> GetPacientes()
        {
            var url = "http://localhost:5010/api/Paciente";
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var pacientes = JsonConvert.DeserializeObject<IEnumerable<PacienteViewModel>>(apiResponse);
            return pacientes;
        }
        public static async Task<PacienteViewModel> GetPacientesbyId(int id)
        {
            var url = "http://localhost:5010/api/Paciente/id?id=" + id;
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var pacientes = JsonConvert.DeserializeObject<PacienteViewModel>(apiResponse);
            return pacientes;
        }
        public static async Task<PacienteViewModelPost2> GetPacientesbyCorreo(string correo)
        {
            var url = "http://localhost:5010/api/Paciente/correo?correo=" + correo;
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var pacientes = JsonConvert.DeserializeObject<PacienteViewModelPost2>(apiResponse);
            int a = pacientes.IdPaciente;
            return pacientes;
        }

        public static async Task<bool> InsertPaciente(PacienteViewModelPost paciente)
        {
            var url = "http://localhost:5010/api/Paciente";
            var json = JsonConvert.SerializeObject(paciente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var pacienteResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return pacienteResponse;
        }
        public static async Task<bool> InsertPaciente2(PacienteViewModelPost2 paciente)
        {
            var url = "http://localhost:5010/api/Paciente";
            var json = JsonConvert.SerializeObject(paciente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var pacienteResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return pacienteResponse;
        }
        public static async Task<bool> UpdatePaciente(PacienteViewModel paciente)
        {
            var url = "http://localhost:5010/api/Paciente/" + paciente.IdPaciente;
            var json = JsonConvert.SerializeObject(paciente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PutAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var pacienteResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return pacienteResponse;
        }
        public static async Task<bool> DeletePaciente(int id)
        {
            var url = "http://localhost:5010/api/Paciente/" + id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.DeleteAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var pacienteResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return pacienteResponse;
        }
    }
}
