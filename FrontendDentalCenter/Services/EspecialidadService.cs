using FrontendDentalCenter.Areas.Paciente.Models;
using Newtonsoft.Json;

namespace FrontendDentalCenter.Services
{
    public class EspecialidadService
    {
        public static async Task<IEnumerable<EspecialidadViewModel>> GetEspecialidades()
        {
            var url = "http://localhost:5010/api/Especialidad";
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var especialidad = JsonConvert.DeserializeObject<IEnumerable<EspecialidadViewModel>>(apiResponse);
            return especialidad;
        }

    }
}
