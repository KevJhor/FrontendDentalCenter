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

    }
}
