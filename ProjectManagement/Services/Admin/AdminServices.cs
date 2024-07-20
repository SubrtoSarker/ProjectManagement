using ProjectManagement.Models.Admin;

namespace ProjectManagement.Services.Admin
{
    public class AdminServices : IAdminServices
    {
        private readonly HttpClient _httpClient;
        public AdminServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AllUser>> GetAllUser(int UserID)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<AllUser>>($"api/Admin/GetAllUser?UserID={UserID}");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Team>> GetAllTeam()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<Team>>($"api/Admin/GetAllTeam");
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public async Task<string> UpdateUser(int User, string Name, string Phone, string Email, int Team, bool Active, bool isboss, int Enroll)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<string>($"api/Admin/UpdateUser?User={User}&Name={Name}&Phone={Phone}&Email={Email}&Team={Team}&Active={Active}&isboss={isboss}&Enroll={Enroll}");
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
