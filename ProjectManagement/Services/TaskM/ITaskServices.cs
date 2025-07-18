﻿using ProjectManagement.Models.Task;

namespace ProjectManagement.Services.TaskM
{
    public interface ITaskServices
    {
        Task<List<ProjectPerUser>> GetProjectByUser(int Enroll, int Type);
        Task<string> CreateTask(string Name, string Description, string ReqFrom, int Priroty, DateOnly DeadLine, int Enroll, int Project);
        Task<List<Tasks>> GetTasks(int Enroll, int Status);
        Task<Tasks> GetCurrentTasks(int Enroll);
        Task<List<Steps>> GetStepsByTask(int Task);
        Task<List<TransferUser>> TransferCheck(int Task, int User);
        Task<string> StepManage(int Type, string Name, bool IsDone, int StepID, int Enroll);
        Task<string> TaskManage(int Type, int TaskID, int User, int Status, TimeSpan Working, int Enroll);
        Task<List<Performance>> GetPerFormance(DateTime From, DateTime To, int User, int Project);
        Task<string> Request(string TaskName, string Description, string RequestFrom, int USerID, int Project, DateTime Date, int Status, TimeSpan tm, string From, string To);
        Task<List<Request>> GetRequest(int User, Boolean isSuperviser);
        Task<List<Notify>> GetNotify(int User);
        Task<List<PendingTask>> GetPendingTasks(int Enroll);
        Task<Tasks> GetTask(int TaskID);
        Task<string> TaskUpdate(Tasks task, int USerID);

    }
}
