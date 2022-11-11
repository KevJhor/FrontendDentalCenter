using FrontendDentalCenter.Models;
using Newtonsoft.Json;

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
    }
}
