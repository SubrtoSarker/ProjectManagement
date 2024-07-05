using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.User
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^(\+8801|8801|01)[3-9]\d{8}$", ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [CustomPasswordValidation(ErrorMessage = "Invalid password.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the Terms of Service.")]
        public bool AgreeToTerms { get; set; }
    }
}
