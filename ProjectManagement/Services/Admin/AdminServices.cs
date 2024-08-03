using Blazored.SessionStorage;
using ProjectManagement.Models.Admin;
using ProjectManagement.Services.Session;
using System.Net.Http.Headers;

namespace ProjectManagement.Services.Admin
{
    public class AdminServices : IAdminServices
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorageService;

        public AdminServices(HttpClient httpClient, ISessionStorageService sessionStorageService)
        {
            _httpClient = httpClient;
            _sessionStorageService = sessionStorageService;
        }

        private async Task SetAuthorizationHeader()
        {
            var session = await _sessionStorageService.GetItemAsync<SessionServices>("session");
            if (session != null && !string.IsNullOrEmpty(session.Key))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Key);
            }
        }
        public async Task<List<AllUser>> GetAllUser(int UserID, string Code)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<AllUser>>($"api/Admin/GetAllUser?UserID={UserID}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Team>> GetAllTeam()
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<Team>>($"api/Admin/GetAllTeam");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<string> UpdateUser(int User, string Name, string Phone, string Email, int Team, bool Active, bool isboss, int Enroll, bool Locked)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Admin/UpdateUser?User={User}&Name={Name}&Phone={Phone}&Email={Email}&Team={Team}&Active={Active}&isboss={isboss}&Enroll={Enroll}&Locked={Locked}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<string> Create(string Name, int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Admin/Create?Name={Name}&Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
