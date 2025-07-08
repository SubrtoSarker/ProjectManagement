using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using Blazored.SessionStorage;
using ProjectManagement.Models.ProjectModel;
using ProjectManagement.Models.User;
using ProjectManagement.Services.Session;

namespace ProjectManagement.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorageService;
        public ProjectService(HttpClient httpClient, ISessionStorageService sessionStorageService)
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
        public async Task<string> AssigneUser(int User, int Project, bool Active, int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Project/ProjectAssign?User={User}&Project={Project}&Active={Active}&Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<string> Create(string Name, DateOnly DeadLine, int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Project/Create?Name={Name}&DeadLine={DeadLine}&Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Projects>> GetProjectByTeam(int TeamID, int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<Projects>>($"api/Project/GetProjectByTeam?TeamID={TeamID}&Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<List<UserPerProject>> GetUserPerProject(int TeamID, int ProjectID)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<UserPerProject>>($"api/Project/UserPerProject?TeamID={TeamID}&ProjectID={ProjectID}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<string> UdateStatus(int Type, int Project, int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Project/StausUpdate?Type={Type}&Project={Project}&Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<string> RequestAction(int RequestID, int Enroll, int Type)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Project/RequestAction?RequestID={RequestID}&Enroll={Enroll}&Type={Type}");
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
