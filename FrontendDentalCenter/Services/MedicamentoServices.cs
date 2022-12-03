using FrontendDentalCenter.ViewModels;
using Newtonsoft.Json;

namespace FrontendDentalCenter.Services
{
    public class MedicamentoServices
    {
        public static async Task<IEnumerable<MedicamentoViewModel>> GetMedicamentos()
        {
            var url = "http://localhost:5010/api/Medicamento";
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var medicamentos = JsonConvert.DeserializeObject<IEnumerable<MedicamentoViewModel>>(apiResponse);
            return medicamentos;
        }

        public static async Task<IEnumerable<MedicamentoViewModel>> GetMedicamentosByIdCab(int id)
        {
            var url = "http://localhost:5010/api/Medicamento/IdCabReceta?id="+id;
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var medicamentos = JsonConvert.DeserializeObject<IEnumerable<MedicamentoViewModel>>(apiResponse);
            return medicamentos;
        }

        
    }
}
