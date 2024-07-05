using System.Collections.Generic;
using ProjectManagement.Models.User;

namespace ProjectManagement.Services.Auth
{
    public interface IAuthServices
    {
        Task<User> LogIn(string User, string Password, int Type, string code);
        Task<User> Register(string Email, string Name, string Phone, string Password, int Team, int Enroll);

    }
}
