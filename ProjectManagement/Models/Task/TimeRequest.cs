using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Task
{
    public class TimeRequest
    {
        public int intTaskID { get; set; }

        [Required(ErrorMessage = "From time is required")]
        public TimeOnly FromTime { get; set; } = new TimeOnly(9, 0);

        [Required(ErrorMessage = "To time is required")]
        public TimeOnly ToTime { get; set; } = new TimeOnly(10, 0);

        [Required(ErrorMessage = "Please provide a reason")]
        [MinLength(10, ErrorMessage = "Reason must be at least 10 characters")]
        public string Reason { get; set; } = "";
    }
}
