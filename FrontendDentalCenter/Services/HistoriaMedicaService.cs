using FrontendDentalCenter.Areas.Medico.Models;
using FrontendDentalCenter.Models;
using Newtonsoft.Json;

namespace FrontendDentalCenter.Services
{
    public class HistoriaMedicaService
    {
        public static async Task<IEnumerable<HistoriaMedicaViewModel>> GetHistoriaMedicaIdMedico(int id)
        {
            var url = "http://localhost:5010/api/HistorialMedico/idMedico?id="+id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var historiaMed = JsonConvert.DeserializeObject<IEnumerable<HistoriaMedicaViewModel>>(apiResponse);
            return historiaMed;
        }

    }
}
