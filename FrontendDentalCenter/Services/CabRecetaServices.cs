using FrontendDentalCenter.Areas.Paciente.Models;
using FrontendDentalCenter.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace FrontendDentalCenter.Services
{
    public class CabRecetaServices
    {
        public static async Task<IEnumerable<CabRecetaViewModel>> GetCabReceta()
        {
            var url = "http://localhost:5010/api/Receta/CabReceta";
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var cabReceta = JsonConvert.DeserializeObject<IEnumerable<CabRecetaViewModel>>(apiResponse);
            return cabReceta;
        }

        public static async Task<bool> InsertCabReceta(CabRecetaViewModelPost cab)
        {
            var url = "http://localhost:5010/api/Receta/CabReceta";
            var json = JsonConvert.SerializeObject(cab);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var cabResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return cabResponse;
        }
        public static async Task<CabRecetaViewModel> GetUltimaCabReceta()
        {
            var url = "http://localhost:5010/api/Receta/UltimaCabReceta";
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var cabReceta = JsonConvert.DeserializeObject<CabRecetaViewModel>(apiResponse);
            return cabReceta;
        }

        public static async Task<RecetaViewModel> GetRecetaByIdCab(int id)
        {
            var url = "http://localhost:5010/api/Receta/Receta/idCab?id="+id;
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var cabReceta = JsonConvert.DeserializeObject<RecetaViewModel>(apiResponse);
            return cabReceta;
        }


        public static async Task<bool> InsertReceta(RecetaViewModelPost rec)
        {
            var url = "http://localhost:5010/api/Receta/DetReceta";
            var json = JsonConvert.SerializeObject(rec);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var cabResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return cabResponse;
        }

        //""
    }
}
