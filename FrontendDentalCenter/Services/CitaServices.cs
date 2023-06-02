using FrontendDentalCenter.Areas.Medico.Models;
using FrontendDentalCenter.Areas.Paciente.Models;
using FrontendDentalCenter.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace FrontendDentalCenter.Services
{
    public class CitaServices
    {
        public static async Task<IEnumerable<CitaViewModel>> GetCitaIdMedico(int id)
        {
            var url = "http://localhost:5010/api/Cita/CitaByDoctorId?id=" + id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var cita = JsonConvert.DeserializeObject<IEnumerable<CitaViewModel>>(apiResponse);
            return cita;
        }
        public static async Task<IEnumerable<CitaViewModel>> GetCitaByPacienteId(int id)
        {
            var url = "http://localhost:5010/api/Cita/CitaByPacienteId?id=" + id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var cita = JsonConvert.DeserializeObject<IEnumerable<CitaViewModel>>(apiResponse);
            return cita;
        }
        public static async Task<bool> UpdateCita(CitaViewModel cita)
        {
            var url = "http://localhost:5010/api/Cita/" + cita.IdCita;
            var json = JsonConvert.SerializeObject(cita);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PutAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var citaResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return citaResponse;
        }
        public static async Task<bool> InsertCita(PacienteCitaViewModelPost cita)
        {
            var url = "http://localhost:5010/api/Cita";
            var json = JsonConvert.SerializeObject(cita);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var citaResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return citaResponse;
        }
    }
}
