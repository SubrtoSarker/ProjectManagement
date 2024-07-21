using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using ProjectManagement.Models.ProjectModel;
using ProjectManagement.Models.User;

namespace ProjectManagement.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;
        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AssigneUser(int User, int Project, bool Active, int Enroll)
        {
            try
            {
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

        public async Task<string> Create(string Name, int Enroll)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Project/Create?Name={Name}&Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Projects>> GetProjectByTeam(int TeamID, int Enroll)
        {
            try
            {
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

    }
}
