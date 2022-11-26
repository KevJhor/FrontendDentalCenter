using FrontendDentalCenter.Areas.Medico.Models;
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
        public static async Task<IEnumerable<HistoriaMedicaViewModel>> GetHistoriaMedicaByIdPaciente(int id)
        {
            var url = "http://localhost:5010/api/HistorialMedico/HistoriaMedica/IdPaciente?id="+id;
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var historia = JsonConvert.DeserializeObject<IEnumerable<HistoriaMedicaViewModel>>(apiResponse);
            return historia;
        }
        public static async Task<IEnumerable<CabHistoriaMedicaViewModel>> GetCabHistoriaMedicabyId(int id)
        {
            var url = "http://localhost:5010/api/HistorialMedico/CabHistoria/Id?id=" + id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var historiaMed = JsonConvert.DeserializeObject<IEnumerable<CabHistoriaMedicaViewModel>>(apiResponse);
            return historiaMed;
        }
        public static async Task<MedicoViewModel> GetMedicosbyId(int id)
        {
            var url = "http://localhost:5010/api/CabMedico/id?id=" + id;
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var Medicos = JsonConvert.DeserializeObject<MedicoViewModel>(apiResponse);
            return Medicos;
        }
    }
}
