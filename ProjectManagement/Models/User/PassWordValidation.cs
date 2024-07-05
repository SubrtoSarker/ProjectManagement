using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.User
{
    public class PassWordValidation
    {
        [Required]
        public string OTP { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [CustomPasswordValidation(ErrorMessage = "Invalid password.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
