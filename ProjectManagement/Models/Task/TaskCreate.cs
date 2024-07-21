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
    }
}
