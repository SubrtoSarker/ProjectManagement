using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.User
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [CustomPasswordValidation(ErrorMessage = "Invalid password.")]
        public string Password { get; set; }
        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the Terms of Service.")]
        //public bool RememberMe { get; set; }
    }
}
