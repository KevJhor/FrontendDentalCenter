using FrontendDentalCenter.Areas.Medico.Models;
using Newtonsoft.Json;

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
    }
}
