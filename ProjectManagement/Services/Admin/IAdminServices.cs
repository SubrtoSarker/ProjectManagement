using ProjectManagement.Models.Admin;

namespace ProjectManagement.Services.Admin
{
    public interface IAdminServices
    {
        Task<List<AllUser>> GetAllUser();
    }
}
