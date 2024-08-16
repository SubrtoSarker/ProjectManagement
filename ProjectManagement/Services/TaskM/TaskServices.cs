using Blazored.SessionStorage;
using ProjectManagement.Models.Admin;
using ProjectManagement.Models.ProjectModel;
using ProjectManagement.Models.Task;
using ProjectManagement.Services.Session;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace ProjectManagement.Services.TaskM
{
    public class TaskServices : ITaskServices
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorageService;
        public TaskServices(HttpClient httpClient, ISessionStorageService sessionStorageService)
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
        public async Task<string> CreateTask(string Name, string Description, string ReqFrom, int Enroll, int Project)
        {
            try
            {
                await SetAuthorizationHeader();
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

        public async Task<List<ProjectPerUser>> GetProjectByUser(int Enroll, int Type)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<ProjectPerUser>>($"api/Task/GetProjectByUser?Enroll={Enroll}&Type={Type}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Tasks>> GetTasks(int Enroll, int Status)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<Tasks>>($"api/Task/GetTasks?Enroll={Enroll}&Status={Status}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<Tasks> GetCurrentTasks(int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<Tasks>($"api/Task/GetCurrentTasks?Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Steps>> GetStepsByTask(int Task)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<Steps>>($"api/Task/GetStepsByTask?Task={Task}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<TransferUser>> TransferCheck(int Task, int User)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<TransferUser>>($"api/Task/TransferCheck?Task={Task}&User={User}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<string> StepManage(int Type, string Name, bool IsDone, int StepID, int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Task/StepManage?Type={Type}&Name={Name}&IsDone={IsDone}&StepID={StepID}&Enroll={Enroll}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<string> TaskManage(int Type, int TaskID, int User, int Status, TimeSpan Working, int Enroll)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Task/TaskManage?Type={Type}&TaskID={TaskID}&User={User}&Status={Status}&Working={Working}&Enroll={Enroll}");
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
                var result = await _httpClient.GetFromJsonAsync<List<Performance>>($"api/Task/GetPerFormance?From={From}&To={To}&User={User}&Project={Project}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<string> Request(string TaskName, string Description, string RequestFrom, int USerID, int Project, DateTime Date, int Status, TimeSpan tm, string From, string To)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Task/Request?TaskName={TaskName}&Description={Description}&RequestFrom={RequestFrom}&USerID={USerID}&Project={Project}&Date={Date}&Status={Status}&tm={tm}&From={From}&To={To}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Request>> GetRequest(int User, Boolean isSuperviser)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<Request>>($"api/Task/GetRequestList?User={User}&isSuperviser={isSuperviser}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Notify>> GetNotify(int User)
        {
            try
            {
                await SetAuthorizationHeader();
                var result = await _httpClient.GetFromJsonAsync<List<Notify>>($"api/Task/GetNotify?Enroll=2");
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
