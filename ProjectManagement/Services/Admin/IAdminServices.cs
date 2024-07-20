using ProjectManagement.Models.Admin;

namespace ProjectManagement.Services.Admin
{
    public interface IAdminServices
    {
        Task<List<AllUser>> GetAllUser(int UserID);
        Task<List<Team>> GetAllTeam();
        Task<string> UpdateUser(int User, string Name, string Phone, string Email, int Team, bool Active, bool isboss, int Enroll);
        Task<string> Create(string Name, int Enroll);
    }
}
