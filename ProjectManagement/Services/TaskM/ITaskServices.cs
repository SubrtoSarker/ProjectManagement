using ProjectManagement.Models.Task;

namespace ProjectManagement.Services.TaskM
{
    public interface ITaskServices
    {
        Task<List<ProjectPerUser>> GetProjectByUser(int Enroll, int Type);
        Task<string> CreateTask(string Name, string Description, string ReqFrom, int Enroll, int Project);
        Task<List<Tasks>> GetTasks(int Enroll, int Status);
        Task<Tasks> GetCurrentTasks(int Enroll);
        Task<List<Steps>> GetStepsByTask(int Task);
        Task<List<TransferUser>> TransferCheck(int Task, int User);
        Task<string> StepManage(int Type, string Name, bool IsDone, int StepID, int Enroll);
        Task<string> TaskManage(int Type, int TaskID, int User, int Status, TimeSpan Working, int Enroll);
    }
}
