using FrontendDentalCenter.Areas.Medico.Models;
using FrontendDentalCenter.Models;
using FrontendDentalCenter.ViewModels;
using Newtonsoft.Json;
using System.Text;

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

        public static async Task<IEnumerable<HistoriaMedicaViewModel>> GetHistoriaMedicaIdCab(int id)
        {
            var url = "http://localhost:5010/api/HistorialMedico/CabHistoria/Id?id=" + id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var historiaMed = JsonConvert.DeserializeObject<IEnumerable<HistoriaMedicaViewModel>>(apiResponse);
            return historiaMed;
        }
        public static async Task<IEnumerable<HistoriaMedicaViewModel>> GetHistoriaMedicaIdPac(int id)
        {
            var url = "http://localhost:5010/api/HistorialMedico/CabHistoria/IdPaciente?id=" + id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var historiaMed = JsonConvert.DeserializeObject<IEnumerable<HistoriaMedicaViewModel>>(apiResponse);
            return historiaMed;
        }
        public static async Task<bool> InsertDetHistoria(HistoriaMedicaViewModelPost historia)
        {
            var url = "http://localhost:5010/api/HistorialMedico/Detalle";
            var json = JsonConvert.SerializeObject(historia);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var historiaResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return historiaResponse;
        }
        public static async Task<bool> InsertHistoria(CabHistoriaMedicaViewModelPost cabhistoria)
        {
            var url = "http://localhost:5010/api/HistorialMedico/Cabecera";
            var json = JsonConvert.SerializeObject(cabhistoria);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var cabhistoriaResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return cabhistoriaResponse;
        }
    }
}
