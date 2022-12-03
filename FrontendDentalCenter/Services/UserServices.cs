using FrontendDentalCenter.Models;
using Newtonsoft.Json;
using System.Text;

namespace FrontendDentalCenter.Services
{
    public class UserServices
    {
        public static async Task<LoginGetShowViewModel> Login(LoginData userAuth)
        {
            var json = JsonConvert.SerializeObject(userAuth);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var url = "http://localhost:5010/api/Login";
            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(url, data);

            var apiResponse = await response.Content.ReadAsStringAsync();
            
            var userResponse = JsonConvert.DeserializeObject<LoginGetShowViewModel>(apiResponse);

            return userResponse;
        }
    }
}
