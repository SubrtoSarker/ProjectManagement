using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Admin
{
    public class AllUser
    {
        [Key]
        public int intUserID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string strUserName { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^(\+8801|8801|01)[3-9]\d{8}$", ErrorMessage = "Invalid phone number.")]
        public string strPhone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string strEmail { get; set; }

        public int intTeamID { get; set; }
        public string strTeamName { get; set; }
        public int intBoss { get; set; }
    }
}
