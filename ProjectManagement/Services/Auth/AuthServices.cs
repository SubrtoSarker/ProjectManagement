using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjectManagement.Models.User;

namespace ProjectManagement.Services.Auth
{
    public class AuthServices : IAuthServices
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthServices(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{"test"}:{"test"}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        }

        public async Task<User> LogIn(string UserName, string Password, int Type, string code)
        {
            try
            {
                var userList = await _httpClient.GetFromJsonAsync<List<User>>(
                    $"api/UserSecurity/SecurityCheck?Name={UserName}&Key={Password}&Type={Type}&Code={code}");
                return userList?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<User> Register(string Email, string Name, string Phone, string Password, int Team, int Enroll)
        {
            try
            {
                //var userList = await _httpClient.GetFromJsonAsync<List<User>>($"api/UserSecurity/Registration?Email={Email}&Name={Name}&Phone={Phone}&Password={Password}&Team={Team}&Enroll={Enroll}");
                var userList = await _httpClient.GetFromJsonAsync<List<User>>($"api/UserSecurity/Registration?Email={Email}&Name={Name}&Phone={Phone}&Key={Password}&Team={Team}&Enroll={Enroll}");
                return userList.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
