using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.ProjectModel
{
    public class Projects
    {
        [Display(Name = "Project ID")]
        public int IntProjectID { get; set; }
        [Display(Name = "Name")]
        public string StrProjectName { get; set; }
        [Display(Name = "Compleate")]
        public bool IsCompleate { get; set; }
        [Display(Name = "Running Days")]
        public int DaysPassed { get; set; }
        [Display(Name = "Total User")]
        public int UserCount { get; set; }
    }
}
