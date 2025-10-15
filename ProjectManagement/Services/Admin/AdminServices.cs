using Blazored.SessionStorage;
using ProjectManagement.Models.Admin;
using ProjectManagement.Models.Task;
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
        public async Task<List<AllUser>> GetAllUser(int UserID)
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
        public async Task<List<DateWiseReport>> GetTeamReport(int Enroll, DateTime From, DateTime To)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<DateWiseReport>>($"api/Admin/GetTeamReport?Enroll={Enroll}&From={From}&To={To}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<CompleatedReport>> CompleatedReport(DateTime From, DateTime To)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<CompleatedReport>>($"api/Admin/GetCompleatedReport?From={From}&To={To}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<PendingTask>> GetPendingTasks(int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<PendingTask>>($"api/Admin/GetPendingTasks?Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Performance>> GetPerFormance(DateTime From, DateTime To, int User, int Project)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<Performance>>($"api/Admin/GetPerFormance?From={From}&To={To}&User={User}&Project={Project}");
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
