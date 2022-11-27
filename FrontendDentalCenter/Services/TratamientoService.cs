using FrontendDentalCenter.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace FrontendDentalCenter.Services
{
    public class TratamientoService
    {
        public static async Task<IEnumerable<TratamientoViewModel>> GetTratamientos()
        {
            var url = "http://localhost:5010/api/Tratamiento";
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var tratamientos = JsonConvert.DeserializeObject<IEnumerable<TratamientoViewModel>>(apiResponse);
            return tratamientos;
        }
        public static async Task<TratamientoViewModel> GetTratamientoById(int id)
        {
            var url = "http://localhost:5010/api/Tratamiento/" + id;
            using var htppClient = new HttpClient();
            using var response = await htppClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            apiResponse = apiResponse.Remove(0, 1);
            apiResponse = apiResponse.Remove(apiResponse.Length - 1, 1);
            string another = apiResponse;
            var tratamiento = JsonConvert.DeserializeObject<TratamientoViewModel>(another);
            return tratamiento;
        }
        public static async Task<bool> InsertTratamiento(TratamientoViewModelPost tratamiento)
        {
            var url = "http://localhost:5010/api/Tratamiento";
            var json = JsonConvert.SerializeObject(tratamiento);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var tratamientoResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return tratamientoResponse;
        }
        public static async Task<bool> UpdateTratamiento(TratamientoViewModel tratamiento)
        {
            var url = "http://localhost:5010/api/Tratamiento/" + tratamiento.IdTratamiento;
            var json = JsonConvert.SerializeObject(tratamiento);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var htppClient = new HttpClient();
            using var response = await htppClient.PutAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var tratamientoResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return tratamientoResponse;
        }
        public static async Task<bool> DeleteTratamiento(int id)
        {
            var url = "http://localhost:5010/api/Tratamiento/" + id;

            using var htppClient = new HttpClient();
            using var response = await htppClient.DeleteAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var tratamientoResponse = JsonConvert.DeserializeObject<bool>(apiResponse);
            return tratamientoResponse;
        }
    }
}
