using FrontendDentalCenter.Models;
using Newtonsoft.Json;

namespace FrontendDentalCenter.Services
{
    public class MedicoService
    {
        public static async Task<IEnumerable<MedicoViewModel>> GetMedicos()
        {
            var url = "http://localhost:5010/api/CabMedico/All";
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var Medicos = JsonConvert.DeserializeObject<IEnumerable<MedicoViewModel>>(apiResponse);
            return Medicos;
        }
    }
}
