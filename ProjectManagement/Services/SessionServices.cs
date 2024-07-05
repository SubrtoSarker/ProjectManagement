namespace ProjectManagement.Services
{
    public class SessionServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private int GetSessionInt(string key) =>
            _httpContextAccessor.HttpContext.Session.GetInt32(key) ?? 0;

        private void SetSessionInt(string key, int value) =>
            _httpContextAccessor.HttpContext.Session.SetInt32(key, value);

        private string GetSessionString(string key) =>
            _httpContextAccessor.HttpContext.Session.GetString(key);

        private void SetSessionString(string key, string value) =>
            _httpContextAccessor.HttpContext.Session.SetString(key, value);

        public int UserID
        {
            get => GetSessionInt("UserID");
            set => SetSessionInt("UserID", value);
        }

        public string Name
        {
            get => GetSessionString("Name");
            set => SetSessionString("Name", value);
        }
        public string Phone
        {
            get => GetSessionString("Phone");
            set => SetSessionString("Phone", value);
        }
        public string Email
        {
            get => GetSessionString("Email");
            set => SetSessionString("Email", value);
        }

        public int TeamID
        {
            get => GetSessionInt("TeamID");
            set => SetSessionInt("TeamID", value);
        }

        public string TeamName
        {
            get => GetSessionString("TeamName");
            set => SetSessionString("TeamName", value);
        }
        public string Boss
        {
            get => GetSessionString("Boss");
            set => SetSessionString("Boss", value);
        }
        public string Admin
        {
            get => GetSessionString("Admin");
            set => SetSessionString("Admin", value);
        }
        public string Key
        {
            get => GetSessionString("Key");
            set => SetSessionString("Key", value);
        }
        public async Task InitializeAsync()
        {
            await Task.CompletedTask;
            UserID = 0;
            Name = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            TeamID = 0;
            TeamName = string.Empty;
            Boss = string.Empty;
            Admin = string.Empty;
            Key = string.Empty;
        }
        public void ClearSession()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
