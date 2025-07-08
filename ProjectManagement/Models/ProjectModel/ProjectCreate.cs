using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.ProjectModel
{
    public class ProjectCreate
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateOnly DeadLine { get; set; }
    }
}
