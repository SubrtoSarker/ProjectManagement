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

        public async Task<List<AllUser>> GetAllUser()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<AllUser>>($"api/Admin/GetAllUser");
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
