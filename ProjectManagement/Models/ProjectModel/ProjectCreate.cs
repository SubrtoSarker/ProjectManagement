using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.ProjectModel
{
    public class ProjectCreate
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
