using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Task
{
    public class Tasks
    {
        [Key]
        public int intTaskID { get; set; }
        public string strTaskName { get; set; }
        public string strDescription { get; set; }
        public string strRequestFrom { get; set; }
        public TimeSpan tmWorking { get; set; }
        public string Agging { get; set; }
    }
}
