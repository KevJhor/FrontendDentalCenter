using FrontendDentalCenter.Areas.Medico.Models;
using FrontendDentalCenter.Models;
using FrontendDentalCenter.ViewModels;
using Newtonsoft.Json;
using System.Text;

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
        public static async Task<bool> InsertMedico(MedicoViewModelPost medico)
        {
            var url = "http://localhost:5010/api/CabMedico";
            var json = JsonConvert.SerializeObject(medico);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var medicoResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return medicoResponse;
        }
        public static async Task<bool> UpdateMedico(MedicoViewModel medico)
        {
            var url = "http://localhost:5010/api/CabMedico/" + medico.IdMedico;
            var json = JsonConvert.SerializeObject(medico);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PutAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var medicoResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return medicoResponse;
        }
        public static async Task<bool> DeleteMedico(int id)
        {
            var url = "http://localhost:5010/api/CabMedico/" + id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.DeleteAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var medicoResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return medicoResponse;
        }
    }
}
