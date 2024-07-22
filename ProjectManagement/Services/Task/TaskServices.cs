﻿using ProjectManagement.Models.Admin;
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
        public async Task<List<Tasks>> GetTasks(int Enroll, int Status)
        {
            try
            {
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
        public async Task<string> StepManage(int Type, string Name, bool IsDone, int StepID, int Enroll)
        {
            try
            {
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
    }
}
