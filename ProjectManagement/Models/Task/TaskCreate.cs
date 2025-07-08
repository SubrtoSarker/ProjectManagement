using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Task
{
    public class TaskCreate
    {
        [Required(ErrorMessage = "Name is required.")]
        public string strTaskName { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string strDescription { get; set; }
        [Required(ErrorMessage = "RequestFrom is required.")]
        public string strRequestFrom { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public DateOnly DeadLine { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        public TaskPriority Priroty { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Check if deadline is today or later
            if (DeadLine < DateOnly.FromDateTime(DateTime.Today))
            {
                yield return new ValidationResult(
                    "Deadline must be today or a future date.",
                    new[] { nameof(DeadLine) });
            }

            // Ensure priority is greater than 0
            if ((int)Priroty <= 0)
            {
                yield return new ValidationResult(
                    "Priority must be selected.",
                    new[] { nameof(Priroty) });
            }
        }

    }
    public enum TaskPriority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
}
