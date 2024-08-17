﻿using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Models.Task
{
    public class PendingTask
    {
        [Key]
        public int intTaskID { get; set; }
        public string strProjectName { get; set; }
        public string strTaskName { get; set; }
        public string strDescription { get; set; }
        public string strStatus { get; set; }
        public TimeSpan tmWorking { get; set; }
    }
}
