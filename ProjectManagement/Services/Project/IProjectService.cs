using ProjectManagement.Models.ProjectModel;

namespace ProjectManagement.Services.Project
{
    public interface IProjectService
    {
        Task<string> Create(string Name, DateOnly DeadLIne, int Enroll);
        Task<List<Projects>> GetProjectByTeam(int TeamID, int Enroll);
        Task<string> UdateStatus(int Type, int Project, int Enroll);
        Task<List<UserPerProject>> GetUserPerProject(int TeamID, int ProjectID);
        Task<string> AssigneUser(int User, int Project, bool Active, int Enroll);
        Task<string> RequestAction(int RequestID, int Enroll, int Type);
    }
}
