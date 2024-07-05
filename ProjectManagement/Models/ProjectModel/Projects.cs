namespace ProjectManagement.Models.ProjectModel
{
    public class Projects
    {
        public int IntProjectID { get; set; }
        public string StrProjectName { get; set; }
        public bool IsCompleate { get; set; }
        public int DaysPassed { get; set; }
        public int UserCount { get; set; }
    }
}
