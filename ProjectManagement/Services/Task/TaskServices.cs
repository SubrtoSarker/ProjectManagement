using ProjectManagement.Models.Admin;
using ProjectManagement.Models.ProjectModel;
using ProjectManagement.Models.Task;

namespace ProjectManagement.Services.Task
{
    public class TaskServices : ITaskServices
    {
        private readonly HttpClient _httpClient;
        public TaskServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> CreateTask(string Name, string Description, string ReqFrom, int Enroll, int Project)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Task/CreateTask?Name={Name}&Description={Description}&ReqFrom={ReqFrom}&Enroll={Enroll}&Project={Project}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<List<ProjectPerUser>> GetProjectByUser(int Enroll)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<ProjectPerUser>>($"api/Task/GetProjectByUser?Enroll={Enroll}");
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
