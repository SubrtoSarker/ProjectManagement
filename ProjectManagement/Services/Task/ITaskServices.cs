using ProjectManagement.Models.Task;

namespace ProjectManagement.Services.Task
{
    public interface ITaskServices
    {
        Task<List<ProjectPerUser>> GetProjectByUser(int Enroll);
        Task<string> CreateTask(string Name, string Description, string ReqFrom, int Enroll, int Project);
    }
}
