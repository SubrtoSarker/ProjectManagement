using ProjectManagement.Models.ProjectModel;

namespace ProjectManagement.Services.Project
{
    public interface IProjectService
    {
        Task<string> Create(string Name, int Enroll);
        Task<List<Projects>> GetProjectByTeam(int TeamID, int Enroll);
        Task<string> UdateStatus(int Type, int Project, int Enroll);

    }
}
